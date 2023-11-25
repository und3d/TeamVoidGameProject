using System.Collections.Generic;
using UnityEngine;

public class PiercingBullet : MonoBehaviour
{
    public int maxPierceCount = 1; 
    private int pierceCount = 0;
    private List<Asteroid> collidedAsteroids = new List<Asteroid>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();

        if (asteroid != null && !HasCollided(asteroid))
        {
            HandleAsteroidCollision(asteroid);
        }
    }

    private void HandleAsteroidCollision(Asteroid asteroid)
    {
        if (pierceCount < maxPierceCount && !HasCollided(asteroid))
        {
            pierceCount++;
            collidedAsteroids.Add(asteroid);

            // Handle asteroid collision
            Destroy(gameObject);
            

            // Add the fragments of the asteroid to prevent recollisions
            List<Asteroid> asteroidFragments = asteroid.GetFragments(); 
            foreach (var fragment in asteroidFragments)
            {
                collidedAsteroids.Add(fragment);
            }
        }
        else
        {
            // Destroy the bullet
            Destroy(gameObject);
        }
    }

    private bool HasCollided(Asteroid asteroid)
    {
        // Check if the bullet has collided with this asteroid
        return collidedAsteroids.Contains(asteroid);
    }
}
