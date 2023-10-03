using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Asteroid))]
public class TempAsteroidSplitting : MonoBehaviour
{
    public GameObject asteroidPrefab;

    private Asteroid asteroid;

    private Asteroid asteroidScript;

    private void Start()
    {
        asteroidScript = GetComponent<Asteroid>();
        if (asteroidScript == null)
        {
            Debug.LogError("Asteroid script not found on " + gameObject.name);
        }
    }

    public void SplitAsteroid()
    {
        Asteroid asteroidScript = GetComponent<Asteroid>();


        Debug.Log("Asteroid splitting with size: " + asteroidScript.size);
        if (asteroidScript.size == 1.4f)
        {
            CreateAsteroid(1.15f);
            CreateAsteroid(1.15f);
        }
        else if (asteroidScript.size == 1.15f)
        {
            CreateAsteroid(0.75f);
            CreateAsteroid(0.75f);
        }
    }

    private void CreateAsteroid(float newSize)
    {
        Debug.Log("Creating Asteroid with intended size: " + newSize);

        // Add a small random offset to the position to space the asteroids apart.
        Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
        GameObject newAsteroid = Instantiate(asteroidPrefab, transform.position + randomOffset, Quaternion.identity);


        Asteroid asteroidScript = newAsteroid.GetComponent<Asteroid>();
        if (newSize == 1.15f)
        {
            asteroidScript.type = 1;
        }
        else if (newSize == 0.75f)
        {
            asteroidScript.type = 0;
        }
        asteroidScript.size = newSize;
        asteroidScript.speed = asteroidScript.asteroidSpeeds[asteroidScript.type];

        newAsteroid.transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)));
        newAsteroid.transform.localScale = Vector3.one * newSize;

        Rigidbody2D _rigidbody = newAsteroid.GetComponent<Rigidbody2D>();
        _rigidbody.velocity = newAsteroid.transform.up * asteroidScript.speed;
    }
}
