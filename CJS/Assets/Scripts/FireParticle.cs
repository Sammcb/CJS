using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle: MonoBehaviour {
	private ParticleSystem ps;

	private void Start() {
		ps = gameObject.AddComponent(typeof(ParticleSystem)) as ParticleSystem;
		var main = ps.main;
		main.startLifetime = 0.5f;
		main.simulationSpeed = 0.3f;
		main.startSize = 0.2f;
		var renderer = ps.GetComponent<Renderer>();
		renderer.material = Resources.Load<Material>("Particles/whisp");
		var shape = ps.shape;
		// shape.scale = new Vector3(0.5f, 0.5f, 1);
		float arc = 40;
		shape.arc = arc;
		shape.rotation = new Vector3(0, 0, 90 - arc / 2);
		// var size = ps.sizeOverLifetime;
		// size.enabled = true;
		// AnimationCurve sizeCurve = new AnimationCurve();
		// sizeCurve.AddKey(0, 0.1f);
		// sizeCurve.AddKey(1, 0.5f);
		// size.size = new ParticleSystem.MinMaxCurve(1, sizeCurve);
	}

	public void SetPos(Vector3 pos) {
		transform.position = pos;
	}
}
