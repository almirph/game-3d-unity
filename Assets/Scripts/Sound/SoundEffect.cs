using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static SoundEffect current;
    private static AudioSource soundPlayer;

    private void Start()
    {
        if (!current)
        {
            current = this;
            soundPlayer = gameObject.GetComponent<AudioSource>();
        }
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        soundPlayer.PlayOneShot(audioClip);
    }

}
