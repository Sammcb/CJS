using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit: TileEntity {
	new protected void Start() {
		base.Start();
		sr.sprite = Resources.LoadAll<Sprite>("Tiles/Hell")[13];
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") col.gameObject.SetActive(false);
	}
}
