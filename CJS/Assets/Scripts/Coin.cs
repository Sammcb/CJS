using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: TileEntity {
	public bool burnt = false;
	public int amount;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.LoadAll<Sprite>("Tiles/Hell")[3];
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
		//amount = UnityEngine.Random.Range(5, 10);
		amount = 1;
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") gameObject.SetActive(false);
		Debug.Log("Coin picked up!");
	}

	public bool Collected() {
		return !gameObject.activeSelf && !burnt;
	}

	public void Burn() {
		gameObject.SetActive(false);
		burnt = true;
	}
}
