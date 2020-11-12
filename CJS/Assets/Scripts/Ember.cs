using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ember: TileEntity {
	new private void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/ember");
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
		gameObject.tag = "Ember";
		StartCoroutine(Grow());
	}

	IEnumerator Grow() {
		yield return new WaitForSeconds(2);
		level.fires.SetTile(position);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Snowball") Destroy(gameObject);
	}
}
