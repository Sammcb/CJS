using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildLevel: MonoBehaviour {
	public UnityEvent levelToShop;
	public UnityEvent nextLevel;
	private GameObject level;
	public GameObject player;
	private GameObject cam;
	private int levelNum = 0; //change this for testing different levels
	public GameObject world;
	public GameObject shop;

	private void Awake() {
		levelToShop = new UnityEvent();
		nextLevel = new UnityEvent();
		levelToShop.AddListener(LevelToShop);
		nextLevel.AddListener(NextLevel);
		transform.position = Vector3.zero;

		player = new GameObject("Player", typeof(Player));
		player.transform.SetParent(transform);
		player.SetActive(false);

		cam = new GameObject("Camera", typeof(Camera), typeof(AudioListener), typeof(PlayerCamera));
		cam.transform.position = Vector3.forward * -10;
		cam.tag = "MainCamera";
		cam.GetComponent<PlayerCamera>().target = player;
		Camera c = cam.GetComponent<Camera>();
		c.orthographic = true;
		c.orthographicSize = 8;
		c.depth = -1;

		InitLevel();
	}

	private void InitLevel() {
		level = new GameObject("Level", typeof(Level));
		level.transform.SetParent(transform);
		Level l = level.GetComponent<Level>();
		l.player = player;
		l.nextLevel = levelToShop;
		player.GetComponent<Player>().levelCoins = 0;
		player.GetComponent<Player>().UpdateText();
		player.GetComponent<Player>().UpdateText();
		l.Init(levelNum);
	}

	private void LevelToShop() {
		Level l = level.GetComponent<Level>();
		player.SetActive(false);
		Player p = player.GetComponent<Player>();
		foreach (Coin coin in l.coins.objects) if (coin.Collected()) p.coins += coin.amount;
		Debug.Log("Player coins =  " + p.coins);
		foreach (Poi poi in l.pois.objects) if (poi.Saved()) p.coins += poi.amount;
		Destroy(level);

		level.SetActive(false);
		shop.SetActive(true);

	}

	private void NextLevel() {
		Debug.Log("Loading level: " + ++levelNum);
		Debug.Log("Player coins: " + player.GetComponent<Player>().coins);
		
		shop.SetActive(false);

		InitLevel();
	}
}
