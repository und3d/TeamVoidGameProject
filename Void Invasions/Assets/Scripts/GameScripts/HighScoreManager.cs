using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance { get; private set; }

    GameObject scoreManager;

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
    public float powerUpDuration = 5;
    public int powerUpSpawnTimer = 20;
    public int nukePoints = 1000;

    public bool buttonPressed = false;

    public int bossCounter = 0;
    public int bossScoreInterval = 1000;
    public int nextBossScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        nextBossScore = bossScoreInterval;
    }

    public void ActivateNuke()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        // Add points to the player's score when the nuke is activated
        scoreManager.GetComponent<ScoreManager>().AddPoints(nukePoints);

        // Find all game objects with the Asteroid tag and destroy them
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        for (int i = 0; i < asteroids.Length; i++)
        {
            Destroy(asteroids[i]);
        }
    }

    public void DeactivateDouble()
    {
        Invoke(nameof(TurnOffDouble), powerUpDuration);
    }

    public void TurnOffDouble()
    {
        Debug.Log("Deactivate Double");
        doubleActive = false;
    }

    public void DeactivateBouncy()
    {
        Invoke(nameof(TurnOffBouncy), powerUpDuration);
    }

    public void TurnOffBouncy()
    {
        Debug.Log("Deactivate Bouncy");
        bouncyActive = false;
    }

    public void DeactivateAutoWeapon()
    {
        Invoke(nameof(TurnOffAutoWeapon), powerUpDuration);
    }

    public void TurnOffAutoWeapon()
    {
        Debug.Log("Deactivate Auto Weapon");
        autoWeaponActive = false;
    }

    public void DeactivateInvinc()
    {
        Invoke(nameof(TurnOffInvinc), powerUpDuration);
    }

    public void TurnOffInvinc()
    {
        Debug.Log("Deactivate Invinc");
        invincActive = false;
    }

    public void DeactivateInsta()
    {
        Invoke(nameof(TurnOffInsta), powerUpDuration);
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
    
}