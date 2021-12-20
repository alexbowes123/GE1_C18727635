
using System.Collections;
using System.Collections.Generic;
// using UnityEngine.Audio;
using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour {



    public AudioSource myAudio;
    // myAudio = GetComponent<AudioSource>();

     void Start()
    {
        myAudio.Play();
    }
}
