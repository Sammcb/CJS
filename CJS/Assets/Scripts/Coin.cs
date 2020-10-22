using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coin: CollideLevelTile {

    #region VARIABLES
    private bool collected = false;
    #endregion

    new private void Awake() {
      base.Awake();
      Tile t = ScriptableObject.CreateInstance<Tile>();
      t.sprite = allSprites[3];
      tiles.Add(t);
    }

    // called when the player picks up the coin
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.rigidbody.name == "Player") {
          Debug.Log("A coin has been picked up!");
          collected = true;
          Vector3 pos = transform.position;
          Tile groundTile = ScriptableObject.CreateInstance<Tile>();
          groundTile.sprite = allSprites[4];
          tm.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), groundTile);
          //TileBase t = tm.GetTile(new Vector3Int((int)pos.x, (int)pos.y, 0));
          //t = null;
      }
    }

}
