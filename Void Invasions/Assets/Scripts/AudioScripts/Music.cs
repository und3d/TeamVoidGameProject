using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Instance { get; private set; }
    AudioSource audioSource;
    public AudioClip music;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //InvokeRepeating(nameof(PlayMusic), 0, music.length - 3);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void PlayMusic()
    {
        audioSource.PlayOneShot(music);
    }
}
