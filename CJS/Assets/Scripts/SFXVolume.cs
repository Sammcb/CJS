using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// audio mixer, audio source, slider combination influenced by https://gamedevbeginner.com/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/
public class SFXVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void Start() {
        float newVol = GameControl.control.sfxVol;
        mixer.SetFloat("vol", newVol);
        GetComponent<Slider>().value = Mathf.Pow(10, (float)(newVol/20));
    }

    public void setVol(float vol) {
        float newVol = Mathf.Log10(vol) * 20;
        mixer.SetFloat("vol", newVol);
        GameControl.control.sfxVol = newVol;
    }
}
