using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallTile: Tile {}

public class Wall: RigidLevelTile {
	new private void Awake() {
		base.Awake();
		WallTile t = ScriptableObject.CreateInstance<WallTile>();
		t.sprite = Resources.Load<Sprite>("Tiles/wall");
		tile = t;
		gameObject.tag = "Wall";
		gameObject.layer = LayerMask.NameToLayer("Wall");
	}

	private bool Touching(int x, int y) {
		Ground g = transform.parent.GetComponent<Level>().ground.GetComponent<Ground>();
		if (g.TileType<GroundTile>(x, y)) return false;
		for (int i = x - 1; i <= x + 1; i++) for (int n = y - 1; n <= y + 1; n++) if ((i != x || n != y) && g.TileType<GroundTile>(i, n)) return true;
		return false;
	}

	public void FillWalls() {
		BoundsInt b = tm.cellBounds;
		for (int x = b.min.x; x <= b.max.x; x++) for (int y = b.min.y; y <= b.max.y; y++) if (Touching(x, y)) tm.SetTile(new Vector3Int(x, y, IntZ()), tile);
	}
}
