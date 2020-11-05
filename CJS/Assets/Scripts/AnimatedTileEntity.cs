using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTileEntity: TileEntity {
	protected Sprite[] sprites;
	protected float delay = 1;
	protected int spriteIndex = 1;

	protected IEnumerator Animate() {
		while (true) {
			spriteIndex = ++spriteIndex % sprites.Length;
			sr.sprite = sprites[spriteIndex];
			yield return new WaitForSeconds(delay);
		}
	}
}
