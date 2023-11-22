using UnityEngine;

public class Nuke : MonoBehaviour
{
    private bool nukeActive = false;
    private float nukeStartTime;

    void Start()
    {
        nukeStartTime = -1.0f; // Set the nuke start time to -1 to indicate it's not active initially
    }

    void Update()
    {
        if (Time.time <= nukeStartTime + 20.0f)
        {
            nukeActive = true; // Activate the nuke
        }
        else
        {
            nukeActive = false; // Deactivate the nuke
        }

        if (nukeActive)
        {
            DestroyAsteroids();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PowerUpNuke")
        {
            nukeStartTime = Time.time; // Activate the nuke when it collides 
            Destroy(other.gameObject); 
        }
    }

    void DestroyAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
        }
    }
}

