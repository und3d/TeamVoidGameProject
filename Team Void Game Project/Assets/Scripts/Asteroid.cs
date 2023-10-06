using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float size;
    public float speed;

    public float[] asteroidSizes = { 0.6f, 1f, 1.4f };
    public int[] asteroidSpeeds = { 10, 7, 4 };
    public float maxLifeTime = 30.0f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        /*
        transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)));
        transform.localScale = Vector3.one * size;

        _rigidbody.velocity = transform.up * speed;
        */
    }

    public void SetVariables(Vector2 direction, int speed, float size, int type)
    {
        //_rigidbody.mass = size * type * 5;

        _rigidbody.AddForce(direction * speed);
        transform.localScale = Vector3.one * size;

        Destroy(this.gameObject, this.maxLifeTime);
    }

    //Collision between Asteroid and Bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
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