﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouseParticle: MonoBehaviour {
	private ParticleSystem ps;

	private void Start() {
		ps = gameObject.AddComponent(typeof(ParticleSystem)) as ParticleSystem;
		var main = ps.main;
		main.loop = false;
		ps.Stop();
		main.duration = 0.4f;
		ps.Play();
		main.startLifetime = 0.3f;
		main.startSize = 0.7f;
		var renderer = ps.GetComponent<Renderer>();
		renderer.material = Resources.Load<Material>("Particles/particle");
		var tsa = ps.textureSheetAnimation;
		tsa.enabled = true;
		tsa.mode = ParticleSystemAnimationMode.Sprites;
		tsa.SetSprite(0, Resources.Load<Sprite>("Particles/steam"));
		var shape = ps.shape;
		float arc = 40;
		shape.arc = arc;
		shape.rotation = new Vector3(0, 0, 90 - arc / 2);
	}

	public void SetPos(Vector3 pos) {
		transform.position = pos;
	}

	public void Update() {
		if (ps.isStopped) Destroy(gameObject);
	}
}
