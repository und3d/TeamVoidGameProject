using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance { get; private set; }
    public AudioClip shootSFX;
    public AudioClip deathSFX;
    public AudioClip explosionSFX;

    AudioSource audioSource;

    public int Highscore;
    public int currScore;
    public int totalLives = 3;
    public int currLives;
    public float shootDelay = 0.5f;

    public int pointPerAsteroid = 50;

    public bool bouncyActive;
    public bool doubleActive;
    public bool instaKillActive;
    public bool shieldActive;
    public bool invincActive;
    public bool autoWeaponActive;
    public bool shotgunWeaponActive;
    public float upgradeDuration = 20;

    public bool buttonPressed = false;

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

    public void DeactivateDouble()
    {
        Invoke(nameof(TurnOffDouble), upgradeDuration);
    }

    public void TurnOffDouble()
    {
        Debug.Log("Deactivate Double");
        doubleActive = false;
    }

    public void DeactivateBouncy()
    {
        Invoke(nameof(TurnOffBouncy), upgradeDuration);
    }

    public void TurnOffBouncy()
    {
        Debug.Log("Deactivate Bouncy");
        bouncyActive = false;
    }

    public void DeactivateAutoWeapon()
    {
        Invoke(nameof(TurnOffAutoWeapon), upgradeDuration);
    }

    public void TurnOffAutoWeapon()
    {
        Debug.Log("Deactivate Auto Weapon");
        autoWeaponActive = false;
    }

    public void DeactivateShotgunWeapon()
    {
        Invoke(nameof(TurnOffShotgunWeapon), upgradeDuration);
    }

    public void TurnOffShotgunWeapon()
    {
        Debug.Log("Deactivate Shotgun Weapon");
        shotgunWeaponActive = false;
    }

    public void DeactivateInvinc()
    {
        Invoke(nameof(TurnOffInvinc), upgradeDuration);
    }

    public void TurnOffInvinc()
    {
        Debug.Log("Deactivate Invinc");
        invincActive = false;
    }

    public void DeactivateInsta()
    {
        Invoke(nameof(TurnOffInsta), upgradeDuration);
    }

    public void TurnOffInsta()
    {
        Debug.Log("Deactivate Insta");
        instaKillActive = false;
    }

    public void NewGame()
    {
        currLives = totalLives;
        currScore = 0;

        SceneManager.LoadScene("Game");
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