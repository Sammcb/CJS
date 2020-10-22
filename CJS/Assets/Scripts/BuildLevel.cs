using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildLevel: MonoBehaviour {
	private GameObject level;
	private GameObject player;
	private GameObject cam;

	private void Start() {
		transform.position = Vector3.zero;

		level = new GameObject("Level", typeof(Level));
		level.transform.SetParent(transform);

		player = new GameObject("Player", typeof(Player));
		player.transform.SetParent(transform);
		player.GetComponent<Player>().SetPos(new Vector2Int(2, 3));

		cam = new GameObject("Camera", typeof(Camera), typeof(AudioListener), typeof(PlayerCamera));
		cam.transform.position = Vector3.forward * -10;
		cam.tag = "MainCamera";
		cam.GetComponent<PlayerCamera>().target = player;
		Camera c = cam.GetComponent<Camera>();
		c.orthographic = true;
		c.orthographicSize = 8;
		c.depth = -1;
	}
}
