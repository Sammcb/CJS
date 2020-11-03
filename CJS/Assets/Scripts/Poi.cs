using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poi: TileEntity {
	public int amount;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.LoadAll<Sprite>("Tiles/Hell")[6];
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		//amount = UnityEngine.Random.Range(20, 30);
		amount = 2;
	}

	public bool Saved() {
		return gameObject.activeSelf;
	}

	public void Burn() {
		gameObject.SetActive(false);
	}
}
