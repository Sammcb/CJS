using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildLevel: MonoBehaviour {
	private UnityEvent nextLevel;
	private GameObject level;
	private GameObject player;
	private GameObject cam;
	private int levelNum = 0;

	private void Start() {
		nextLevel = new UnityEvent();
		nextLevel.AddListener(NextLevel);
		transform.position = Vector3.zero;

		player = new GameObject("Player", typeof(Player));
		player.transform.SetParent(transform.parent);

		level = new GameObject("Level", typeof(Level));
		level.transform.SetParent(transform);
		Level l = level.GetComponent<Level>();
		l.player = player;
		l.nextLevel = nextLevel;

		cam = new GameObject("Camera", typeof(Camera), typeof(AudioListener), typeof(PlayerCamera));
		cam.transform.position = Vector3.forward * -10;
		cam.tag = "MainCamera";
		cam.GetComponent<PlayerCamera>().target = player;
		Camera c = cam.GetComponent<Camera>();
		c.orthographic = true;
		c.orthographicSize = 8;
		c.depth = -1;
	}

	private void NextLevel() {
		Level l = level.GetComponent<Level>();
		player.SetActive(false);
		Player p = player.GetComponent<Player>();
		foreach (Coin coin in l.coins.objects) if (coin.Collected()) p.coins += coin.amount;
		foreach (Poi poi in l.pois.objects) if (poi.Saved()) p.coins += poi.amount;
		Destroy(level);

		Debug.Log("Loading level: " + ++levelNum);
		Debug.Log("Player coins: " + player.GetComponent<Player>().coins);
	}
}
