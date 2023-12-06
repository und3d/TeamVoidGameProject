using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public SpecialAsteroid sAsteroidPrefab;
    public Sprite circle;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public int spawnAmount = 2;
    public float spawnDistance = 13.0f;
    public int asteroidType;
    int coinFlip;
    bool isSpecial;
    int specialType;

    Vector3 spawnDirection;
    Vector3 spawnPoint;
    float variance;
    Quaternion rotation;
    Asteroid asteroid;
    SpecialAsteroid sAsteroid;
    public GameObject childRadius;
    GameObject radius;
    SpriteRenderer radiusSprite;
    CircleCollider2D radiusCollider;

    private void Start()
    {
        //Repeatedly spawns asteroids at a rate of spawnRate
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        //spawns a specified # of asteroids
        for (int i = 0; i < this.spawnAmount; i++)
        {
            coinFlip = Random.Range(1, 3);
            if (coinFlip == 1)
            {
                specialType = Random.Range(0, 3);      //sets the asteroid type (0 = Gold, 1 = Red, 2 = Ice)
                switch (specialType)
                {
                    case 0:
                        AsteroidSetup();

                        sAsteroid = Instantiate(sAsteroidPrefab, spawnPoint, rotation);
                        radius = Instantiate(childRadius, sAsteroid.transform);
                        sAsteroid.SetVariables(rotation * -spawnDirection, specialType);
                        
                        break;
                    case 1:
                        AsteroidSetup();

                        sAsteroid = Instantiate(sAsteroidPrefab, spawnPoint, rotation);
                        sAsteroid.SetVariables(rotation * -spawnDirection, specialType);

                        break;
                    case 2:
                        AsteroidSetup();

                        sAsteroid = Instantiate(sAsteroidPrefab, spawnPoint, rotation);
                        radius = Instantiate(childRadius, sAsteroid.transform);
                        sAsteroid.SetVariables(rotation * -spawnDirection, specialType);

                        break;
                }
            }
            else if (coinFlip == 2)
            {
                AsteroidSetup();

                asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);     //creates the asteroid

                asteroid.size = asteroid.asteroidSizes[asteroidType];       //sets the asteroid's size based on it's type

                //Sets variables to be modified in the Asteroid Script
                asteroid.SetVariables(rotation * -spawnDirection, asteroid.asteroidSpeeds[asteroidType], asteroid.asteroidSizes[asteroidType], asteroidType);
            }
        }
    }

    void AsteroidSetup()
    {
        asteroidType = Random.Range(0, 3);      //sets the asteroid type (0 = small, 1 = medium, 2 = large)
        spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;   //Sets the direction of travel of the asteroid using a specified diameter unit circle around the origin
        spawnPoint = this.transform.position + spawnDirection;      //sets spawn direction using same unit circle

        variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);       //Adds an offset to the trajectory so that it doesn't go directly to origin
        rotation = Quaternion.AngleAxis(variance, Vector3.forward);          //rotates the asteroid so it has some variety
    }
}
