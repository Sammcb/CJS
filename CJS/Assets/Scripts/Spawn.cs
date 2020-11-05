using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn: TileEntity {
	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Tiles/ground");
	}

	public void SpawnPlayer(GameObject player) {
		player.SetActive(true);
		player.GetComponent<Player>().SetPos(new Vector2Int((int) transform.position.x, (int) transform.position.y));
	}
}
