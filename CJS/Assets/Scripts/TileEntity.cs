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
}
