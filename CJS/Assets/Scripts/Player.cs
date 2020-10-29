using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: TileEntity {
	public int coins = 0;
	private Rigidbody2D rb;
	private float range = 10;
	private float speed = 3;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/Circle");
		c = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		gameObject.tag = "Player";
		gameObject.layer = LayerMask.NameToLayer("Player");
	}

	private void Update() {
		Vector3 move = Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
		transform.Translate(Vector3.Normalize(move) * Time.deltaTime * speed);

		if(Input.GetMouseButtonDown(0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 dir = pos - transform.position;
			dir.z = 0;
			GameObject water = new GameObject("Water", typeof(Water));
			water.transform.position = transform.position;
			water.GetComponent<Water>().end = transform.position + Vector3.Normalize(dir) * range;
		}

	}

}
