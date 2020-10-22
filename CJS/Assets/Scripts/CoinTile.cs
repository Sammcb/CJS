using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinTile: Tile {
    public Sprite[] sprites;

    public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData) {
        if (sprites != null && sprites.Length > 0) tileData.sprite = sprites[0];
    }

}
