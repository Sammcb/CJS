﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level: MonoBehaviour {
	public static int groundZ = 1;
	public static int wallZ = 0;
	public static int fireZ = 0;
	public static int coinZ = 0;
	public static int houseZ = 0;
	public GameObject ground;
	public GameObject walls;
	public GameObject fire;
	public GameObject coin;
	public GameObject house;
	private Vector2Int a;
	private Vector2Int b;
	private Grid g;

	private void Awake() {
		g = gameObject.AddComponent(typeof(Grid)) as Grid;
		g.cellSize = new Vector3(1, 1, 0);
	}

	private void Start() {
		ground = new GameObject("Ground", typeof(Ground));
		ground.transform.SetParent(transform);
		ground.transform.localPosition = Vector3.forward * groundZ;
		ground.GetComponent<Ground>().FillTiles(new Vector2Int(1, 1), new Vector2Int(10, 10));

		walls = new GameObject("Walls", typeof(Wall));
		walls.transform.SetParent(transform);
		walls.transform.localPosition = Vector3.forward * wallZ;
		walls.GetComponent<Wall>().FillWalls();

		fire = new GameObject("Fire", typeof(Fire));
		fire.transform.SetParent(transform);
		fire.transform.localPosition = Vector3.forward * fireZ;
		fire.GetComponent<Fire>().FillTiles(new Vector2Int(4, 4), new Vector2Int(4, 4));

		coin = new GameObject("Coin", typeof(Coin));
		coin.transform.SetParent(transform);
		coin.transform.localPosition = Vector3.forward * coinZ;
		coin.GetComponent<Coin>().FillTiles(new Vector2Int(1, 1), new Vector2Int(1, 1));

		house = new GameObject("House", typeof(House));
		house.transform.SetParent(transform);
		house.transform.localPosition = Vector3.forward * houseZ;
		house.GetComponent<House>().FillTiles(new Vector2Int(2, 2), new Vector2Int(2,2));

	}

	public void SetBounds(Vector2Int a, Vector2Int b) {
		this.a = a;
		this.b = b;
	}

	public int MinX() {
		return Mathf.Min(a.x, b.x);
	}

	public int MinY() {
		return Mathf.Min(a.y, b.y);
	}

	public int MaxX() {
		return Mathf.Max(a.x, b.x);
	}

	public int MaxY() {
		return Mathf.Max(a.y, b.y);
	}

	public bool InBounds(Vector2Int va, Vector2Int vb) {
		return Mathf.Min(va.x, vb.x) >= MinX() && Mathf.Max(va.x, vb.x) >= MinY() && Mathf.Min(va.y, vb.y) <= MaxX() && Mathf.Max(va.y, vb.y) <= MaxY();
		fire.GetComponent<Fire>().FillTiles(new Vector2Int(1, 1), new Vector2Int(4, 4));
	}
}
