using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Wall: CollideLevelTile {
	new private void Awake() {
		base.Awake();
		foreach (int i in new [] {0}) {
			Tile t = ScriptableObject.CreateInstance<Tile>();
			t.sprite = allSprites[i];
			tiles.Add(t);
		}
	}

	private void Update() {
		
	}
}
