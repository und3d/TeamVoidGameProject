using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float size;
    public float speed;
    public int score = 0;
    public int type;

    private bool isInitialized = false;
    public Vector2 astDirection;

    public float[] asteroidSizes = { 0.6f, 1f, 1.4f };
    public int[] asteroidSpeeds = { 10, 7, 4 };
    public float maxLifeTime = 30.0f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    //added piercingbullet list
    private List<PiercingBullet> collidedBullets = new List<PiercingBullet>();

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();

        /*        // If the asteroid is not already initialized, randomize its type.
                if (!isInitialized)
                {
                    InitializeAsteroid(Random.Range(0, 3));
                } */
    }

    private void Start()
    {
        
    }

    public void SetAsteroidProperties(int newType)
    {
        SetVariables(this.astDirection, asteroidSpeeds[newType], asteroidSizes[newType], newType);
    }

    //Variables set in the spawner script
    public void SetVariables(Vector2 direction, int speed, float size, int setType)
    {
        this.astDirection = direction;
        _rigidbody.AddForce(direction * speed);         //Sets the speed of the asteroid
        transform.localScale = Vector3.one * size;      //Sets the size of the asteroid based on it's type (determined in spawner script)
        isInitialized = true;
        type = setType;

        Destroy(this.gameObject, this.maxLifeTime);     //Destroys asteroid after specified amount of time
    }
    //also added for piercing bullet

    public List<Asteroid> GetFragments()
    {
        return new List<Asteroid>(); 
    }


    private void HandleBulletCollision(PiercingBullet bullet)
    {
        Destroy(gameObject); // Destroying the asteroid for demonstration
    }


        /*    // helper function to set the initial properties of the asteroid based on its type
            private void InitializeAsteroid(int newType)
            {
                type = newType;
                size = asteroidSizes[type];
                speed = asteroidSpeeds[type];
                isInitialized = true;
            } */

        //Collision between Asteroid and Bullet
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //added for bulletpiercing
            PiercingBullet piercingBullet = collision.gameObject.GetComponent<PiercingBullet>();

            if(piercingBullet != null && !HasCollided(piercingBullet))
            {
                HandleBulletCollision(piercingBullet);
            }

            TempAsteroidSplitting splittingScript = GetComponent<TempAsteroidSplitting>();
            if (splittingScript != null)
            {
                splittingScript.SplitAsteroid();
            }
            HighScoreManager.Instance.AsteroidExplosion();
            FindObjectOfType<ScoreManager>().AddPoints(100);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }

    

    private bool HasCollided(PiercingBullet bullet)
    {
        return collidedBullets.Contains(bullet);
    }
}