using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioData;


    /**
     * Starts audio.
     **/
    public void startAudio()
    {
        audioData = GetComponent<AudioSource>();
        audioData.enabled = true;
        audioData.Play(0);
    }
}
