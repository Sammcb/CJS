using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class World: MonoBehaviour {
	public UnityEvent toShop;
	public UnityEvent nextLevel;
	public UnityEvent die;
	private Level level;
	private Camera cam;
	private Light2D globeLight;
	public int levelNum = 0;
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

		globeLight = new GameObject("GlobalLight", typeof(Light2D)).GetComponent<Light2D>();
		globeLight.transform.SetParent(transform);
		globeLight.transform.position = Vector3.zero;
		globeLight.lightType = Light2D.LightType.Global;
		globeLight.intensity = 0.2f;
		globeLight.color = new Color(0.59f, 0.99f, 1);

		cam = new GameObject("Camera", typeof(Camera), typeof(AudioListener), typeof(PlayerCamera)).GetComponent<Camera>();
		cam.transform.SetParent(transform);
		cam.transform.position = Vector3.forward * -10;
		cam.tag = "MainCamera";
		cam.orthographic = true;
		cam.orthographicSize = 8;
		cam.depth = -1;
		cam.clearFlags = CameraClearFlags.Nothing;
		cam.cullingMask = 0b_0000_0000_0000_0000_0000_0111_1111_1111;

		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		dieSfx = Resources.Load<AudioClip>("SoundEffects/dieSFX");
		levelStartSfx = Resources.Load<AudioClip>("SoundEffects/levelStartSfx");

		InitLevel();
	}

	private void InitLevel() {
		level = new GameObject("Level", typeof(Level)).GetComponent<Level>();
		level.transform.SetParent(transform);
		level.baseZ = baseZ;
		level.maxLevel = maxLevel;
		level.toShop = toShop;
		level.pause = pause;
		level.world = this;
		UpdateStats();
		level.Init(levelNum);
	}

	private void ToShop() {
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
		coins -= level.collectedCoins;
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
