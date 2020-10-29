using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level: MonoBehaviour {
	public static int groundZ = 3;
	public static int wallZ = 2;
	public static int fireZ = 1;
	public static int coinZ = 2;
	public static int poiZ = 2;
	public GameObject ground;
	public GameObject walls;
	public GameObject poi;
	public TileEntityManager<Fire> fires;
	public TileEntityManager<Coin> coins;
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

		fires = new TileEntityManager<Fire>();
		fires.l = gameObject;
		fires.tileName = "Fire";
		fires.z = fireZ;
		fires.FillTiles(new Vector2Int(4, 4), new Vector2Int(5, 5));

		coins = new TileEntityManager<Coin>();
		coins.l = gameObject;
		coins.tileName = "Coin";
		coins.z = coinZ;
		coins.SetTile(new Vector2Int(1, 1));

		poi = new GameObject("POI", typeof(Poi));
		poi.transform.SetParent(transform);
		poi.transform.localPosition = Vector3.forward * poiZ;
		poi.GetComponent<Poi>().FillTiles(new Vector2Int(2, 2), new Vector2Int(2,2));

	}
}
