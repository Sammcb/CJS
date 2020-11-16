using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit: TileEntity {
	public UnityEvent exit;
	private AudioClip levelFinishSfx;
	private AudioSource source;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/exit");
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;

		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		levelFinishSfx = Resources.Load<AudioClip>("SoundEffects/levelFinishSfx");
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			source.PlayOneShot(levelFinishSfx);
			exit.Invoke();
		}
	}
}
