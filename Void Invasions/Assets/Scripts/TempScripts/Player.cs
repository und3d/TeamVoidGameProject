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
    public bool canShoot = true;

    public float shootDelay = 0.5f;

    public float turnDirection { get; private set; } = 0f;
    public float rotationSpeed = 0.1f;

    public float respawnDelay = 3f;
    public float respawnInvulnerability = 3f;

    public bool screenWrapping = true;
    private Bounds screenBounds;


    private bool hasMaxBounces = false; // Boolean to track whether maxBounces power-up is active
    private bool isInvincible = false; // Invincibility
    private bool isInstakill = false; //Instantkill
    public float powerUpDuration = 10f; // Time allowed for upgrade

    //Refrencing the gameobject
    GameObject shield;

    // Boolean to track whether the shield power-up is active
    private bool hasShield = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //Shield Power up logic
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();

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
                    if (canShoot)
                    {
                        Shoot(); // Shoot when touch ends in the right half of the screen
                    }
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
        if (rigidbody.position.x > screenBounds.max.x + 0.5f)
        {
            rigidbody.position = new Vector2(screenBounds.min.x - 0.5f, rigidbody.position.y);
        }
        else if (rigidbody.position.x < screenBounds.min.x - 0.5f)
        {
            rigidbody.position = new Vector2(screenBounds.max.x + 0.5f, rigidbody.position.y);
        }
        else if (rigidbody.position.y > screenBounds.max.y + 0.5f)
        {
            rigidbody.position = new Vector2(rigidbody.position.x, screenBounds.min.y - 0.5f);
        }
        else if (rigidbody.position.y < screenBounds.min.y - 0.5f)
        {
            rigidbody.position = new Vector2(rigidbody.position.x, screenBounds.max.y + 0.5f);
        }
    }

    private void Shoot()
    {
        canShoot = false;
        Invoke(nameof(CanShoot), shootDelay);

        // Define shootDirection here (assuming it's a Vector2 variable)
        Vector2 shootDirection = transform.up;

        // Define hasBounceUpgrade here (assuming it's a bool variable)
        bool hasBounceUpgrade = true; // Adjust this value based on your logic

        // Set enableBounce based on whether the instakill power-up is active
        bool enableBounce = !isInstakill;

        // Instantiate the bullet and shoot
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Shoot(shootDirection, enableBounce);
    }

    private void CanShoot()
    {
        canShoot = true;
    }

    public void TurnOffCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
    }

    //Invincibility
    public void ActivateInvincibility()
    {
        isInvincible = true;
        StartCoroutine(DeactivateInvincibilityAfterDuration());
    }

    public void DeactivateInvincibility()
    {
        isInvincible = false;
    }

    IEnumerator DeactivateInvincibilityAfterDuration()
    {
        yield return new WaitForSeconds(powerUpDuration);
        DeactivateInvincibility();
    }

    //InstaKill
    public void ActivateInstakill()
    {
        isInstakill = true;
        StartCoroutine(DeactivateInstakillAfterDuration());
    }

    public void DeactivateInstakill()
    {
        isInstakill = false;
    }

    IEnumerator DeactivateInstakillAfterDuration()
    {
        yield return new WaitForSeconds(powerUpDuration);
        DeactivateInstakill();
    }

    ///maxBounces
    public void ActivateMaxBounces()
    {
        // Set the maximum number of bounces as needed
        Bullet bulletPrefab = GetComponent<Bullet>();
        if (bulletPrefab != null)
        {
            bulletPrefab.maxBounces = 3;
        }

        // Set the flag to indicate that maxBounces is active
        hasMaxBounces = true;
    }

    public void DeactivateMaxBounces()
    {
        // Reset maxBounces to its default value
        Bullet bulletPrefab = GetComponent<Bullet>();
        if (bulletPrefab != null)
        {
            bulletPrefab.maxBounces = 1; // Set to the default value
        }

        // Set the flag to indicate that maxBounces is not active
        hasMaxBounces = false;
    }

    //Activate and deactivate Shield powerup
    public void ActivateShield()
    {
        shield.SetActive(true);
        hasShield = true;
    }

    public void DeactivateShield()
    {
        shield.SetActive(false);
        hasShield = false;
    }

    public bool HasShield()
    {
        return hasShield;
    }

    //Collision with Asteroids
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            // If the player has a shield, deactivate it and continue playing
            if (HasShield())
            {
                DeactivateShield();
            }
            else
            {
                // Destroy the player GameObject first
                Destroy(gameObject);
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = 0.0f;

                // Then handle player death and respawn
                gameManager.PlayerDied();
                StartCoroutine(RespawnAfterDelay());
            }
            Destroy(collision.gameObject);
        }

        PowerUp powerUp = collision.gameObject.GetComponent<PowerUp>();
        if (powerUp)
        {
            if (powerUp.activateShield)
            {
                // Activate the shield power-up and destroy it
                ActivateShield();
                Destroy(powerUp.gameObject);
            }
            else if (powerUp.invincibility)
            {
                // Handle invincibility power-up logic
                ActivateInvincibility();
                Destroy(powerUp.gameObject);
            }
            else if (powerUp.instaKill)
            {
                // Handle instakill power-up logic
                ActivateInstakill();
                Destroy(powerUp.gameObject);
            }
            else if (powerUp.activateMaxBounces)
            {
                // Handle maxBounces power-up logic
                ActivateMaxBounces();
                StartCoroutine(DeactivateMaxBouncesAfterDuration());
                Destroy(powerUp.gameObject);
            }
        }
    }

    IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);

        // Respawn logic goes here, either in GameManager or directly in this script
        gameManager.Respawn(); // Make sure RespawnPlayer is defined in your GameManager
    }
    IEnumerator DeactivateMaxBouncesAfterDuration()
    {
        yield return new WaitForSeconds(powerUpDuration);
        DeactivateMaxBounces();
    }

}