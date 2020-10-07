using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground: LevelTile {
	new private void Awake() {
		base.Awake();
		foreach (int i in new [] {5}) {
			Tile t = ScriptableObject.CreateInstance<Tile>();
			t.sprite = allSprites[i];
			tiles.Add(t);
		}
	}
}
