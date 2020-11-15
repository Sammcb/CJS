using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire: AnimatedTileEntity {
	private static int spreadRate = 10;
	private int tick;
	private AudioClip burnSfx;
	private AudioSource source;


	new private void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/Fire");
		sr.sprite = sprites[0];
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		tick = UnityEngine.Random.Range(0, 6);
		StartCoroutine(Animate());
		StartCoroutine(SpreadFire());
		gameObject.tag = "Fire";
		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		burnSfx = Resources.Load<AudioClip>("SoundEffects/burnSFX");
	}

	IEnumerator SpreadFire() {
		bool burnSound = false;

		while (true) {
			if (++tick >= spreadRate) {
				tick = 0;
				for (float x = transform.position.x - 1; x <= transform.position.x + 1; x++) for (float y = transform.position.y - 1; y <= transform.position.y + 1; y++) {
					Vector3Int cell = level.g.WorldToCell(new Vector3(x, y, z));
					if (level.wall.TileType<WallTile>(cell.x, cell.y) || level.fires.tiles.Contains((Vector2Int) cell) || level.embers.tiles.Contains((Vector2Int) cell) || level.exit.position == (Vector2Int) cell || UnityEngine.Random.Range(0, 10) < 5) continue;
					if (level.coins.tiles.Contains((Vector2Int) cell)) {
						burnSound = true;
						level.coins.Tile((Vector2Int) cell).Burn();
					}
					if (level.pois.tiles.Contains((Vector2Int) cell)) {
						burnSound = true;
						level.pois.Tile((Vector2Int) cell).Burn();
					}
					if(burnSound) source.PlayOneShot(burnSfx);
					level.embers.SetTile((Vector2Int) cell);
				}
			}
			yield return new WaitForSeconds(1);
		}
	}

	private void OnDestroy() {
		Vector3Int cell = level.g.WorldToCell(transform.position);
		level.fires.tiles.Remove((Vector2Int) cell);
	}
}
