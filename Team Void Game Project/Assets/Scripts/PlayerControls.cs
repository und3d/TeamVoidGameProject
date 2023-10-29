using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    public FixedJoystick Joystick;
    public Bullet bulletPrefab;
    public GameManager gameManager;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;
    public bool canShoot = true;
    public bool isAlive = true;
    public float shootDelay = 0.5f;
    public float respawnInvulnerability = 3f;

    public static bool PointerDown = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Movement
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        //Rotation
        float hAxis = move.x;
        float vAxis = move.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
    }

    private void FixedUpdate()
    {
        if(PointerDown)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void ShootButtonPressed()
    {
        if (canShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        canShoot = false;
        if (isAlive)
        {
            Invoke(nameof(CanShoot), shootDelay);
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.Shoot(transform.up);
        }
    }

    private void CanShoot()
    {
        if (isAlive)
        {
            canShoot = true;
        }
    }

    public void TurnOffCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
    }

    //Collision with Asteroids
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;
            isAlive = false;
            this.gameObject.SetActive(false);

            gameManager.PlayerDied();
        }
    }
}
