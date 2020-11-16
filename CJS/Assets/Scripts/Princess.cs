using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess: Exit {
	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/princess");
	}
}
