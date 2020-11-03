using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: TileEntity {
	public int coins = 0;
	public int levelCoins = 0;
	public int lives = 3;
	private Rigidbody2D rb;
	public float range = 3;
	public float speed = 3;
	public StatsDisplay coinsText;
	public StatsDisplay livesText;

	new protected void Start() {
		base.Start();
		sr.sprite = Resources.Load<Sprite>("Sprites/Circle");
		c = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		gameObject.tag = "Player";
		gameObject.layer = LayerMask.NameToLayer("Player");
	}

	private void Update() {
		Vector3 move = Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
		transform.Translate(Vector3.Normalize(move) * Time.deltaTime * speed);

		if(Input.GetMouseButtonDown(0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 dir = pos - transform.position;
			dir.z = 0;
			GameObject water = new GameObject("Water", typeof(Water));
			water.transform.position = transform.position;
			water.GetComponent<Water>().end = transform.position + Vector3.Normalize(dir) * range;
		}

	}

	public void PickupCoin() {
		coinsText = GameObject.Find("Coins").GetComponent<StatsDisplay>();
		levelCoins++;
		Debug.Log("updating coins to ... " + (coins + levelCoins));
		coinsText.UpdateText(coins + levelCoins);
	}

	public void LoseLife() {
		livesText = GameObject.Find("Lives").GetComponent<StatsDisplay>();
		lives--;
		Debug.Log("updating lives to ... " + lives);
		livesText.UpdateText(lives);
	}

	public void UpdateText() {
		coinsText = GameObject.Find("Coins").GetComponent<StatsDisplay>();
		livesText = GameObject.Find("Lives").GetComponent<StatsDisplay>();
		coinsText.UpdateText(coins);
		livesText.UpdateText(lives);
	}

}
