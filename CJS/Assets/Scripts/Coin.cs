using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: AnimatedTileEntity {
	public bool burnt = false;
	public int amount;
	private AudioClip coinsSfx;
	private AudioSource source;

	new protected void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/coin");
		sr.sprite = sprites[0];
		delay = 0.7f;
		StartCoroutine(Animate());
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
		amount = 1;
		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		coinsSfx = Resources.Load<AudioClip>("SoundEffects/coinsSFX");
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			source.PlayOneShot(coinsSfx);
			gameObject.SetActive(false);
			level.collectedCoins += amount;
			level.world.coins += amount;
			level.world.UpdateStats();
		}
	}

	public bool Collected() {
		return !gameObject.activeSelf && !burnt;
	}

	public void Burn() {
		gameObject.SetActive(false);
		burnt = true;
		BurnParticle emitter = new GameObject("Emitter", typeof(BurnParticle)).GetComponent<BurnParticle>();
		emitter.transform.SetParent(level.transform);
		emitter.SetPos(new Vector3(transform.position.x, transform.position.y, z - 1));
	}
}
