using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: TileEntity {
	public bool collected = false;
	public int value = 0;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.LoadAll<Sprite>("Tiles/Hell")[3];
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") gameObject.SetActive(false);
	}
}
