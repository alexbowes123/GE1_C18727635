
using System.Collections;
using System.Collections.Generic;
// using UnityEngine.Audio;
using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour {

    //defint audio source
    //define audio listener

    public AudioSource myAudio;
    // myAudio = GetComponent<AudioSource>();

     void Start()
    {
        // How do you 'fetch' the audio?
        // After fetching the audio, what function will you call?
        myAudio.Play();
    }

    // void AudioTrigger()
    // {
    //     StartCoroutine(audioCoroutine());
    // }

    // IEnumerator audioCoroutine()
    // {
    //     // How do you wait for 5 seconds?
    //     // How do you play the audio file?

    //     AudioTrigger();
    // }
}
