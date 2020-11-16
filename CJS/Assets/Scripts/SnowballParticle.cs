using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballParticle: MonoBehaviour {
	public ParticleSystem ps;

	private void Start() {
		ps = gameObject.AddComponent(typeof(ParticleSystem)) as ParticleSystem;
		var main = ps.main;
		main.startLifetime = 0.5f;
		main.simulationSpeed = 1.5f;
		main.simulationSpace = ParticleSystemSimulationSpace.World;
		main.startSize = 0.1f;
		main.startSpeed = 0.2f;
		var render = ps.GetComponent<Renderer>();
		GetComponent<Renderer>().material = Resources.Load<Material>("Particles/particle");
		var tsa = ps.textureSheetAnimation;
		tsa.enabled = true;
		tsa.mode = ParticleSystemAnimationMode.Sprites;
		tsa.SetSprite(0, Resources.Load<Sprite>("Particles/snow"));
		var shape = ps.shape;
		shape.shapeType = ParticleSystemShapeType.Circle;
		shape.radius = 0.1f;
		float arc = 180;
		shape.arc = arc;
		shape.rotation = new Vector3(0, 0, 90 - arc / 2);
	}

	public void SetPos(Vector3 pos) {
		transform.position = pos;
	}
}
