using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEntity: MonoBehaviour {
	protected SpriteRenderer sr;
	protected Collider2D c;
	public int z;

	protected void Start() {
		sr = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
	}

	public void SetPos(Vector2Int pos) {
		transform.localPosition = new Vector3(pos.x + 0.5f, pos.y + 0.5f, z);
	}

	// public static void FillTiles<T>(Vector2Int a, Vector2Int b, Transform parent) {
	// 	for (int x = Mathf.Min(a.x, b.x); x <= Mathf.Max(a.x, b.x); x++) for (int y = Mathf.Min(a.y, b.y); y <= Mathf.Max(a.y, b.y); y++) {
	// 		GameObject o = new GameObject("", typeof(T));
	// 		TileEntity te = o.GetComponent<TileEntity>();
	// 		te.name = te.tileName;
	// 		te.transform.SetParent(parent);
	// 		te.transform.localPosition = Vector3.forward * te.z;
	// 		te.SetPos(new Vector2Int(x, y));
	// 	}
	// }

	// public bool TileType<T>(int x, int y) {
	// 	TileBase t = tm.GetTile(new Vector3Int(x, y, IntZ()));
	// 	if (t == null) return false;
	// 	return t.GetType() == typeof(T);
	// }

	// coin = new GameObject("Coin", typeof(Coin));
	// coin.transform.SetParent(transform);
	// coin.transform.localPosition = Vector3.forward * coinZ;
	// coin.GetComponent<Coin>().SetPos(new Vector2Int(1, 1));
}
