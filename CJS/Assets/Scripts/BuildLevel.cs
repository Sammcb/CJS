using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildLevel: MonoBehaviour {
	private GameObject level;

	private void Start() {
		transform.position = Vector3.zero;

		level = new GameObject("Level", typeof(Level));
		level.transform.SetParent(transform);
	}
}
