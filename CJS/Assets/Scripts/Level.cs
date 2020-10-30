using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level: MonoBehaviour {
	public static int groundZ = 3;
	public static int wallZ = 2;
	public static int fireZ = 1;
	public static int coinZ = 2;
	public static int poiZ = 2;
	public static int exitZ = 2;
	public static int spawnZ = 2;
	public GameObject ground;
	public GameObject walls;
	public GameObject poi;
	public GameObject spawn;
	public GameObject exit;
	public TileEntityManager<Fire> fires;
	public TileEntityManager<Coin> coins;
	public TileEntityManager<Poi> pois;
	public GameObject player;
	public UnityEvent nextLevel;
	private Grid g;

	private void Awake() {
		g = gameObject.AddComponent(typeof(Grid)) as Grid;
		g.cellSize = new Vector3(1, 1, 0);

		ground = new GameObject("Ground", typeof(Ground));
		ground.transform.SetParent(transform);
		ground.transform.localPosition = Vector3.forward * groundZ;

		walls = new GameObject("Walls", typeof(Wall));
		walls.transform.SetParent(transform);
		walls.transform.localPosition = Vector3.forward * wallZ;

		fires = new TileEntityManager<Fire>();
		fires.l = gameObject;
		fires.tileName = "Fire";
		fires.z = fireZ;
		
		coins = new TileEntityManager<Coin>();
		coins.l = gameObject;
		coins.tileName = "Coin";
		coins.z = coinZ;
		
		pois = new TileEntityManager<Poi>();
		pois.l = gameObject;
		pois.tileName = "Poi";
		pois.z = poiZ;
		
		exit = new GameObject("Exit", typeof(Exit));
		exit.transform.SetParent(transform);
		exit.GetComponent<Exit>().z = exitZ;
		exit.SetActive(false);

		spawn = new GameObject("Spawn", typeof(Spawn));
		spawn.transform.SetParent(transform);
		spawn.GetComponent<Spawn>().z = spawnZ;
		spawn.SetActive(false);
	}

	public void Init(int level) {
		Exit e = exit.GetComponent<Exit>();
		Spawn s = spawn.GetComponent<Spawn>();
		switch (level) {
			case 0:
				ground.GetComponent<Ground>().FillTiles(new Vector2Int(1, 1), new Vector2Int(10, 10));
				walls.GetComponent<Wall>().FillWalls();
				fires.FillTiles(new Vector2Int(4, 4), new Vector2Int(5, 5));
				coins.SetTile(new Vector2Int(1, 1));
				pois.SetTile(new Vector2Int(2, 2));
				e.SetPos(new Vector2Int(9, 9));
				s.SetPos(new Vector2Int(2, 3));
				break;
			default:
				break;
		}
		exit.SetActive(true);
		spawn.SetActive(true);
		s.SpawnPlayer(player);
	}
}
