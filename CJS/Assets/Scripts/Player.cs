using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player: AnimatedTileEntity {
	public int coins = 0;
	public int levelCoins = 0;
	public int lives = 3;
	private Rigidbody2D rb;
	public float range = 3;
	public float speed = 3;
	public UnityEvent die;
	private PlayerParticle emitter;
	private float maxShootDelay = 0.5f;
	private float shootDelay;
	private float colRadius = 0.3f;
	private bool paused = false;
	private AudioClip throwSfx;
	private AudioSource source;

	new protected void Start() {
		base.Start();
		sprites = Resources.LoadAll<Sprite>("Sprites/player");
		sr.sprite = sprites[0];
		delay = 5;
		StartCoroutine(Animate());
		c = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
		((CircleCollider2D) c).radius = colRadius;
		rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		gameObject.tag = "Player";
		gameObject.layer = LayerMask.NameToLayer("Player");
		shootDelay = maxShootDelay;
		source = GameObject.Find("SfxSource").GetComponent<AudioSource>();
		throwSfx = Resources.Load<AudioClip>("SoundEffects/throwSFX");
		emitter = new GameObject("Emitter", typeof(PlayerParticle)).GetComponent<PlayerParticle>();
		emitter.transform.SetParent(transform);
		emitter.transform.rotation = transform.rotation * Quaternion.AngleAxis(180, Vector3.forward);
		emitter.SetPos(new Vector3(transform.position.x, transform.position.y, z + 1));
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
		if (Input.GetButtonDown("Cancel")) paused = !paused;
		if (paused) return;

		if (emitter.ps && emitter.ps.isStopped && (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)) {
			emitter.ps.Play();
		} else if (emitter.ps && emitter.ps.isPlaying && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0) {
			emitter.ps.Stop();
		}

		Vector3 pos = Vector3.Normalize(Vector3.up * Input.GetAxisRaw("Vertical") + Vector3.right * Input.GetAxisRaw("Horizontal")) * Time.deltaTime * speed;
		List<Collider2D> cols = new List<Collider2D>();
		ContactFilter2D filter = new ContactFilter2D();
		filter.SetDepth(2, 2);
		Physics2D.OverlapCircle(transform.position + new Vector3(0, pos.y, 0), colRadius, filter, cols);
		Vector3 finalPos = Vector3.zero;
		if (cols.Count == 0) finalPos += new Vector3(0, pos.y, 0);
		cols.Clear();
		Physics2D.OverlapCircle(transform.position + new Vector3(pos.x, 0, 0), colRadius, filter, cols);
		if (cols.Count == 0) finalPos += new Vector3(pos.x, 0, 0);
		transform.Translate(finalPos, Space.World);

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

		if (shootDelay < maxShootDelay) shootDelay += Time.deltaTime;

		if(Input.GetButton("Fire1") && shootDelay >= maxShootDelay) {
			source.PlayOneShot(throwSfx);
			GameObject snowball = new GameObject("Snowball", typeof(Snowball));
			snowball.transform.SetParent(level.transform);
			Snowball sb = snowball.GetComponent<Snowball>();
			sb.z = z - 1;
			sb.end = transform.position + Vector3.Normalize(transform.up) * range;
			sb.SetRawPos(transform.position + transform.up * 0.2f);
			shootDelay = 0;
		}
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Fire") die.Invoke();
	}
}
