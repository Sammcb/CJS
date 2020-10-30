using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEntityManager<T> where T: TileEntity {
	public GameObject l;
	public string tileName;
	public int z;
	public List<Vector2Int> tiles = new List<Vector2Int>();
	public List<T> objects = new List<T>();

	public void SetTile(Vector2Int pos) {
		GameObject o = new GameObject(tileName, typeof(T));
		T te = o.GetComponent<T>();
		te.transform.SetParent(l.transform);
		te.transform.localPosition = Vector3.forward * z;
		te.z = z;
		te.SetPos(pos);
		tiles.Add(pos);
		objects.Add(te);
	}

	public void FillTiles(Vector2Int a, Vector2Int b) {
		for (int x = Mathf.Min(a.x, b.x); x <= Mathf.Max(a.x, b.x); x++) for (int y = Mathf.Min(a.y, b.y); y <= Mathf.Max(a.y, b.y); y++) SetTile(new Vector2Int(x, y));
	}

	public T Tile(Vector2Int pos) {
		return objects[tiles.IndexOf(pos)];
	}
}
