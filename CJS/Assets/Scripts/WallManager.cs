using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WallManager: TileEntityManager<Wall> {
	public TileEntityManager<Ground> grounds;
	private CompositeShadowCaster2D csc;

	public WallManager(Level level, string tileName, int z, TileEntityManager<Ground> grounds): base(level, tileName, z) {
		this.grounds = grounds;
		csc = parent.AddComponent(typeof(CompositeShadowCaster2D)) as CompositeShadowCaster2D;
	}

	private bool Touching(int x, int y) {
		if (grounds.tiles.Contains(new Vector2Int(x, y))) return false;
		for (int i = x - 1; i <= x + 1; i++) for (int n = y - 1; n <= y + 1; n++) if ((i != x || n != y) && grounds.tiles.Contains(new Vector2Int(i, n))) return true;
		return false;
	}

	public void FillWalls() {
		for (int x = level.min.x; x < level.max.x; x++) for (int y = level.min.y; y <= level.max.y; y++) if (Touching(x, y)) SetTile(new Vector2Int(x, y));
	}
}
