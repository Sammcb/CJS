using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Poi: RigidLevelTile {
	new private void Awake() {
		base.Awake();
		Tile t = ScriptableObject.CreateInstance<Tile>();
		t.sprite = allSprites[6];
		tile = t;
	}

	public void burn(int x, int y) {
		
	}
}
