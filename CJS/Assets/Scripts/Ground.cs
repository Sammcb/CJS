using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundTile: Tile {}

public class Ground: LevelTile {
	new private void Awake() {
		base.Awake();
		GroundTile t = ScriptableObject.CreateInstance<GroundTile>();
		t.sprite = Resources.Load<Sprite>("Tiles/ground");
		tile = t;
	}
}
