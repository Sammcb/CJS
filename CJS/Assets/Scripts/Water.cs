using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water: MonoBehaviour {
	public Vector3 end;
	private SpriteRenderer sr;
	private Rigidbody2D rb;
	private CircleCollider2D cc;
	private float speed = 3;

	private void Start() {
		sr = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
		sr.sprite = Resources.Load<Sprite>("Sprites/Circle");
		sr.color = Color.blue;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		cc = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
		gameObject.layer = LayerMask.NameToLayer("Water");
	}

	private void Update() {
		if (Vector3.Distance(transform.position, end) < 0.5f) Destroy(gameObject);
		transform.Translate(Vector3.Normalize(end - transform.position) * Time.deltaTime * speed);
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Fire") Debug.Log("fire");
		Destroy(gameObject);
	}
}
