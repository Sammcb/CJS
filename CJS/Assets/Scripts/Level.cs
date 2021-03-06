﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

public class Level: MonoBehaviour {
	public World world;
	public int baseZ = 3;
	public Vector2Int min = Vector2Int.zero;
	public Vector2Int max = new Vector2Int(100, 100);
	public Spawn spawn;
	public Exit exit;
	public Princess princess;
	public Background background;
	public TileEntityManager<Ground> grounds;
	public WallManager walls;
	public TileEntityManager<Fire> fires;
	public TileEntityManager<Ember> embers;
	public TileEntityManager<Coin> coins;
	public TileEntityManager<Poi> pois;
	public TileEntityManager<Seal> seals;
	public Player player;
	public UnityEvent toShop;
	public Grid g;
	public int collectedCoins = 0;
	public int savedSeals = 0;
	public GameObject pause;
	public int maxLevel;
	private bool paused = false;
	private Light2D playerLight;
	private AudioClip pauseSfx;
	private AudioClip unpauseSfx;
	private AudioSource source;

	private void BuildObjects(int level) {
		TileEntity.level = this;

		g = gameObject.AddComponent(typeof(Grid)) as Grid;
		g.cellSize = new Vector3(1, 1, 0);

		playerLight = new GameObject("PlayerLight", typeof(Light2D), typeof(PlayerLight)).GetComponent<Light2D>();
		playerLight.transform.SetParent(transform);
		playerLight.transform.localPosition = Vector3.zero;
		playerLight.lightType = Light2D.LightType.Point;
		playerLight.pointLightOuterRadius = 10;
		playerLight.shadowIntensity = 0.5f;

		grounds = new TileEntityManager<Ground>(this, "Ground", baseZ);

		walls = new WallManager(this, "Wall", baseZ - 1, grounds);

		fires = new TileEntityManager<Fire>(this, "Fire", baseZ - 2);

		embers = new TileEntityManager<Ember>(this, "Ember", baseZ - 2);
		
		coins = new TileEntityManager<Coin>(this, "Coin", baseZ - 1);
		
		pois = new TileEntityManager<Poi>(this, "Poi", baseZ - 1);

		seals = new TileEntityManager<Seal>(this, "Seal", baseZ - 1);
		
		princess = new GameObject("Princess", typeof(Princess)).GetComponent<Princess>();
		princess.transform.SetParent(transform);
		princess.z = baseZ - 1;
		princess.exit = toShop;

		exit = new GameObject("Exit", typeof(Exit)).GetComponent<Exit>();
		exit.transform.SetParent(transform);
		exit.z = baseZ - 1;
		exit.exit = toShop;

		if (level == maxLevel) exit.gameObject.SetActive(false);
		if (level != maxLevel) princess.gameObject.SetActive(false);

		spawn = new GameObject("Spawn", typeof(Spawn)).GetComponent<Spawn>();
		spawn.transform.SetParent(transform);
		spawn.z = baseZ - 1;

		background = new GameObject("Background", typeof(Background)).GetComponent<Background>();
		background.transform.SetParent(transform);
		background.z = baseZ + 1;

		player = world.BuildPlayer();
		playerLight.GetComponent<PlayerLight>().target = player;
		princess.player = player;
	}

