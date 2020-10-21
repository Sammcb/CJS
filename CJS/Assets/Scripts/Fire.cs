using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire: CollideLevelTile {
	new private void Awake() {
		base.Awake();
		FireTile t = ScriptableObject.CreateInstance<FireTile>();
		t.sprites = new[] {allSprites[1], allSprites[2]};
		tiles.Add(t);
	}
}
