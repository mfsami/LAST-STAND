using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource soundSrc;
    public AudioClip sound;
    void Start()
    {
        soundSrc.clip = sound;
        soundSrc.loop = true;
        soundSrc.Play();
    }

    
}
