using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public int spawnAmount = 2;
    public float spawnDistance = 13.0f;
    public int asteroidType;

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
            asteroidType = Random.Range(0, 3);      //sets the asteroid type (0 = small, 1 = medium, 2 = large)
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;   //Sets the direction of travel of the asteroid using a specified diameter unit circle around the origin
            Vector3 spawnPoint = this.transform.position + spawnDirection;      //sets spawn direction using same unit circle

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);       //Adds an offset to the trajectory so that it doesn't go directly to origin
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);          //rotates the asteroid so it has some variety

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);     //creates the asteroid

            asteroid.size = asteroid.asteroidSizes[asteroidType];       //sets the asteroid's size based on it's type

            //Sets variables to be modified in the Asteroid Script
            asteroid.SetVariables(rotation * -spawnDirection, asteroid.asteroidSpeeds[asteroidType], asteroid.asteroidSizes[asteroidType], asteroidType);
        }
    }
}
