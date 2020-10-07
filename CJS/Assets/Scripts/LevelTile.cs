using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelTile: MonoBehaviour {
	protected Tilemap tm;
	protected TilemapRenderer tmr;
	protected List<Tile> tiles = new List<Tile>();
	protected Sprite[] allSprites;

	protected void Awake() {
		allSprites = Resources.LoadAll<Sprite>("Tiles/Hell");
		tm = gameObject.AddComponent(typeof(Tilemap)) as Tilemap;
		tmr = gameObject.AddComponent(typeof(TilemapRenderer)) as TilemapRenderer;
	}

	public void FillTiles(Vector2Int a, Vector2Int b) {
		int minX = Mathf.Min(a.x, b.x);
		int maxX = Mathf.Max(a.x, b.x);
		int minY = Mathf.Min(a.y, b.y);
		int maxY = Mathf.Max(a.y, b.y);
		for (int x = minX; x <= maxX; x++) for (int y = minY; y <= maxY; y++) tm.SetTile(new Vector3Int(x, y, (int) transform.position.z), tiles[0]);
	}
}
