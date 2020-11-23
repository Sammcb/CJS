using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background: AnimatedTileEntity {
	public Camera cam;

	new private void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/background");
		sr.sprite = sprites[0];
		sr.drawMode = SpriteDrawMode.Tiled;
		sr.size = new Vector2(200, 200);
		StartCoroutine(Animate());
	}
}
