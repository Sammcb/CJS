using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire: CollideLevelTile {
	public static int spreadRate = 10;
	private List<int> fireTicks = new List<int>();

	new private void Awake() {
		base.Awake();
		FireTile t = ScriptableObject.CreateInstance<FireTile>();
		t.sprites = new[] {allSprites[1], allSprites[2]};
		tile = t;
		StartCoroutine(SpreadFire());
	}

	new public void FillTiles(Vector2Int a, Vector2Int b) {
		base.FillTiles(a, b);
		for (int i = 0; i < tilesPos.Count; i++) fireTicks.Add(UnityEngine.Random.Range(0, 6));
	}

	IEnumerator SpreadFire() {
		while (true) {
			List<Vector2Int> newPos = new List<Vector2Int>();
			for (int i = 0; i < tilesPos.Count; i++) {
				if (++fireTicks[i] >= spreadRate) {
					fireTicks[i] = 0;
					for (int x = tilesPos[i].x - 1; x <= tilesPos[i].x + 1; x++) for (int y = tilesPos[i].y - 1; y <= tilesPos[i].y + 1; y++) {
						Level l = transform.parent.GetComponent<Level>();
						Wall walls = l.walls.GetComponent<Wall>();
						if (walls.TileType<Tile>(x, y)) continue;
						if (TileType<FireTile>(x, y)) continue;
						tm.SetTile(new Vector3Int(x, y, IntZ()), tile);
						newPos.Add(new Vector2Int(x, y));
					}
				}
			}
			foreach (Vector2Int pos in newPos) {
				tilesPos.Add(pos);
				fireTicks.Add(UnityEngine.Random.Range(0, 6));
			}
			yield return new WaitForSeconds(1);
		}
	}
}
