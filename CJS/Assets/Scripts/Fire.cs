using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire: AnimatedTileEntity {
	private static int spreadRate = 10;
	private int tick;

	new private void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/Fire");
		sr.sprite = sprites[0];
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		tick = UnityEngine.Random.Range(0, 6);
		StartCoroutine(Animate());
		StartCoroutine(SpreadFire());
		gameObject.tag = "Fire";
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
					if (walls.TileType<WallTile>(cell.x, cell.y) || l.fires.tiles.Contains((Vector2Int) cell) || l.exit.GetComponent<Exit>().position == (Vector2Int) cell ||UnityEngine.Random.Range(0, 10) < 5) continue;
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
