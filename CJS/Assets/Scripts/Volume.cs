using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


// audio mixer, audio source, slider combination influenced by https://gamedevbeginner.com/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/
public class Volume : MonoBehaviour
{
    public AudioMixer mixer;

    public void setVol(float vol) {
        mixer.SetFloat("vol", Mathf.Log10(vol) * 20);
    }
}
