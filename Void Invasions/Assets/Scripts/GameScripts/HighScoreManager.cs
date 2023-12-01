using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance { get; private set; }
    public AudioClip shootSFX;
    public AudioClip deathSFX;
    public AudioClip explosionSFX;

    AudioSource audioSource;

    public int Highscore;

    public bool bouncyActive;
    public bool doubleActive;
    public bool instaKillActive;
    public bool shieldActive;
    public bool invincActive;
    public bool weaponActive;

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