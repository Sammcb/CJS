using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ashes: TileEntity {
	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/ashes");
	}
}
