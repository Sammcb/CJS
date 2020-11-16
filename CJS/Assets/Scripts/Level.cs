using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level: MonoBehaviour {
	public World world;
	public int baseZ = 3;
	public Ground ground;
	public Wall wall;
	public Spawn spawn;
	public Exit exit;
	public TileEntityManager<Fire> fires;
	public TileEntityManager<Ember> embers;
	public TileEntityManager<Coin> coins;
	public TileEntityManager<Poi> pois;
	public Player player;
	public UnityEvent toShop;
	public Grid g;
	public int collectedCoins = 0;

	private void BuildObjects() {
		TileEntity.level = this;

		g = gameObject.AddComponent(typeof(Grid)) as Grid;
		g.cellSize = new Vector3(1, 1, 0);

		ground = new GameObject("Ground", typeof(Ground)).GetComponent<Ground>();
		ground.transform.SetParent(transform);
		ground.transform.localPosition = Vector3.forward * baseZ;

		wall = new GameObject("Wall", typeof(Wall)).GetComponent<Wall>();
		wall.transform.SetParent(transform);
		wall.transform.localPosition = Vector3.forward * (baseZ - 1);

		fires = new TileEntityManager<Fire>();
		fires.level = this;
		fires.tileName = "Fire";
		fires.z = baseZ - 2;

		embers = new TileEntityManager<Ember>();
		embers.level = this;
		embers.tileName = "Ember";
		embers.z = baseZ - 2;
		
		coins = new TileEntityManager<Coin>();
		coins.level = this;
		coins.tileName = "Coin";
		coins.z = baseZ - 1;
		
		pois = new TileEntityManager<Poi>();
		pois.level = this;
		pois.tileName = "Poi";
		pois.z = baseZ - 1;
		pois.size = new Vector2Int(2, 1);
		
		exit = new GameObject("Exit", typeof(Exit)).GetComponent<Exit>();
		exit.transform.SetParent(transform);
		exit.z = baseZ - 1;
		exit.exit = toShop;

		spawn = new GameObject("Spawn", typeof(Spawn)).GetComponent<Spawn>();
		spawn.transform.SetParent(transform);
		spawn.z = baseZ - 1;

		player = world.BuildPlayer();
	}

	public void Init(int level) {
		BuildObjects();
		switch (level) {
			case 0:
				ground.FillTiles(new Vector2Int(1, 1), new Vector2Int(3, 15));
				wall.FillWalls();
				exit.SetPos(new Vector2Int(2, 15));
				spawn.SetPos(new Vector2Int(2, 1));
				break;
			case 1:
				ground.FillTiles(new Vector2Int(1, 1), new Vector2Int(10, 3));
				ground.FillTiles(new Vector2Int(8, 4), new Vector2Int(10, 15));
				wall.FillWalls();
				fires.FillTiles(new Vector2Int(9, 13), new Vector2Int(9, 13));
				exit.SetPos(new Vector2Int(9, 15));
				spawn.SetPos(new Vector2Int(1, 1));
				break;
			case 2:
				ground.FillTiles(new Vector2Int(1,1), new Vector2Int(20, 3));
				wall.FillWalls();
				fires.FillTiles(new Vector2Int(5, 1), new Vector2Int(7,3));
				spawn.SetPos(new Vector2Int(10, 2));
				exit.SetPos(new Vector2Int(20, 2));
				coins.SetTile(new Vector2Int(1, 1));
				coins.SetTile(new Vector2Int(1, 2));
				coins.SetTile(new Vector2Int(1, 3));
				break;
			case 3:
				ground.FillTiles(new Vector2Int(1,1), new Vector2Int(5, 15));
				spawn.SetPos(new Vector2Int(3, 1));
				exit.SetPos(new Vector2Int(3, 15));
				pois.SetTile(new Vector2Int(3, 10));
				fires.FillTiles(new Vector2Int(1, 5), new Vector2Int(5,7));
				wall.FillWalls();
				coins.SetTile(new Vector2Int(5, 15));
				coins.SetTile(new Vector2Int(1, 15));
				break;
			case 4:
				ground.FillTiles(new Vector2Int(1,1), new Vector2Int(11, 10));
				wall.FillWalls();
				wall.FillTiles(new Vector2Int(3,1), new Vector2Int(3, 8));
				wall.FillTiles(new Vector2Int(6,3), new Vector2Int(6, 10));
				wall.FillTiles(new Vector2Int(9,1), new Vector2Int(9, 8));
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
			case 5:
				ground.FillTiles(new Vector2Int(2,2), new Vector2Int(34,19));
				wall.FillWalls();
				wall.FillTiles(new Vector2Int(5,5), new Vector2Int(13,5));
				wall.FillTiles(new Vector2Int(5,6), new Vector2Int(5,14));
				wall.FillTiles(new Vector2Int(6,14), new Vector2Int(10,14));
				wall.FillTiles(new Vector2Int(10,14), new Vector2Int(10,8));
				wall.FillTiles(new Vector2Int(14,5), new Vector2Int(14,16));
				wall.FillTiles(new Vector2Int(15,16), new Vector2Int(29,16));
				wall.FillTiles(new Vector2Int(29,16), new Vector2Int(29,2));
				wall.FillTiles(new Vector2Int(18,2), new Vector2Int(18,12));
				wall.FillTiles(new Vector2Int(19,12), new Vector2Int(25,12));
				wall.FillTiles(new Vector2Int(25,12), new Vector2Int(25,4));
				wall.FillTiles(new Vector2Int(25,4), new Vector2Int(21,4));
				wall.FillTiles(new Vector2Int(21,5), new Vector2Int(21,9));
				spawn.SetPos(new Vector2Int(2,2));
				exit.SetPos(new Vector2Int(32,2));
				fires.FillTiles(new Vector2Int(8,2), new Vector2Int(11,4));
				fires.FillTiles(new Vector2Int(12,12), new Vector2Int(12,12));
				fires.FillTiles(new Vector2Int(18,13), new Vector2Int(21,15));
				fires.FillTiles(new Vector2Int(28,6), new Vector2Int(28,6));
				fires.FillTiles(new Vector2Int(33, 13), new Vector2Int(33,13));
				coins.FillTiles(new Vector2Int(22,5), new Vector2Int(24,7));
				coins.SetTile(new Vector2Int(6, 13));
				coins.SetTile(new Vector2Int(9, 13));
				pois.FillTiles(new Vector2Int(7, 11), new Vector2Int(8,12));
				break;
			case 6:
				ground.FillTiles(new Vector2Int(1,1), new Vector2Int(40,40));
				wall.FillWalls();
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
			case 7:
				ground.FillTiles(new Vector2Int(2,2), new Vector2Int(18,32));
				ground.FillTiles(new Vector2Int(19,2), new Vector2Int(36, 4));
				wall.FillWalls();
				wall.FillTiles(new Vector2Int(5,2), new Vector2Int(5,9));
				wall.FillTiles(new Vector2Int(5,13), new Vector2Int(14,13));
				wall.FillTiles(new Vector2Int(14,2), new Vector2Int(14,12));
				wall.FillTiles(new Vector2Int(6,9), new Vector2Int(11,9));
				wall.FillTiles(new Vector2Int(11,4), new Vector2Int(11,8));
				wall.FillTiles(new Vector2Int(8,4), new Vector2Int(10,4));
				wall.FillTiles(new Vector2Int(8,5), new Vector2Int(8,6));
				wall.FillTiles(new Vector2Int(2,17), new Vector2Int(16,17));
				wall.FillTiles(new Vector2Int(16,18), new Vector2Int(16,30));
				wall.FillTiles(new Vector2Int(4,30), new Vector2Int(15,30));
				wall.FillTiles(new Vector2Int(4,20), new Vector2Int(4,29));
				wall.FillTiles(new Vector2Int(5,20), new Vector2Int(13,20));
				wall.FillTiles(new Vector2Int(13,21), new Vector2Int(13,27));
				wall.FillTiles(new Vector2Int(7,27), new Vector2Int(12,27));
				wall.FillTiles(new Vector2Int(7,23), new Vector2Int(7,26));
				wall.FillTiles(new Vector2Int(8,23), new Vector2Int(9,23));
				wall.FillTiles(new Vector2Int(10,23), new Vector2Int(10,24));
				spawn.SetPos(new Vector2Int(2,2));
				exit.SetPos(new Vector2Int(8, 24));
				coins.SetTile(new Vector2Int(35,2));
				coins.SetTile(new Vector2Int(35,4));
				coins.SetTile(new Vector2Int(34,3));
				coins.SetTile(new Vector2Int(36,3));
				coins.SetTile(new Vector2Int(2,32));
				coins.SetTile(new Vector2Int(15, 18));
				pois.FillTiles(new Vector2Int(9,5), new Vector2Int(10,5));
				fires.FillTiles(new Vector2Int(5,10), new Vector2Int(5,12));
				fires.FillTiles(new Vector2Int(12,4), new Vector2Int(13,9));
				fires.FillTiles(new Vector2Int(20, 2), new Vector2Int(20,4));
				fires.SetTile(new Vector2Int(18, 17));
				fires.SetTile(new Vector2Int(15, 29));
				fires.SetTile(new Vector2Int(2, 18));
				break;
			case 8:
				ground.FillTiles(new Vector2Int(10,12), new Vector2Int(12,26));
				ground.FillTiles(new Vector2Int(13,24), new Vector2Int(22, 26));
				ground.FillTiles(new Vector2Int(23,12), new Vector2Int(39,26));
				ground.FillTiles(new Vector2Int(23,27), new Vector2Int(25,41));
				ground.FillTiles(new Vector2Int(26,39), new Vector2Int(37, 41));
				ground.FillTiles(new Vector2Int(35,42), new Vector2Int(37,49));
				wall.FillWalls();
				wall.FillTiles(new Vector2Int(35,12), new Vector2Int(35,23));
				wall.FillTiles(new Vector2Int(26,23), new Vector2Int(34,23));
				wall.FillTiles(new Vector2Int(26,14), new Vector2Int(26,22));
				spawn.SetPos(new Vector2Int(24,25));
				exit.SetPos(new Vector2Int(36, 49));
				pois.SetTile(new Vector2Int(11,12));
				pois.SetTile(new Vector2Int(37,12));
				fires.SetTile(new Vector2Int(11, 23));
				fires.SetTile(new Vector2Int(30, 12));
				fires.SetTile(new Vector2Int(35, 25));
				fires.SetTile(new Vector2Int(24, 40));
				fires.SetTile(new Vector2Int(31,40));
				coins.SetTile(new Vector2Int(29, 20));
				coins.SetTile(new Vector2Int(32, 20));
				break;
			case 9:
				ground.FillTiles(new Vector2Int(2,2), new Vector2Int(42,17));
				ground.FillTiles(new Vector2Int(21,18), new Vector2Int(23, 35));
				wall.FillWalls();
				wall.FillTiles(new Vector2Int(5,5), new Vector2Int(5,14));
				wall.FillTiles(new Vector2Int(6,5), new Vector2Int(13,5));
				wall.FillTiles(new Vector2Int(13,6), new Vector2Int(13,14));
				wall.FillTiles(new Vector2Int(8,14), new Vector2Int(12,14));
				wall.FillTiles(new Vector2Int(18,5), new Vector2Int(26,5));
				wall.FillTiles(new Vector2Int(18,6), new Vector2Int(18,14));
				wall.FillTiles(new Vector2Int(19,14), new Vector2Int(20,14));
				wall.FillTiles(new Vector2Int(26,6), new Vector2Int(26, 14));
				wall.FillTiles(new Vector2Int(24, 14), new Vector2Int(25,14));
				wall.FillTiles(new Vector2Int(31, 5), new Vector2Int(39,5));
				wall.FillTiles(new Vector2Int(31,6), new Vector2Int(31,14));
				wall.FillTiles(new Vector2Int(32,14), new Vector2Int(36, 14));
				wall.FillTiles(new Vector2Int(39, 6), new Vector2Int(39,14));
				spawn.SetPos(new Vector2Int(22,3));
				exit.SetPos(new Vector2Int(22, 35));
				pois.SetTile(new Vector2Int(9,6));
				pois.SetTile(new Vector2Int(35,6));
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
			case 10:
				ground.FillTiles(new Vector2Int(2,2), new Vector2Int(24,25));
				ground.FillTiles(new Vector2Int(25,24), new Vector2Int(42, 25));
				wall.FillWalls();
				spawn.SetPos(new Vector2Int(2,2));
				exit.SetPos(new Vector2Int(42, 24));
				pois.SetTile(new Vector2Int(30,24));
				coins.SetTile(new Vector2Int(38, 24));
				coins.SetTile(new Vector2Int(40,24));
				coins.SetTile(new Vector2Int(34, 24));
				coins.SetTile(new Vector2Int(36, 24));
				fires.FillTiles(new Vector2Int(2,5), new Vector2Int(20,25));
				fires.FillTiles(new Vector2Int(5,2), new Vector2Int(24,4));
				fires.FillTiles(new Vector2Int(21,5), new Vector2Int(24,20));
				
				break;
			case 11:
				break;
			default:
				break;
		}
		spawn.SpawnPlayer(player);
	}
}
