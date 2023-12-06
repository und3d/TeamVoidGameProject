using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAsteroid : MonoBehaviour
{
    public float speed;
    public int score = 0;
    public int goldScore = 500;
    public int type;

    public Vector2 astDirection;

    public float asteroidSize = 1f;
    public int asteroidSpeed = 7;
    public float maxLifeTime = 30.0f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    radiusCollisions radius;
    int tempScore;

    public Sprite redAsteroid;
    public Sprite goldAsteroid;
    public Sprite iceAsteroid;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        speed = 7;
    }

    //Variables set in the spawner script
    public void SetVariables(Vector2 direction, int setType)
    {
        astDirection = direction;
        _rigidbody.AddForce(direction * speed);         //Sets the speed of the asteroid
        type = setType;
        score = 50;
        SetSprite();
        if (type == 0 || type == 2)
        {
            radius = transform.GetChild(0).gameObject.GetComponent<radiusCollisions>();
        }

        Destroy(gameObject, maxLifeTime);     //Destroys asteroid after specified amount of time
    }

    void SetSprite()
    {
        switch (type)
        {
            case 0:
                _spriteRenderer.sprite = redAsteroid;
                break;
            case 1:
                _spriteRenderer.sprite = goldAsteroid;
                break;
            case 2:
                _spriteRenderer.sprite = iceAsteroid;
                break;
        }
    }

    //Collision between Asteroid and Bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            switch (type)
            {
                case 0:     //red
                    scoreManager.AddPoints(score);
                    if (radius.ObjsInRadius.Count > 1)
                    {
                        for (int i = 1; i < radius.ObjsInRadius.Count; i++)
                        {
                            GameObject obj = radius.ObjsInRadius[i];
                            switch (obj.tag)
                            {
                                case "Asteroid":            //Controls destroy sequence for asteroids in radius
                                    if (obj.GetComponent<Asteroid>() != null)   //if normal asteroid
                                    {
                                        switch (obj.GetComponent<Asteroid>().type)
                                        {
                                            case 0:
                                                tempScore = 75;
                                                break;
                                            case 1:
                                                tempScore = 50;
                                                break;
                                            case 2:
                                                tempScore = 25;
                                                break;
                                        }
                                        scoreManager.AddPoints(tempScore);
                                        Destroy(obj);
                                    }
                                    else if (obj.GetComponent<SpecialAsteroid>() != null)   //if special asteroid
                                    {
                                        scoreManager.AddPoints(score);
                                        Destroy(obj);
                                    }
                                    break;
                                case "Player":            //Controls destroy sequence if the player is in radius
                                    obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                                    obj.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
                                    obj.GetComponent<PlayerControls>().isAlive = false;
                                    obj.gameObject.SetActive(false);

                                    obj.GetComponent<PlayerControls>().gameManager.PlayerDied();
                                    SFX.Instance?.PlayerDeath();
                                    break;
                            }
                        }
                        radius.ObjsInRadius.Clear();
                    }
                    break;
                case 1:     //gold
                    scoreManager.AddPoints(goldScore);
                    break;
                case 2:     //ice
                    scoreManager.AddPoints(score);
                    if (radius.ObjsInRadius.Count > 1)
                    {
                        for (int i = 1; i < radius.ObjsInRadius.Count; i++)
                        {
                            GameObject obj = radius.ObjsInRadius[i];
                            switch (obj.tag)
                            {
                                case "Asteroid":            //Controls freeze sequence for asteroids in radius
                                    obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                                    break;
                                case "Player":            //Does nothing to player
                                    break;
                            }
                        }
                        radius.ObjsInRadius.Clear();
                    }
                    break;
            }

            SFX SFXManager = SFX.Instance;
            if (SFXManager != null)
            {
                SFXManager.AsteroidExplosion();
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    
}
