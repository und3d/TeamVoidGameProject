using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int type;
    public float size;
    public float speed;
    public int score = 0;
    

    private bool isInitialized = false;

    private float[] asteroidSizes = { 0.75f, 1.15f, 1.4f };
    public int[] asteroidSpeeds = { 5, 3, 1 };

    private void Awake()
    {
        // If the asteroid is not already initialized, randomize its type.
        if (!isInitialized)
        {
            InitializeAsteroid(Random.Range(0, 3));
        }
    }

    private void Start()
    {
        Rigidbody2D _rigidbody = GetComponent<Rigidbody2D>();

        // randomly rotate the asteroid for varied appearance
        transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)));

        // adjust the asteroid's scale in the scene based on its size
        transform.localScale = Vector3.one * size;

        // set the asteroid's movement velocity in the direction it's facing
        _rigidbody.velocity = transform.up * speed;
    }

    public void SetAsteroidProperties(int newType)
    {
        InitializeAsteroid(newType);
    }

    // helper function to set the initial properties of the asteroid based on its type
    private void InitializeAsteroid(int newType)
    {
        type = newType;
        size = asteroidSizes[type];
        speed = asteroidSpeeds[type];
        isInitialized = true;
    }

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

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddPoints(100);
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }
}