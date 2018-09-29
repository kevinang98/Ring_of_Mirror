using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

    private AudioSource audio;
    public AudioClip music1;
    public AudioClip music2;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (FindObjectOfType<Movement>().enemy == true)
        {
            audio.Stop();
            audio.loop = true;
            audio.PlayOneShot(music2);
        }
        if (FindObjectOfType<Movement>().enemy == false)
        {
            audio.Stop();
            audio.loop = true;
            audio.PlayOneShot(music1);
        }
    }
}