using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static SFX Instance { get; private set; }
    AudioSource audioSource;
    public AudioClip shootSFX;
    public AudioClip deathSFX;
    public AudioClip explosionSFX;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

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
    public void AsteroidExplosion()
    {
        audioSource.clip = explosionSFX;
        audioSource.PlayOneShot(explosionSFX);
    }

    public void ShootSFX()
    {
        audioSource.clip = shootSFX;
        audioSource.PlayOneShot(shootSFX);
    }

    public void PlayerDeath()
    {
        audioSource.clip = deathSFX;
        audioSource.PlayOneShot(deathSFX);
    }
}
