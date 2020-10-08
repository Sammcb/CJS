using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire: CollideLevelTile {
	new private void Awake() {
		base.Awake();
		foreach (int i in new [] {1, 2}) {
			Tile t = ScriptableObject.CreateInstance<Tile>();
			t.sprite = allSprites[i];
			tiles.Add(t);
		}
	}

	private void Update() {
		
	}
}
