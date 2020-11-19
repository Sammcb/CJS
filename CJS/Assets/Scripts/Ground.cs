using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground: TileEntity {
	new private void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Tiles/ground");
	}
}
