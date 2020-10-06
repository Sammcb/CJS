using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildLevel: MonoBehaviour {

	private GameObject level;
	private GameObject ground;
	private GameObject walls;
	private GameObject fire;

	private Tile groundTile;
	private Tile wallTile;
	private Tile fireTile;


	private void Start() {
		transform.position = Vector3.zero;
		Sprite[] hellSprites = Resources.LoadAll<Sprite>("Tiles/Hell");

		level = new GameObject("Level", typeof(Grid));
		level.transform.SetParent(transform);
		level.GetComponent<Grid>().cellSize = new Vector3(1, 1, 0);

		groundTile = ScriptableObject.CreateInstance<Tile>();
		groundTile.sprite = hellSprites[5];

		wallTile = ScriptableObject.CreateInstance<Tile>();
		wallTile.sprite = hellSprites[1];

		fireTile = ScriptableObject.CreateInstance<Tile>();
		fireTile.sprite = hellSprites[0];

		GenerateGround();
		GenerateWalls();
		GenerateFire();
	}

	private void GenerateGround() {
		ground = new GameObject("Ground", typeof(Tilemap), typeof(TilemapRenderer));
		ground.transform.SetParent(level.transform);
		ground.transform.localPosition = Vector3.forward;

		for(int i = 0; i < 4; i++) {
			for(int j = 0; j< 4; j++) {
				ground.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 1), groundTile);
			}
		}
	}

	private void GenerateWalls() {
		walls = new GameObject("Walls", typeof(Tilemap), typeof(TilemapRenderer), typeof(TilemapCollider2D), typeof(Rigidbody2D), typeof(CompositeCollider2D));
		walls.transform.SetParent(level.transform);
		walls.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		walls.GetComponent<TilemapCollider2D>().usedByComposite = true;

		for(int i = 0; i < 4; i++) {
			for(int j = 0; j< 4; j++) {
				if(i == 0 || i == 3 || j == 0 || j == 3) {
					walls.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), wallTile);
				}
			}
		}
	}

	private void GenerateFire() {
		fire = new GameObject("Fire", typeof(Tilemap), typeof(TilemapRenderer), typeof(TilemapCollider2D), typeof(Rigidbody2D), typeof(CompositeCollider2D));
		fire.transform.SetParent(level.transform);
		fire.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		fire.GetComponent<TilemapCollider2D>().usedByComposite = true;

		for(int i = 1; i < 3; i++) {
			for(int j = 1; j< 3; j++) {
				fire.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), fireTile);
			}
		}
	}
}
