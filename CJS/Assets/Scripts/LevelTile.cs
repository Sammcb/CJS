using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelTile: MonoBehaviour {
	protected Tilemap tm;
	protected TilemapRenderer tmr;
	protected Tile tile;
	protected Sprite[] allSprites;

	protected void Awake() {
		allSprites = Resources.LoadAll<Sprite>("Tiles/Hell");
		tm = gameObject.AddComponent(typeof(Tilemap)) as Tilemap;
		tmr = gameObject.AddComponent(typeof(TilemapRenderer)) as TilemapRenderer;
		tm.size = new Vector3Int(20, 20, 0);
	}

	protected int IntZ() {
		return (int) transform.position.z;
	}

	public void FillTiles(Vector2Int a, Vector2Int b) {
		tm.BoxFill(new Vector3Int(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y), IntZ()), tile, Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y), Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y));
	}

	public bool TileType<T>(int x, int y) {
		TileBase t = tm.GetTile(new Vector3Int(x, y, IntZ()));
		if (t == null) return false;
		return t.GetType() == typeof(T);
	}
}
