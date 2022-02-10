using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource AudioSource;

    private float musicVolume = 1f;


    void Start()
    {
        AudioSource.Play();
    }

    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void updateVolume( float volume)
    {
        musicVolume = volume;
    }
}
