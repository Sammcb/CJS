using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BuildLevel: MonoBehaviour {
	public UnityEvent toShop;
	public UnityEvent nextLevel;
	public UnityEvent die;
	private GameObject level;
	public GameObject player;
	private GameObject cam;
	private int levelNum = 3; //change this for testing different levels
	private int maxLevel = 5;
	public GameObject shopParentMenu;
	public GameObject shopChildMenu;

	private void Awake() {
		toShop = new UnityEvent();
		nextLevel = new UnityEvent();
		die = new UnityEvent();
		toShop.AddListener(ToShop);
		nextLevel.AddListener(NextLevel);
		die.AddListener(Die);

		transform.position = Vector3.zero;

		player = new GameObject("Player", typeof(Player));
		player.transform.SetParent(transform);
		Player p = player.GetComponent<Player>();
		p.z = 0;
		p.die = die;
		player.SetActive(false);

		cam = new GameObject("Camera", typeof(Camera), typeof(AudioListener), typeof(PlayerCamera));
		cam.transform.position = Vector3.forward * -10;
		cam.tag = "MainCamera";
		cam.GetComponent<PlayerCamera>().target = player;
		Camera c = cam.GetComponent<Camera>();
		c.orthographic = true;
		c.orthographicSize = 8;
		c.depth = -1;
		c.backgroundColor = Color.black;

		InitLevel();
	}

	private void InitLevel() {
		level = new GameObject("Level", typeof(Level));
		level.transform.SetParent(transform);
		Level l = level.GetComponent<Level>();
		l.player = player;
		l.toShop = toShop;
		player.GetComponent<Player>().levelCoins = 0;
		player.GetComponent<Player>().UpdateText();
		l.Init(levelNum);
	}

	private void ToShop() {
		Level l = level.GetComponent<Level>();
		player.SetActive(false);
		Player p = player.GetComponent<Player>();
		foreach (Coin coin in l.coins.objects) if (coin.Collected()) p.coins += coin.amount;
		foreach (Poi poi in l.pois.objects) if (poi.Saved()) p.coins += poi.amount;
		player.GetComponent<Player>().UpdateText();
		Destroy(level);
		if (levelNum == maxLevel) {
			Win();
			return;
		}
		shopParentMenu.SetActive(true);
		shopChildMenu.GetComponent<ShopMenu>().UpdateShop();
	}

	private void NextLevel() {
		levelNum++;
		shopParentMenu.SetActive(false);
		InitLevel();
	}

	private void Die() {
		Player p = player.GetComponent<Player>();
		p.lives--;
		p.UpdateText();
		Destroy(level);
		if (p.lives < 0) {
			Lose();
			return;
		}
		InitLevel();
	}

	private void Clean() {
		Destroy(player);
		Destroy(cam);
	}

	private void Win() {
		Clean();
		SceneManager.LoadScene("Win");
	}

	private void Lose() {
		Clean();
		SceneManager.LoadScene("Game Over");
	}
}
