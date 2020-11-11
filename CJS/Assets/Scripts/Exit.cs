using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit: TileEntity {
	public UnityEvent exit;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/door");
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") exit.Invoke();
	}
}
