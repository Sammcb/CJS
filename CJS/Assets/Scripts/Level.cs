using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level: MonoBehaviour {
	public static int groundZ = 1;
	public static int wallZ = 0;
	public static int fireZ = 0;
	public GameObject ground;
	public GameObject walls;
	public GameObject fire;
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
		fire.GetComponent<Fire>().FillTiles(new Vector2Int(1, 1), new Vector2Int(4, 4));
	}
}
