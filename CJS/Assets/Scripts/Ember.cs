using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ember: TileEntity {
	new private void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/ember");
		gameObject.tag = "Ember";
		StartCoroutine(Grow());
	}

	IEnumerator Grow() {
		yield return new WaitForSeconds(2);
		level.fires.SetTile(position);
		Destroy(gameObject);
	}
}
