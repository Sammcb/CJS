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
        foreach (int i in new [] {2, 3}) {
            Tile t = ScriptableObject.CreateInstance<Tile>();
            t.sprite = allSprites[i];
            tiles.Add(t);
        }
    }

    // called when the player picks up the coin
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.rigidbody.name == "Player") {
          Debug.Log("A coin has been picked up!");
          collected = true;
      }
    }

}
