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

	protected int IntZ() {
		return (int) transform.position.z;
	}

	public void FillTiles(Vector2Int a, Vector2Int b) {
		int minX = Mathf.Min(a.x, b.x);
		int maxX = Mathf.Max(a.x, b.x);
		int minY = Mathf.Min(a.y, b.y);
		int maxY = Mathf.Max(a.y, b.y);
		Level l = transform.parent.GetComponent<Level>();
		if (!l.InBounds(a, b)) return;
		for (int x = minX; x <= maxX; x++) for (int y = minY; y <= maxY; y++) tm.SetTile(new Vector3Int(x, y, IntZ()), tiles[0]);
	}

	public bool TileType<T>(int x, int y) {
		TileBase t = tm.GetTile(new Vector3Int(x, y, IntZ()));
		if (t == null) return false;
		return t.GetType() == typeof(T);
	}
}
