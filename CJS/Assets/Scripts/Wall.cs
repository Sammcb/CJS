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

	private bool Touching(int x, int y) {
		Ground g = transform.parent.GetComponent<Level>().ground.GetComponent<Ground>();
		if (g.TileType<GroundTile>(x, y)) return false;
		for (int i = x - 1; i <= x + 1; i++) for (int n = y - 1; n <= y + 1; n++) if ((i != x || n != y) && g.TileType<GroundTile>(i, n)) return true;
		return false;
	}

	public void FillWalls() {
		Level l = transform.parent.GetComponent<Level>();
		for (int x = l.MinX(); x <= l.MaxX(); x++) for (int y = l.MinY(); y <= l.MaxY(); y++) if (Touching(x, y)) tm.SetTile(new Vector3Int(x, y, (int) transform.position.z), tiles[0]);
	}
}
