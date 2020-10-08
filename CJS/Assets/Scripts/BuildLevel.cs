using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildLevel: MonoBehaviour {

	private int groundZ = 1;
	private int wallZ = 0;
	private int fireZ = 0;

	private GameObject level;
	private GameObject ground;
	private GameObject walls;
	private GameObject fire;

	private void Start() {
		transform.position = Vector3.zero;
		Sprite[] hellSprites = Resources.LoadAll<Sprite>("Tiles/Hell");

		level = new GameObject("Level", typeof(Grid));
		level.transform.SetParent(transform);
		level.GetComponent<Grid>().cellSize = new Vector3(1, 1, 0);

		ground = new GameObject("Ground", typeof(Ground));
		ground.transform.SetParent(level.transform);
		ground.transform.localPosition = Vector3.forward * groundZ;
		ground.GetComponent<Ground>().FillTiles(new Vector2Int(5, 5), new Vector2Int(-5, -5));

		walls = new GameObject("Walls", typeof(Wall));
		walls.transform.SetParent(level.transform);
		walls.transform.localPosition = Vector3.forward * wallZ;
		walls.GetComponent<Wall>().FillTiles(new Vector2Int(5, 5), new Vector2Int(-5, 5));

		fire = new GameObject("Fire", typeof(Fire));
		fire.transform.SetParent(level.transform);
		fire.transform.localPosition = Vector3.forward * fireZ;
		fire.GetComponent<Fire>().FillTiles(new Vector2Int(4, 4), new Vector2Int(4, 4));
	}
}
