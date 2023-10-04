using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int type;
    public float size;
    public float speed;

    private float[] asteroidSizes = { 0.75f, 1.15f, 1.4f };
    public int[] asteroidSpeeds = { 5, 3, 1 };

    // function to set asteroid properties based on its type.
    public void SetAsteroidProperties(int newType)
    {
        // set the asteroid's type (0 = small, 1 = medium, 2 = large)
        type = newType;

        // Determine the asteroid's size/speed based on type
        size = asteroidSizes[type];
        speed = asteroidSpeeds[type];

        // set the asteroid's scale in the scene based on its size
        transform.localScale = Vector3.one * size;
    }

    private void Start()
    {
        // Randomly determine the asteroid's type upon creation (either 0, 1, or 2)
        type = Random.Range(0, 3);

        // set the asteroid's size/speed based on the randomly determined type
        size = asteroidSizes[type];
        speed = asteroidSpeeds[type];


        Rigidbody2D _rigidbody = GetComponent<Rigidbody2D>();

        // randomly rotate the asteroid for varied appearance
        transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)));

        // adjust the asteroid's scale in the scene based on its size
        transform.localScale = Vector3.one * size;

        // set the asteroid's movement velocity in the direction it's facing
        _rigidbody.velocity = transform.up * speed;
    }

    // Collision between Asteroid and Bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TempAsteroidSplitting splittingScript = GetComponent<TempAsteroidSplitting>();
            if (splittingScript != null)
            {
                splittingScript.SplitAsteroid();
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }


    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Asteroids are only destroyed with bullets.
        if (collision.CompareTag("Bullet"))
        {
            // Register the destruction with the game manager.
            gameManager.asteroidCount--;

            // Destroy the bullet so it doesn't carry on and hit more things.
            Destroy(collision.gameObject);

            // If size > 1 spawn 2 smaller asteroids of size-1.
            if (size > 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    Asteroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
                    newAsteroid.size = size - 1;
                    newAsteroid.gameManager = gameManager;
                    gameManager.asteroidCount += 2;
                }
            }

            // Destroy this asteroid.
            Destroy(gameObject);
        }
    }
    */
}