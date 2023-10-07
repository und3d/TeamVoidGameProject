using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int type;
    public float size;
    public float speed;
    public int score = 0;
    

    private float[] asteroidSizes = { 0.75f, 1.15f, 1.4f };
    private int[] asteroidSpeeds = { 5, 3, 1 };

    private void Start()
    {
        //Asteroid Type
        type = Random.Range(0, 3);
        size = asteroidSizes[type];
        speed = asteroidSpeeds[type];

        Rigidbody2D _rigidbody = GetComponent<Rigidbody2D>();

        transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)));
        transform.localScale = Vector3.one * size;

        _rigidbody.velocity = transform.up * speed;
    }

    //Collision between Asteroid and Bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);

            GamesManager gamesManager = FindObjectOfType<GamesManager>();
            if (gamesManager != null)
            {
                gamesManager.AddPoints(100);
            }
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