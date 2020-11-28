using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal: TileEntity {
	public bool burnt = false;
	private AudioClip sealSfx;
	private AudioSource source;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/seal");
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		sealSfx = Resources.Load<AudioClip>("SoundEffects/sealSFX");
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			source.PlayOneShot(sealSfx);
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
}
