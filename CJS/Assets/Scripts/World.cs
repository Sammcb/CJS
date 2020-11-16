using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class World: MonoBehaviour {
	public UnityEvent toShop;
	public UnityEvent nextLevel;
	public UnityEvent die;
	private Level level;
	private Camera cam;
	private int levelNum = 11;
	private int maxLevel = 11;
	private int baseZ = 3;
	public GameObject shopParentMenu;
	public GameObject shopChildMenu;
	public GameObject stats;
	public GameObject pause;

	public int coins = 0;
	public int lives = 3;
	public float speed = 3;
	public float range = 3;

	private AudioClip dieSfx;
	private AudioClip levelStartSfx;

	private AudioSource source;

	private void Awake() {
		toShop = new UnityEvent();
		nextLevel = new UnityEvent();
		die = new UnityEvent();
		toShop.AddListener(ToShop);
		nextLevel.AddListener(NextLevel);
		die.AddListener(Die);

		transform.position = Vector3.zero;

		cam = new GameObject("Camera", typeof(Camera), typeof(AudioListener), typeof(PlayerCamera)).GetComponent<Camera>();
		cam.transform.position = Vector3.forward * -10;
		cam.tag = "MainCamera";
		cam.orthographic = true;
		cam.orthographicSize = 8;
		cam.depth = -1;
		cam.backgroundColor = Color.black;

		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		dieSfx = Resources.Load<AudioClip>("SoundEffects/dieSFX");
		levelStartSfx = Resources.Load<AudioClip>("SoundEffects/levelStartSfx");

		InitLevel();
	}

	private void InitLevel() {
		level = new GameObject("Level", typeof(Level)).GetComponent<Level>();
		level.transform.SetParent(transform);
		level.baseZ = baseZ;
		level.toShop = toShop;
		level.pause = pause;
		level.world = this;
		UpdateStats();
		level.Init(levelNum);
	}

	private void ToShop() {
		coins += level.collectedCoins;
		foreach (Poi poi in level.pois.objects) if (poi.Saved()) coins += poi.amount;
		UpdateStats();
		Destroy(level.gameObject);
		if (levelNum == maxLevel) {
			Win();
			return;
		}
		shopParentMenu.SetActive(true);
		shopChildMenu.GetComponent<ShopMenu>().UpdateShop();
	}

	private void NextLevel() {
		source.PlayOneShot(levelStartSfx);

		levelNum++;
		shopParentMenu.SetActive(false);
		InitLevel();
	}

	private void Die() {
		source.PlayOneShot(dieSfx);

		lives--;
		Destroy(level.gameObject);
		if (lives < 0) {
			Lose();
			return;
		}
		InitLevel();
	}

	private void Clean() {
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

	public Player BuildPlayer() {
		Player p = new GameObject("Player", typeof(Player)).GetComponent<Player>();
		p.transform.SetParent(level.transform);
		p.z = level.baseZ - 3;
		p.coins = coins;
		p.lives = lives;
		p.die = die;
		p.speed = speed;
		p.range = range;
		cam.GetComponent<PlayerCamera>().target = p;
		return p;
	}

	public void UpdateStats() {
		StatsDisplay coinsText = GameObject.Find("Coins").GetComponent<StatsDisplay>();
		StatsDisplay livesText = GameObject.Find("Lives").GetComponent<StatsDisplay>();
		coinsText.UpdateText(coins);
		livesText.UpdateText(lives);
	}
}
