using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollideLevelTile: LevelTile {
	protected TilemapCollider2D tmc;
	protected Rigidbody2D rb;
	protected CompositeCollider2D cc;

	new protected void Awake() {
		base.Awake();
		tmc = gameObject.AddComponent(typeof(TilemapCollider2D)) as TilemapCollider2D;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		cc = gameObject.AddComponent(typeof(CompositeCollider2D)) as CompositeCollider2D;

		rb.bodyType = RigidbodyType2D.Static;
		tmc.usedByComposite = true;
	}
}
