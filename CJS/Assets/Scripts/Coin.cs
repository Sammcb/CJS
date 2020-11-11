using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: AnimatedTileEntity {
	public bool burnt = false;
	public int amount;

	new protected void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/coin");
		sr.sprite = sprites[0];
		delay = 0.7f;
		StartCoroutine(Animate());
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
		amount = 1;
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			gameObject.SetActive(false);
			level.collectedCoins += amount;
			level.world.UpdateStats();
		}
	}

	public bool Collected() {
		return !gameObject.activeSelf && !burnt;
	}

	public void Burn() {
		gameObject.SetActive(false);
		burnt = true;
	}
}
