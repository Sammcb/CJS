using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class House: CollideLevelTile {

    #region VARIABLES
    private bool active = true;
    #endregion

    new private void Awake() {
        base.Awake();
        foreach (int i in new [] {2, 3}) {
            Tile t = ScriptableObject.CreateInstance<Tile>();
            t.sprite = allSprites[i];
            tiles.Add(t);
        }
    }

    // called when fire touches it
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.rigidbody.name != "Player") {
          Debug.Log("A house has been burned down!");
          active = false;
      }
    }

}
