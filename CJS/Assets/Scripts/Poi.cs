using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PoiTile: Tile {
}

public class Poi: CollideLevelTile {
	new private void Awake() {
		base.Awake();
		PoiTile t = ScriptableObject.CreateInstance<PoiTile>();
		t.sprite = allSprites[6];
		tile = t;
	}
}
