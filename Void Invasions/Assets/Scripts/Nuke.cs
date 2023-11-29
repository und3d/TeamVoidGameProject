using UnityEngine;

public class Nuke : MonoBehaviour
{
    private bool isNukeActive = false;
    private float nukeDuration = 20.0f;
    private float nukeStartTime;

    // Reference to the ScoreManager
    public ScoreManager scoreManager;

    void Start()
    {
        // Set the nuke start time
        Invoke(nameof(ActivateNuke), 15f);
    }

    void Update()
    {
        // Check if the nuke is active based on the duration
        if (isNukeActive && Time.time - nukeStartTime > nukeDuration)
        {
            isNukeActive = false;
            DestroyAsteroids();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the power-up for the nuke
  
   
    }

    void ActivateNuke()
    {
        // Set the nuke start time 
        nukeStartTime = Time.time;
        isNukeActive = true;

        // Add points to the player's score when the nuke is activated
        int pointsToAdd = 1000; // You can change this to any amount you want
        scoreManager.AddPoints(pointsToAdd);

        // Destroy asteroids 
        DestroyAsteroids();
    }

    void DestroyAsteroids()
    {
        // Find all game objects with the Asteroid tag and destroy them
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        
        for (int i = 0; i < asteroids.Length; i++)
        {
            Destroy(asteroids[i]);
        }
    }
}
