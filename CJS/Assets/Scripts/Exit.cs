using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit: TileEntity {
	public UnityEvent toShop;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.LoadAll<Sprite>("Tiles/Hell")[13];
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
		toShop = transform.parent.GetComponent<Level>().toShop;
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") toShop.Invoke();
	}
}
