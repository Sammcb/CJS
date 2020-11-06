using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poi: TileEntity {
	public int amount;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/poi");
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		amount = 1;
	}

	new public void SetPos(Vector2Int pos) {
		transform.localPosition = new Vector3(pos.x + 1, pos.y + 0.5f, z);
		position = pos;
	}

	public bool Saved() {
		return gameObject.activeSelf;
	}

	public void Burn() {
		gameObject.SetActive(false);
	}
}
