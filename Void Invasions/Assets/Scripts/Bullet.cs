using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 500f;
    public float maxLifetime = 2f;
    public int maxBounces = 1; // Maximum number of bounces

    private int currentBounces = 0; // Current number of bounces
    bool shouldBounce = false;  // Flag to determine whether bouncing is allowed

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Modify the Shoot method to accept the bouncing upgrade flag
    public void Shoot(Vector2 direction, bool enableBounce)
    {
        shouldBounce = enableBounce;
        currentBounces = 0; // Reset the bounces when shooting again

        if (rigidbody != null)
        {
            rigidbody.velocity = Vector2.zero; // Reset velocity before applying force
            rigidbody.AddForce(direction * speed);
            Destroy(gameObject, maxLifetime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            if (shouldBounce)
            {
                // Bounce off the surface
                Bounce(collision.GetContact(0).normal);
            }
            else
            {
                // Destroy the asteroid instantly
                Destroy(collision.gameObject);
            }

            // Destroy the bullet in either case
            Destroy(gameObject);
        }
    }

    private void Bounce(Vector2 normal)
    {
        // Reflect the velocity using the collision normal
        rigidbody.velocity = Vector2.Reflect(rigidbody.velocity, normal);
    }
}
