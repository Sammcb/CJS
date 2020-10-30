using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire: TileEntity {
	private static int spreadRate = 10;
	private int tick;
	private Sprite[] sprites;
	private int spriteIndex = 0;

	new private void Start() {
		base.Start();
		Sprite[] allSprites = Resources.LoadAll<Sprite>("Tiles/Hell");
		sprites = new[] {allSprites[1], allSprites[2]};
		sr.sprite = sprites[spriteIndex++];
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		tick = UnityEngine.Random.Range(0, 6);
		StartCoroutine(Animate());
		StartCoroutine(SpreadFire());
		gameObject.tag = "Fire";
	}

	IEnumerator Animate() {
		while (true) {
			sr.sprite = sprites[spriteIndex++ % sprites.Length];
			yield return new WaitForSeconds(1);
		}
	}

	IEnumerator SpreadFire() {
		Level l = transform.parent.GetComponent<Level>();
		Wall walls = l.walls.GetComponent<Wall>();
		Grid g = l.GetComponent<Grid>();
		while (true) {
			if (++tick >= spreadRate) {
				tick = 0;
				for (float x = transform.position.x - 1; x <= transform.position.x + 1; x++) for (float y = transform.position.y - 1; y <= transform.position.y + 1; y++) {
					Vector3Int cell = g.WorldToCell(new Vector3(x, y, z));
					if (walls.TileType<WallTile>(cell.x, cell.y) || l.fires.tiles.Contains((Vector2Int) cell) || UnityEngine.Random.Range(0, 10) < 5) continue;
					if (l.coins.tiles.Contains((Vector2Int) cell)) l.coins.Tile((Vector2Int) cell).Burn();
					if (l.pois.tiles.Contains((Vector2Int) cell)) l.pois.Tile((Vector2Int) cell).Burn();
					l.fires.SetTile((Vector2Int) cell);
				}
			}
			yield return new WaitForSeconds(1);
		}
	}

	private void OnDestroy() {
		Grid g = transform.parent.GetComponent<Grid>();
		Vector3Int cell = g.WorldToCell(transform.position);
		transform.parent.GetComponent<Level>().fires.tiles.Remove((Vector2Int) cell);
	}
}
