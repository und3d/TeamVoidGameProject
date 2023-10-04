using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Asteroid))]
public class TempAsteroidSplitting : MonoBehaviour
{
    public GameObject asteroidPrefab;
    private Asteroid asteroidScript;

    private void Start()
    {
        // get the asteroid script attached to the current gameobject
        asteroidScript = GetComponent<Asteroid>();

        // Log an error if the asteroid script is not found
        if (asteroidScript == null)
        {
            Debug.LogError("Asteroid script not found on " + gameObject.name);
        }
    }

    // Function to handle the asteroid splitting 
    public void SplitAsteroid()
    {
        // simple debug log for the current asteroid's size before splitting.
        Debug.Log("Asteroid splitting with size: " + asteroidScript.size);

        // check the size of the current asteroid and spawn smaller asteroids accordingly.
        if (asteroidScript.size == 1.4f) // if it's a large asteroid.
        {
            CreateAsteroid(1.15f); 
            CreateAsteroid(1.15f); 
        }
        else if (asteroidScript.size == 1.15f) // If it's a medium asteroid.
        {
            CreateAsteroid(0.75f);
            CreateAsteroid(0.75f);
        }
    }

    // function to create a new asteroid.
    private void CreateAsteroid(float newSize)
    {
        // Log the intended size for the new asteroid.
        Debug.Log("Creating Asteroid with intended size: " + newSize);

        // Generate a random offset to space the newly split asteroids apart a bit.
        Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);

        // Instantiate a new asteroid using the prefab.
        GameObject newAsteroid = Instantiate(asteroidPrefab, transform.position + randomOffset, Quaternion.identity);

        // Get the Asteroid script from the newly instantiated asteroid.
        Asteroid asteroidScript = newAsteroid.GetComponent<Asteroid>();

        // Determine the type of the asteroid based on its size and set its properties accordingly.
        if (newSize == 1.4f)
        {
            asteroidScript.SetAsteroidProperties(2); // large asteroid.
        }
        else if (newSize == 1.15f)
        {
            asteroidScript.SetAsteroidProperties(1); // medium asteroid.
        }
        else if (newSize == 0.75f)
        {
            asteroidScript.SetAsteroidProperties(0); // small asteroid.
        }

        // randomly rotate the new asteroid (fun variation lol)
        newAsteroid.transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)));

        // set the velocity of the new asteroid so it moves in the direction it's facing
        Rigidbody2D _rigidbody = newAsteroid.GetComponent<Rigidbody2D>();
        _rigidbody.velocity = newAsteroid.transform.up * asteroidScript.speed;
    }
}
