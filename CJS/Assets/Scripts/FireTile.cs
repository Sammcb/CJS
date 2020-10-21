using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FireTile: Tile {
	public Sprite[] sprites;
	public float animationSpeed = 1;
	public float animationStartTime = 0;

	public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData) {
		if (sprites != null && sprites.Length > 0) tileData.sprite = sprites[0];
	}

	public override bool GetTileAnimationData(Vector3Int location, ITilemap tileMap, ref TileAnimationData tileAnimationData) {
		if (sprites == null || sprites.Length <= 0) return false;
		tileAnimationData.animatedSprites = sprites;
		tileAnimationData.animationSpeed = animationSpeed;
		tileAnimationData.animationStartTime = animationStartTime;
		return true;
	}
}
