using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataBus: MonoBehaviour {
	public int maxIgloos = 0;
	public int igloosSaved = 0;
	public int maxSeals = 0;
	public int sealsSaved = 0;

	private void Update() {
		if (SceneManager.GetActiveScene().name == "ColdWin") {
			Debug.Log(maxIgloos);
			Debug.Log(igloosSaved);
			TMPro.TextMeshProUGUI epilogue = GameObject.Find("Epilogue").GetComponent<TMPro.TextMeshProUGUI>();
			epilogue.text = "Or did you? The princess is horrified you only saved " + igloosSaved + "/" + maxIgloos + " igloos and " + sealsSaved + "/" + maxSeals + " pet seals. She breaks up with you. Do better next time.";
		}
		if (SceneManager.GetActiveScene().name != "Game") Destroy(gameObject);
	}
}
