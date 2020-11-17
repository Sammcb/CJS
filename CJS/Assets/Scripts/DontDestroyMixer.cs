using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DontDestroyMixer : MonoBehaviour
{
    public AudioMixer sfxMixer;
    public AudioMixer musicMixer;

    void Awake()
    {
        DontDestroyOnLoad(sfxMixer);
        DontDestroyOnLoad(musicMixer);
        DontDestroyOnLoad(gameObject);
    }
}
