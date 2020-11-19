using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background: TileEntity {
	public Camera cam;

	new private void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/background");
		sr.drawMode = SpriteDrawMode.Tiled;
		sr.size = new Vector2(200, 200);
	}

	private void Awake() {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
	}
}
