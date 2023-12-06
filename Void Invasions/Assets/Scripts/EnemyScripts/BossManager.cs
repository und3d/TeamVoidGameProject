using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    public int bossHealth = 100;
    public int spawnRate = 5;
    public GameObject asteroidLauncher;
    public Text healthText;
    public GameObject player;
    public Asteroid asteroidPrefab;

    int asteroidType;

    private void Awake()
    {
        UpdateHealthText();
        InvokeRepeating(nameof(SpawnAsteroid), spawnRate, spawnRate);

    }

    void SpawnAsteroid()
    {
        asteroidType = Random.Range(0, 3);
        Quaternion rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.zero);

        Asteroid asteroid = Instantiate(this.asteroidPrefab, asteroidLauncher.transform.position, rotation);

        asteroid.size = asteroid.asteroidSizes[asteroidType];

        asteroid.transform.position = asteroidLauncher.transform.position;

        Vector2 playerPosition = player.transform.position;
        Vector2 asteroidPosition = asteroid.transform.position;
        Vector2 asteroidToPlayer = playerPosition - asteroidPosition;

        asteroid.SetVariables(asteroidToPlayer, asteroid.asteroidSpeeds[asteroidType], asteroid.asteroidSizes[asteroidType], asteroidType);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Collision");
            if (bossHealth > 1)
            {
                bossHealth -= 2;
                UpdateHealthText();
                Debug.Log(bossHealth);
                Destroy(other.gameObject);
            }
            else
            {
                HighScoreManager.Instance.nextBossScore = HighScoreManager.Instance.currScore + HighScoreManager.Instance.bossScoreInterval;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            }
        }
        
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + bossHealth;
    }
}
