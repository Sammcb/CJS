using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Princess: AnimatedTileEntity {
	public UnityEvent exit;
	public Player player;
	private bool paused = false;

	new protected void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/princess");
		sr.sprite = sprites[0];
		delay = 5;
		StartCoroutine(Animate());
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		c.isTrigger = true;
		PrincessParticle emitter = new GameObject("Emitter", typeof(PrincessParticle)).GetComponent<PrincessParticle>();
		emitter.transform.SetParent(transform);
		emitter.SetPos(new Vector3(transform.position.x, transform.position.y, z - 1));
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			exit.Invoke();
		}
	}

	new protected IEnumerator Animate() {
		while (true) {
			spriteIndex = ++spriteIndex % sprites.Length;
			sr.sprite = sprites[spriteIndex];
			if (spriteIndex == 1) {
				yield return new WaitForSeconds(0.2f);
				continue;
			}
			yield return new WaitForSeconds(delay);
		}
	}

	private void Update() {
		if (Input.GetButtonDown("Cancel")) paused = !paused;
		if (paused) return;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
	}
}
