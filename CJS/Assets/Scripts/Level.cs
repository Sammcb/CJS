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
				ground.GetComponent<Ground>().FillTiles(new Vector2Int(1, 1), new Vector2Int(3, 15));
				walls.GetComponent<Wall>().FillWalls();
				e.SetPos(new Vector2Int(2, 15));
				s.SetPos(new Vector2Int(2, 1));
				break;
			case 1:
				ground.GetComponent<Ground>().FillTiles(new Vector2Int(1, 1), new Vector2Int(10, 3));
				ground.GetComponent<Ground>().FillTiles(new Vector2Int(8, 4), new Vector2Int(10, 15));
				walls.GetComponent<Wall>().FillWalls();
				fires.FillTiles(new Vector2Int(9, 13), new Vector2Int(9, 13));
				//pois.SetTile(new Vector2Int(2, 2));
				e.SetPos(new Vector2Int(9, 15));
				s.SetPos(new Vector2Int(1, 1));
				break;
			case 3:
				ground.GetComponent<Ground>().FillTiles(new Vector2Int(1,1), new Vector2Int(20, 3));
				walls.GetComponent<Wall>().FillWalls();
				fires.FillTiles(new Vector2Int(5, 1), new Vector2Int(7,3));
				s.SetPos(new Vector2Int(10, 2));
				e.SetPos(new Vector2Int(20, 2));
				coins.SetTile(new Vector2Int(1, 1));
				coins.SetTile(new Vector2Int(1, 2));
				coins.SetTile(new Vector2Int(1, 3));
				break;
			case 4:
				ground.GetComponent<Ground>().FillTiles(new Vector2Int(1,1), new Vector2Int(5, 15));
				s.SetPos(new Vector2Int(3, 1));
				e.SetPos(new Vector2Int(3, 15));
				pois.SetTile(new Vector2Int(3, 10));
				fires.FillTiles(new Vector2Int(1, 5), new Vector2Int(5,7));
				walls.GetComponent<Wall>().FillWalls();
				coins.SetTile(new Vector2Int(5, 15));
				coins.SetTile(new Vector2Int(1, 15));
				break;
			case 5:
				ground.GetComponent<Ground>().FillTiles(new Vector2Int(1,1), new Vector2Int(11, 10));
				walls.GetComponent<Wall>().FillWalls();
				walls.GetComponent<Wall>().FillTiles(new Vector2Int(3,1), new Vector2Int(3, 8));
				walls.GetComponent<Wall>().FillTiles(new Vector2Int(6,3), new Vector2Int(6, 10));
				walls.GetComponent<Wall>().FillTiles(new Vector2Int(9,1), new Vector2Int(9, 8));
				s.SetPos(new Vector2Int(1, 1));
				e.SetPos(new Vector2Int(11,1));
				coins.SetTile(new Vector2Int(2,5));
				coins.SetTile(new Vector2Int(5,6));
				coins.SetTile(new Vector2Int(7,6));
				coins.SetTile(new Vector2Int(10,5));
				fires.FillTiles(new Vector2Int(1, 9), new Vector2Int(5,10));
				fires.FillTiles(new Vector2Int(4, 1), new Vector2Int(8,2));
				fires.FillTiles(new Vector2Int(7, 9), new Vector2Int(10,10));
				break;
			default:
				break;
		}
		exit.SetActive(true);
		spawn.SetActive(true);
		s.SpawnPlayer(player);
	}
}
