﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball: AnimatedTileEntity {
	public Vector3 end;
	private Rigidbody2D rb;
	private float size = 0.5f;
	private float speed = 3;
	private float splash = 0.75f;
	private float fireZ = 1;

	private AudioClip snowballSfx;
	private AudioSource source;

	new private void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/snowball");
		sr.sprite = sprites[0];
		delay = 0.3f;
		StartCoroutine(Animate());
		transform.localScale = Vector3.one * size;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		c = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
		gameObject.layer = LayerMask.NameToLayer("Snowball");
		gameObject.tag = "Snowball";
		SnowballParticle emitter = new GameObject("Emitter", typeof(SnowballParticle)).GetComponent<SnowballParticle>();
		emitter.transform.SetParent(transform);
		emitter.SetPos(new Vector3(transform.position.x, transform.position.y, z - 1));

		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		snowballSfx = Resources.Load<AudioClip>("SoundEffects/snowballSFX");
	}

	private void Update() {
		if (Vector3.Distance(transform.position, end) < 0.5f) Destroy(gameObject);
		transform.Translate(Vector3.Normalize(end - transform.position) * Time.deltaTime * speed);
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Fire") {
			source.PlayOneShot(snowballSfx);
			List<Collider2D> cols = new List<Collider2D>();
			ContactFilter2D filter = new ContactFilter2D();
			filter.SetDepth(fireZ, fireZ);
			Physics2D.OverlapCircle(transform.position, splash, filter, cols);
			foreach (Collider2D c in cols) {
				DouseParticle emitter = new GameObject("Emitter", typeof(DouseParticle)).GetComponent<DouseParticle>();
				emitter.transform.SetParent(level.transform);
				emitter.SetPos(new Vector3(c.transform.position.x, c.transform.position.y, z - 1));
				Destroy(c.gameObject);
			}
		}
		Destroy(gameObject);
	}
}
