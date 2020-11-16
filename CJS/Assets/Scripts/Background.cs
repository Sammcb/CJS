using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background: MonoBehaviour {
	public Camera cam;

	private void Awake() {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		float camHeight = cam.orthographicSize * 2;
		Vector2 camSize = new Vector2(cam.aspect * camHeight, camHeight);
		Vector2 srSize = sr.sprite.bounds.size;
		Vector2 scale = transform.localScale;
		scale *= camSize.x >= camSize.y ? camSize.x / srSize.x : camSize.y / srSize.y;
		transform.localScale = scale;
	}
}
