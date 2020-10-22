using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: TileEntity {
	public int coins = 0;
	private Rigidbody2D rb;
	private float range = 2;
	private float moveSpeed = 3;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/Circle");
		c = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		gameObject.tag = "Player";
	}

	private void Update() {
		// Movement
		Vector3 movement = (Vector3.up * Input.GetAxis("Vertical")) + (Vector3.right * Input.GetAxis("Horizontal"));
		transform.Translate(Vector3.Normalize(movement) * Time.deltaTime * moveSpeed);

		// Fire hose
		if(Input.GetMouseButtonDown(0)) {
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mouse.z = 0;
			Vector3 direction = Vector3.Normalize(mouse-transform.position) * range;
			Debug.DrawRay(transform.position, direction, Color.white, 5);
		}

	}

}
