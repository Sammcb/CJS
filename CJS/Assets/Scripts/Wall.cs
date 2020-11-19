using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;

public class Wall: TileEntity {
	private Rigidbody2D rb;
	private ShadowCaster2D sc;

	new private void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Tiles/wall");
		c = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		sc = gameObject.AddComponent(typeof(ShadowCaster2D)) as ShadowCaster2D;
		gameObject.tag = "Wall";
		gameObject.layer = LayerMask.NameToLayer("Wall");
	}
}