	public void Init(int level) {
		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		pauseSfx = Resources.Load<AudioClip>("SoundEffects/pauseSFX");
		unpauseSfx = Resources.Load<AudioClip>("SoundEffects/unpauseSFX");
		BuildObjects(level);
		switch (level) {
			case 0:
				grounds.FillTiles(new Vector2Int(1, 1), new Vector2Int(3, 15));
				walls.FillWalls();
				exit.SetPos(new Vector2Int(2, 15));
				spawn.SetPos(new Vector2Int(2, 1));
				break;
			case 1:
				grounds.FillTiles(new Vector2Int(1, 1), new Vector2Int(10, 3));
				grounds.FillTiles(new Vector2Int(8, 4), new Vector2Int(10, 15));
				walls.FillWalls();
				fires.FillTiles(new Vector2Int(9, 13), new Vector2Int(9, 13));
				exit.SetPos(new Vector2Int(9, 15));
				spawn.SetPos(new Vector2Int(1, 1));
				break;
			case 2:
				grounds.FillTiles(new Vector2Int(1,1), new Vector2Int(20, 3));
				walls.FillWalls();
				fires.FillTiles(new Vector2Int(5, 1), new Vector2Int(7,3));
				spawn.SetPos(new Vector2Int(10, 2));
				exit.SetPos(new Vector2Int(20, 2));
				coins.SetTile(new Vector2Int(1, 1));
				coins.SetTile(new Vector2Int(1, 2));
				coins.SetTile(new Vector2Int(1, 3));
				break;
			case 3:
				grounds.FillTiles(new Vector2Int(1,1), new Vector2Int(5, 15));
				spawn.SetPos(new Vector2Int(3, 1));
				exit.SetPos(new Vector2Int(3, 15));
				pois.SetTile(new Vector2Int(3, 10));
				fires.FillTiles(new Vector2Int(1, 5), new Vector2Int(5,7));
				walls.FillWalls();
				coins.SetTile(new Vector2Int(5, 15));
				coins.SetTile(new Vector2Int(1, 15));
				break;
			case 4:
				grounds.FillTiles(new Vector2Int(1,1), new Vector2Int(15,10));
				walls.FillWalls();
				walls.FillTiles(new Vector2Int(10, 2), new Vector2Int(10,10));
				walls.FillTiles(new Vector2Int(5, 1), new Vector2Int(5, 9));
				coins.SetTile(new Vector2Int(1,1));
				coins.SetTile(new Vector2Int(1,10));
				fires.FillTiles(new Vector2Int(6, 3), new Vector2Int(9,3));
				fires.FillTiles(new Vector2Int(6, 7), new Vector2Int(9,7));
				fires.SetTile(new Vector2Int(5, 10));
				spawn.SetPos(new Vector2Int(15, 5));
				exit.SetPos(new Vector2Int(1, 5));
				seals.SetTile(new Vector2Int(3, 5));
				break;
			case 5:
				grounds.FillTiles(new Vector2Int(1,1), new Vector2Int(11, 10));
				walls.FillWalls();
				walls.FillTiles(new Vector2Int(3,1), new Vector2Int(3, 8));
				walls.FillTiles(new Vector2Int(6,3), new Vector2Int(6, 10));
				walls.FillTiles(new Vector2Int(9,1), new Vector2Int(9, 8));
				spawn.SetPos(new Vector2Int(1, 1));
				exit.SetPos(new Vector2Int(11,1));
				coins.SetTile(new Vector2Int(2,5));
				coins.SetTile(new Vector2Int(5,6));
				coins.SetTile(new Vector2Int(7,6));
				coins.SetTile(new Vector2Int(10,5));
				fires.FillTiles(new Vector2Int(1, 9), new Vector2Int(5,10));
				fires.FillTiles(new Vector2Int(4, 1), new Vector2Int(8,2));
				fires.FillTiles(new Vector2Int(7, 9), new Vector2Int(10,10));
				break;
			case 6:
				grounds.FillTiles(new Vector2Int(2,2), new Vector2Int(34,19));
				walls.FillWalls();
				walls.FillTiles(new Vector2Int(5,5), new Vector2Int(13,5));
				walls.FillTiles(new Vector2Int(5,6), new Vector2Int(5,14));
				walls.FillTiles(new Vector2Int(6,14), new Vector2Int(10,14));
				walls.FillTiles(new Vector2Int(10,14), new Vector2Int(10,8));
				walls.FillTiles(new Vector2Int(14,5), new Vector2Int(14,16));
				walls.FillTiles(new Vector2Int(15,16), new Vector2Int(29,16));
				walls.FillTiles(new Vector2Int(29,16), new Vector2Int(29,2));
				walls.FillTiles(new Vector2Int(18,2), new Vector2Int(18,12));
				walls.FillTiles(new Vector2Int(19,12), new Vector2Int(25,12));
				walls.FillTiles(new Vector2Int(25,12), new Vector2Int(25,4));
				walls.FillTiles(new Vector2Int(25,4), new Vector2Int(21,4));
				walls.FillTiles(new Vector2Int(21,5), new Vector2Int(21,9));
				spawn.SetPos(new Vector2Int(2,2));
				exit.SetPos(new Vector2Int(32,2));
				fires.FillTiles(new Vector2Int(8,2), new Vector2Int(11,4));
				fires.FillTiles(new Vector2Int(12,12), new Vector2Int(12,12));
				fires.FillTiles(new Vector2Int(18,13), new Vector2Int(21,15));
				fires.FillTiles(new Vector2Int(28,6), new Vector2Int(28,6));
				fires.FillTiles(new Vector2Int(33, 13), new Vector2Int(33,13));
				coins.SetTile(new Vector2Int(22,5));
				coins.SetTile(new Vector2Int(24,5));
				coins.SetTile(new Vector2Int(22,7));
				coins.SetTile(new Vector2Int(24,7));
				coins.SetTile(new Vector2Int(6, 13));
				coins.SetTile(new Vector2Int(9, 13));
				pois.SetTile(new Vector2Int(7, 11));
				//pois.SetTile(new Vector2Int(8, 12));
				break;
			case 7:
				grounds.FillTiles(new Vector2Int(1,1), new Vector2Int(40,40));
				walls.FillWalls();
				spawn.SetPos(new Vector2Int(20,20));
				exit.SetPos(new Vector2Int(1,40));
				fires.FillTiles(new Vector2Int(15, 15), new Vector2Int(15, 25));
				fires.FillTiles(new Vector2Int(16, 25), new Vector2Int(25, 25));
				fires.FillTiles(new Vector2Int(16, 15), new Vector2Int(25, 15));
				fires.FillTiles(new Vector2Int(25, 16), new Vector2Int(25, 24));
				fires.FillTiles(new Vector2Int(10, 10), new Vector2Int(10, 30));
				fires.FillTiles(new Vector2Int(11, 30), new Vector2Int(30, 30));
				fires.FillTiles(new Vector2Int(11, 10), new Vector2Int(30, 10));
				fires.FillTiles(new Vector2Int(30, 11), new Vector2Int(30, 29));
				coins.SetTile(new Vector2Int(40, 1));
				coins.SetTile(new Vector2Int(1, 1));
				coins.SetTile(new Vector2Int(40, 40));
				break;
			case 8:
				grounds.FillTiles(new Vector2Int(2,2), new Vector2Int(18,32));
				grounds.FillTiles(new Vector2Int(19,2), new Vector2Int(36, 4));
				walls.FillWalls();
				walls.FillTiles(new Vector2Int(5,2), new Vector2Int(5,9));
				walls.FillTiles(new Vector2Int(5,13), new Vector2Int(14,13));
				walls.FillTiles(new Vector2Int(14,2), new Vector2Int(14,12));
				walls.FillTiles(new Vector2Int(6,9), new Vector2Int(11,9));
				walls.FillTiles(new Vector2Int(11,4), new Vector2Int(11,8));
				walls.FillTiles(new Vector2Int(8,4), new Vector2Int(10,4));
				walls.FillTiles(new Vector2Int(8,5), new Vector2Int(8,6));
				walls.FillTiles(new Vector2Int(2,17), new Vector2Int(16,17));
				walls.FillTiles(new Vector2Int(16,18), new Vector2Int(16,30));
				walls.FillTiles(new Vector2Int(4,30), new Vector2Int(15,30));
				walls.FillTiles(new Vector2Int(4,20), new Vector2Int(4,29));
				walls.FillTiles(new Vector2Int(5,20), new Vector2Int(13,20));
				walls.FillTiles(new Vector2Int(13,21), new Vector2Int(13,27));
				walls.FillTiles(new Vector2Int(7,27), new Vector2Int(12,27));
				walls.FillTiles(new Vector2Int(7,23), new Vector2Int(7,26));
				walls.FillTiles(new Vector2Int(8,23), new Vector2Int(9,23));
				walls.FillTiles(new Vector2Int(10,23), new Vector2Int(10,24));
				spawn.SetPos(new Vector2Int(2,2));
				exit.SetPos(new Vector2Int(8, 24));
				//coins.SetTile(new Vector2Int(35,2));
				//coins.SetTile(new Vector2Int(35,4));
				coins.SetTile(new Vector2Int(34,3));
				coins.SetTile(new Vector2Int(36,3));
				coins.SetTile(new Vector2Int(2,32));
				coins.SetTile(new Vector2Int(15, 18));
				pois.FillTiles(new Vector2Int(9,5), new Vector2Int(9,5));
				fires.FillTiles(new Vector2Int(5,10), new Vector2Int(5,12));
				fires.FillTiles(new Vector2Int(12,4), new Vector2Int(13,9));
				fires.FillTiles(new Vector2Int(20, 2), new Vector2Int(20,4));
				fires.SetTile(new Vector2Int(18, 17));
				fires.SetTile(new Vector2Int(15, 29));
				fires.SetTile(new Vector2Int(2, 18));
				break;
			case 9:
				grounds.FillTiles(new Vector2Int(10,12), new Vector2Int(12,26));
				grounds.FillTiles(new Vector2Int(13,24), new Vector2Int(22, 26));
				grounds.FillTiles(new Vector2Int(23,12), new Vector2Int(39,26));
				grounds.FillTiles(new Vector2Int(23,27), new Vector2Int(25,41));
				grounds.FillTiles(new Vector2Int(26,39), new Vector2Int(37, 41));
				grounds.FillTiles(new Vector2Int(35,42), new Vector2Int(37,49));
				walls.FillWalls();
				walls.FillTiles(new Vector2Int(35,12), new Vector2Int(35,23));
				walls.FillTiles(new Vector2Int(26,23), new Vector2Int(34,23));
				walls.FillTiles(new Vector2Int(26,14), new Vector2Int(26,22));
				spawn.SetPos(new Vector2Int(24,25));
				exit.SetPos(new Vector2Int(36, 49));
				pois.SetTile(new Vector2Int(11,12));
				seals.SetTile(new Vector2Int(37,12));
				fires.SetTile(new Vector2Int(11, 23));
				fires.SetTile(new Vector2Int(30, 12));
				fires.SetTile(new Vector2Int(35, 25));
				fires.SetTile(new Vector2Int(24, 40));
				fires.SetTile(new Vector2Int(31,40));
				coins.SetTile(new Vector2Int(29, 20));
				coins.SetTile(new Vector2Int(32, 20));
				break;
			case 10:
				grounds.FillTiles(new Vector2Int(2,2), new Vector2Int(42,17));
				grounds.FillTiles(new Vector2Int(21,18), new Vector2Int(23, 35));
				walls.FillWalls();
				walls.FillTiles(new Vector2Int(5,5), new Vector2Int(5,14));
				walls.FillTiles(new Vector2Int(6,5), new Vector2Int(13,5));
				walls.FillTiles(new Vector2Int(13,6), new Vector2Int(13,14));
				walls.FillTiles(new Vector2Int(8,14), new Vector2Int(12,14));
				walls.FillTiles(new Vector2Int(18,5), new Vector2Int(26,5));
				walls.FillTiles(new Vector2Int(18,6), new Vector2Int(18,14));
				walls.FillTiles(new Vector2Int(19,14), new Vector2Int(20,14));
				walls.FillTiles(new Vector2Int(26,6), new Vector2Int(26, 14));
				walls.FillTiles(new Vector2Int(24, 14), new Vector2Int(25,14));
				walls.FillTiles(new Vector2Int(31, 5), new Vector2Int(39,5));
				walls.FillTiles(new Vector2Int(31,6), new Vector2Int(31,14));
				walls.FillTiles(new Vector2Int(32,14), new Vector2Int(36, 14));
				walls.FillTiles(new Vector2Int(39, 6), new Vector2Int(39,14));
				spawn.SetPos(new Vector2Int(22,3));
				exit.SetPos(new Vector2Int(22, 35));
				pois.SetTile(new Vector2Int(9,6));
				seals.SetTile(new Vector2Int(35,6));
				fires.SetTile(new Vector2Int(6, 3));
				fires.SetTile(new Vector2Int(38, 3));
				fires.SetTile(new Vector2Int(7, 12));
				fires.SetTile(new Vector2Int(37, 12));
				fires.SetTile(new Vector2Int(10,16));
				fires.SetTile(new Vector2Int(34, 16));
				fires.SetTile(new Vector2Int(22, 18));
				fires.SetTile(new Vector2Int(22, 27));
				fires.FillTiles(new Vector2Int(22,11), new Vector2Int(22,12));
				coins.SetTile(new Vector2Int(41, 3));
				coins.SetTile(new Vector2Int(3, 3));
				coins.SetTile(new Vector2Int(19, 6));
				coins.SetTile(new Vector2Int(25, 6));
				break;
			case 11:
				grounds.FillTiles(new Vector2Int(2,2), new Vector2Int(24,25));
				grounds.FillTiles(new Vector2Int(25,24), new Vector2Int(42, 25));
				walls.FillWalls();
				spawn.SetPos(new Vector2Int(2,2));
				exit.SetPos(new Vector2Int(42, 24));
				pois.SetTile(new Vector2Int(30,24));
				//coins.SetTile(new Vector2Int(38, 24));
				coins.SetTile(new Vector2Int(40,24));
				//coins.SetTile(new Vector2Int(34, 24));
				coins.SetTile(new Vector2Int(36, 24));
				fires.FillTiles(new Vector2Int(2,5), new Vector2Int(20,25));
				fires.FillTiles(new Vector2Int(5,2), new Vector2Int(24,4));
				fires.FillTiles(new Vector2Int(21,5), new Vector2Int(24,20));
				break;
			case 12:
				grounds.FillTiles(new Vector2Int(33,8), new Vector2Int(49,49));
				walls.FillWalls();
				walls.FillTiles(new Vector2Int(33,22), new Vector2Int(42,22));
				walls.FillTiles(new Vector2Int(36,26), new Vector2Int(49,26));
				walls.FillTiles(new Vector2Int(36,27), new Vector2Int(36,35));
				walls.FillTiles(new Vector2Int(39,35), new Vector2Int(49,35));
				walls.FillTiles(new Vector2Int(35,38), new Vector2Int(35,47));
				walls.FillTiles(new Vector2Int(36,38), new Vector2Int(38,38));
				walls.FillTiles(new Vector2Int(38,39), new Vector2Int(38,49));
				walls.FillTiles(new Vector2Int(41,38), new Vector2Int(47, 38));
				walls.FillTiles(new Vector2Int(41, 39), new Vector2Int(41,46));
				walls.FillTiles(new Vector2Int(42,46), new Vector2Int(44,46));
				walls.FillTiles(new Vector2Int(44,41), new Vector2Int(44,45));
				walls.FillTiles(new Vector2Int(47,39), new Vector2Int(47, 46));
				spawn.SetPos(new Vector2Int(49,49));
				princess.SetPos(new Vector2Int(33,8));
				pois.SetTile(new Vector2Int(36,39));
				pois.SetTile(new Vector2Int(42,45));
				pois.SetTile(new Vector2Int(49,27));
				pois.SetTile(new Vector2Int(36,10));
				pois.SetTile(new Vector2Int(41,10));
				pois.SetTile(new Vector2Int(46,10));
				pois.SetTile(new Vector2Int(36,18));
				pois.SetTile(new Vector2Int(41,18));
				pois.SetTile(new Vector2Int(46,18));
				fires.FillTiles(new Vector2Int(46,24), new Vector2Int(47,24));
				fires.FillTiles(new Vector2Int(39,27), new Vector2Int(39,34));
				fires.FillTiles(new Vector2Int(36, 46), new Vector2Int(37,47));
				fires.FillTiles(new Vector2Int(45,41), new Vector2Int(46,42));
				fires.SetTile(new Vector2Int(41, 14));
				break;
			default:
				break;
		}
		background.SetPos(Vector2Int.zero);
		spawn.SpawnPlayer(player);
	}

	private void Update() {
		if (Input.GetButtonDown("Cancel")) {
			if (paused) {
				source.PlayOneShot(unpauseSfx);
				pause.SetActive(false);
				Time.timeScale = 1;
				paused = false;
			} else {
				source.PlayOneShot(pauseSfx);
				pause.SetActive(true);
				Time.timeScale = 0;
				paused = true;
			}
		}
	}
}
