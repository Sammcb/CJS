using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenMenu: MonoBehaviour {
	public void PlayGame() {
		SceneManager.LoadScene("Game");
	}

	public void QuitGame() {
		Debug.Log("Quitting");
		Application.Quit();
	}
    
    public void BackToStart() {
        SceneManager.LoadScene("StartScreen");
    }
}
