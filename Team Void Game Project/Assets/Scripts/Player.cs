using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public GameManager gameManager;

    public new Rigidbody2D rigidbody { get; private set; }
    public Bullet bulletPrefab;

    public float thrustSpeed = 1f;
    public bool thrusting { get; private set; }

    public float turnDirection { get; private set; } = 0f;
    public float rotationSpeed = 0.1f;

    public float respawnDelay = 3f;
    public float respawnInvulnerability = 3f;

    public bool screenWrapping = true;
    private Bounds screenBounds;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        /* GameObject[] boundaries = GameObject.FindGameObjectsWithTag("x");

         // Disable all boundaries if screen wrapping is enabled
         for (int i = 0; i < boundaries.Length; i++) {
             boundaries[i].SetActive(!screenWrapping);
         }*/

        // Convert screen space bounds to world space bounds
        screenBounds = new Bounds();
        screenBounds.Encapsulate(Camera.main.ScreenToWorldPoint(Vector3.zero));
        screenBounds.Encapsulate(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)));
    }

 private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        turnDirection = 0f;

        // Calculate movement and rotation
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody.AddForce(movement * thrustSpeed * Time.deltaTime);

        float rotation = -moveHorizontal * rotationSpeed * Time.deltaTime;
        rigidbody.rotation += rotation;

         // Shoot when the screen is touched
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // Handle touch input for turning
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2) // Left half of the screen for turning
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                {
                    float touchX = touch.position.x / Screen.width * 2 - 1f; // Map touch position to -1 to 1
                    turnDirection = Mathf.Clamp(touchX, -1f, 1f); // Limit the turn direction between -1 and 1
                }
            }
            else // Right half of the screen for thrusting and shooting
            {
                if (touch.phase == TouchPhase.Began)
                {
                    thrusting = true; // Start thrusting when touch begins in the right half of the screen
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Shoot(); // Shoot when touch ends in the right half of the screen
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (thrusting)
        {
            rigidbody.AddForce(transform.up * thrustSpeed);
        }

        if (turnDirection != 0f)
        {
            rigidbody.AddTorque(-rotationSpeed * turnDirection); // Reverse the rotation direction
        }

        if (screenWrapping)
        {
            ScreenWrap();
        }
    }

    private void ScreenWrap()
    {
        // Move to the opposite side of the screen if the player exceeds the bounds
        if (rigidbody.position.x > screenBounds.max.x + 0.5f) {
            rigidbody.position = new Vector2(screenBounds.min.x - 0.5f, rigidbody.position.y);
        }
        else if (rigidbody.position.x < screenBounds.min.x - 0.5f) {
            rigidbody.position = new Vector2(screenBounds.max.x + 0.5f, rigidbody.position.y);
        }
        else if (rigidbody.position.y > screenBounds.max.y + 0.5f) {
            rigidbody.position = new Vector2(rigidbody.position.x, screenBounds.min.y - 0.5f);
        }
        else if (rigidbody.position.y < screenBounds.min.y - 0.5f) {
            rigidbody.position = new Vector2(rigidbody.position.x, screenBounds.max.y + 0.5f);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.6243f, 0), transform.rotation);
        bullet.Shoot(transform.up);
    }

    public void TurnOffCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
    }

    public void TurnOnCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
  
    //Collision with Asteroids
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);

            gameManager.PlayerDied();
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0f;

            GameManager.Instance.OnPlayerDeath(this);
        }
    }*/

}