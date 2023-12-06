using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float size;
    public float speed;
    public int score = 0;
    public int type;

    private bool isInitialized = false;
    public Vector2 astDirection;

    public float[] asteroidSizes = { 0.6f, 1f, 1.4f };
    public int[] asteroidSpeeds = { 10, 7, 4 };
    public float maxLifeTime = 30.0f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetAsteroidProperties(int newType)
    {
        SetVariables(astDirection, asteroidSpeeds[newType], asteroidSizes[newType], newType);
    }

    //Variables set in the spawner script
    public void SetVariables(Vector2 direction, int speed, float size, int setType)
    {
        astDirection = direction;
        _rigidbody.AddForce(direction * speed);         //Sets the speed of the asteroid
        transform.localScale = Vector3.one * size;      //Sets the size of the asteroid based on it's type (determined in spawner script)
        isInitialized = true;
        type = setType;

        Destroy(gameObject, maxLifeTime);     //Destroys asteroid after specified amount of time
    }

    //Collision between Asteroid and Bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (!HighScoreManager.Instance.instaKillActive)
            {
                TempAsteroidSplitting splittingScript = GetComponent<TempAsteroidSplitting>();
                if (splittingScript != null)
                {
                    splittingScript.SplitAsteroid();
                }
            }

            SFX SFXManager = SFX.Instance;
            if (SFXManager != null)
            {
                SFXManager.AsteroidExplosion();
            }

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                switch(type)
                {
                    case 0:
                        score = 75;
                        break;
                    case 1:
                        score = 50;
                        break;
                    case 2:
                        score = 25;
                        break;
                }
                scoreManager.AddPoints(score);
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}