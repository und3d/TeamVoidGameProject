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
        Debug.Log("Asteroid splitting with type: " + asteroidScript.type);

        // check the type of the current asteroid and spawn smaller asteroids accordingly.
        switch (asteroidScript.type)
        {
            case 2:  // large asteroid
                CreateAsteroid(1);
                CreateAsteroid(1);
                break;

            case 1:  // medium asteroid
                CreateAsteroid(0);
                CreateAsteroid(0);
                break;
        }
    }

    // function to create a new asteroid.
    private void CreateAsteroid(int newType)
    {
        // debug
        // Debug.Log("Creating Asteroid with intended type: " + newType);

        // Generate a random offset to space the newly split asteroids apart a bit.
        Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);

        // instantiate a new asteroid using the prefab, then get the script from newly instantiateed asteroid -> set it's properties as well
        GameObject newAsteroid = Instantiate(asteroidPrefab, transform.position + randomOffset, Quaternion.identity);
        Asteroid asteroidScript = newAsteroid.GetComponent<Asteroid>();
        asteroidScript.SetAsteroidProperties(newType);

        // randomly rotate the new asteroid (fun variation lol)
        newAsteroid.transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)));

        // set the velocity of the new asteroid so it moves in the direction it's facing
        Rigidbody2D _rigidbody = newAsteroid.GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(newAsteroid.transform.up * asteroidScript.asteroidSpeeds[newType] * 5);
        
    }
}
