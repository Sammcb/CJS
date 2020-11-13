using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn: TileEntity {
	new protected void Start() {
		base.Start();
		sr.sprite = Resources.LoadAll<Sprite>("Sprites/hole")[3];
	}

	public void SpawnPlayer(Player player) {
		player.SetPos(new Vector2Int((int) transform.position.x, (int) transform.position.y));
	}
}
