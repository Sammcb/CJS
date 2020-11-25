using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal: AnimatedTileEntity {
	public bool burnt = false;
	public Player player;
	private AudioClip coinsSfx;
	private AudioSource source;
	private bool paused = false;

	new protected void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/princess");
		sr.sprite = sprites[0];
		delay = 0.7f;
		StartCoroutine(Animate());
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		coinsSfx = Resources.Load<AudioClip>("SoundEffects/coinsSFX");
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			source.PlayOneShot(coinsSfx);
			gameObject.SetActive(false);
			level.savedSeals++;
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

	private void Update() {
		if (Input.GetButtonDown("Cancel")) paused = !paused;
		if (paused) return;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
	}
}
