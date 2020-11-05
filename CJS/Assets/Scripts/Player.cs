using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: AnimatedTileEntity {
	public int coins = 0;
	public int levelCoins = 0;
	public int lives = 3;
	private Rigidbody2D rb;
	public float range = 3;
	public float speed = 3;
	public StatsDisplay coinsText;
	public StatsDisplay livesText;
	private float maxShootDelay = 0.5f;
	private float shootDelay;

	new protected void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/player");
		sr.sprite = sprites[0];
		delay = 5;
		StartCoroutine(Animate());
		c = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
		((CircleCollider2D) c).radius = 0.3f;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		gameObject.tag = "Player";
		gameObject.layer = LayerMask.NameToLayer("Player");
		shootDelay = maxShootDelay;
	}

	new protected IEnumerator Animate() {
		while (true) {
			spriteIndex = ++spriteIndex % sprites.Length;
			sr.sprite = sprites[spriteIndex];
			if (spriteIndex == 0) {
				yield return new WaitForSeconds(0.2f);
				continue;
			}
			yield return new WaitForSeconds(delay);
		}
	}

	private void Update() {
		Vector3 move = Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
		transform.Translate(Vector3.Normalize(move) * Time.deltaTime * speed, Space.World);

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

		if (shootDelay < maxShootDelay) shootDelay += Time.deltaTime;

		if(Input.GetMouseButtonDown(0) && shootDelay >= maxShootDelay) {
			GameObject snowball = new GameObject("Snowball", typeof(Snowball));
			Snowball sb = snowball.GetComponent<Snowball>();
			sb.z = z - 1;
			sb.end = transform.position + Vector3.Normalize(transform.up) * range;
			sb.SetRawPos(transform.position + transform.up * 0.2f);
			shootDelay = 0;
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

	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Fire") Debug.Log("dead");
	}
}
