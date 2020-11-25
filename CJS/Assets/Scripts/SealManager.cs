using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SealManager: TileEntityManager<Seal> {
	public Player player;

	public SealManager(Level level, string tileName, int z, Player player): base(level, tileName, z) {
		this.player = player;
	}

	public void SetPlayer() {
		foreach (Seal seal in objects) seal.player = player;
	}
}
