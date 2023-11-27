using UnityEngine;

public class Nuke : MonoBehaviour
{
    private bool isNukeActive = false;
    private float nukeDuration = 20.0f;
    private float nukeStartTime;

    void Start()
    {
        // Set the nuke start time to the current time to make it active from the start
        nukeStartTime = Time.time;
    }

    void Update()
    {
        // Check if the nuke is active based on the duration
        isNukeActive = Time.time <= nukeStartTime + nukeDuration;

        // If the nuke is active, destroy asteroids
        if (isNukeActive)
        {
            DestroyAsteroids();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the power-up for the nuke
        if (other.CompareTag("PowerUpNuke"))
        {
            // Activate the nuke and set the start time
            ActivateNuke();
            Destroy(other.gameObject); // Destroy the power-up
        }
    }

    void ActivateNuke()
    {
        // Set the nuke start time to the current time
        nukeStartTime = Time.time;
    }

    void DestroyAsteroids()
    {
        // Find all game objects with the "Asteroid" tag and destroy them
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
        }
    }
}
