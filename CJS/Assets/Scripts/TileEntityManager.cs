using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEntityManager<T> where T: TileEntity {
	public Level level;
	public string tileName;
	public int z;
	public List<Vector2Int> tiles = new List<Vector2Int>();
	public List<T> objects = new List<T>();
	public Vector2Int size = new Vector2Int(1, 1);
	protected GameObject parent;

	public TileEntityManager(Level level, string tileName, int z) {
		this.level = level;
		this.tileName = tileName;
		this.z = z;
		parent = new GameObject(tileName + "s");
		parent.transform.SetParent(level.transform);
		parent.transform.localPosition = Vector3.zero;
	}

	public void SetTile(Vector2Int pos) {
		GameObject o = new GameObject(tileName, typeof(T));
		T te = o.GetComponent<T>();
		te.transform.SetParent(parent.transform);
		te.transform.localPosition = Vector3.forward * z;
		te.z = z;
		if (te.GetType() == typeof(Poi)) {
			Poi p = te.GetComponent<Poi>();
			p.SetPos(pos);
		} else {
			te.SetPos(pos);
		}
		for (int i = 0; i < size.x; i++) for (int n = 0; n < size.y; n++) {
			tiles.Add(new Vector2Int(pos.x + i, pos.y + n));
			objects.Add(te);
		}
	}

	public void FillTiles(Vector2Int a, Vector2Int b) {
		for (int x = Mathf.Min(a.x, b.x); x <= Mathf.Max(a.x, b.x); x++) for (int y = Mathf.Min(a.y, b.y); y <= Mathf.Max(a.y, b.y); y++) SetTile(new Vector2Int(x, y));
	}

	public T Tile(Vector2Int pos) {
		return objects[tiles.IndexOf(pos)];
	}
}
