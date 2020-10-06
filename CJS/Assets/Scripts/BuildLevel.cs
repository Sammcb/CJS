using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildLevel: MonoBehaviour {
	private void Start() {
		transform.position = Vector3.zero;
		Sprite[] hellSprites = Resources.LoadAll<Sprite>("Tiles/Hell");

		GameObject level = new GameObject("Level", typeof(Grid));
		level.transform.SetParent(transform);
		level.GetComponent<Grid>().cellSize = new Vector3(1, 1, 0);

		GameObject ground = new GameObject("Ground", typeof(Tilemap), typeof(TilemapRenderer));
		ground.transform.SetParent(level.transform);
		ground.transform.localPosition = Vector3.forward;

		Tile groundTile = ScriptableObject.CreateInstance<Tile>();
		groundTile.sprite = hellSprites[5];

		Tile test = ScriptableObject.CreateInstance<Tile>();
		test.sprite = hellSprites[0];

		ground.GetComponent<Tilemap>().SetTile(new Vector3Int(0, 0, 1), groundTile);
		ground.GetComponent<Tilemap>().SetTile(new Vector3Int(1, 0, 1), test);
		ground.GetComponent<Tilemap>().SetTile(new Vector3Int(2, 0, 1), groundTile);

		GameObject walls = new GameObject("Walls", typeof(Tilemap), typeof(TilemapRenderer));
		walls.transform.SetParent(level.transform);
	}
}
