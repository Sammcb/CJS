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
		sr.sprite = Resources.Load<Sprite>("Sprites/player");
		c = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
		((CircleCollider2D) c).radius = 0.3f;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		gameObject.tag = "Player";
		gameObject.layer = LayerMask.NameToLayer("Player");
	}

	private void Update() {
		Vector3 move = Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
		transform.Translate(Vector3.Normalize(move) * Time.deltaTime * speed, Space.World);

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

		if(Input.GetMouseButtonDown(0)) {
			GameObject snowball = new GameObject("Snowball", typeof(Snowball));
			snowball.transform.position = transform.position;
			snowball.GetComponent<Snowball>().end = transform.position + Vector3.Normalize(transform.up) * range;
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
