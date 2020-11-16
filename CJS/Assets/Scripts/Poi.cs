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

	public bool Saved() {
		return gameObject.activeSelf;
	}

	public void Burn() {
		gameObject.SetActive(false);
		BurnParticle emitter = new GameObject("Emitter", typeof(BurnParticle)).GetComponent<BurnParticle>();
		emitter.transform.SetParent(level.transform);
		emitter.SetPos(new Vector3(transform.position.x, transform.position.y, z - 1));
	}
}
