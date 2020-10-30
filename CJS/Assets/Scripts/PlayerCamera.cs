using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera: MonoBehaviour {
	public GameObject target;

	private void Update() {
		if (target == null) return;
		transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z), 0.1f);
	}
}
