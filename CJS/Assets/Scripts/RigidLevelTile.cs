using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidLevelTile: CollideLevelTile {
	
	new protected void Awake() {
		base.Awake();
		cc.isTrigger = false;
	}
}
