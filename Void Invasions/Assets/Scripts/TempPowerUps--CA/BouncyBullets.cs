using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBullets : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public int maxBounces = 3;

    private int bounces = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial velocity
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        // Destroy the bullet after a certain lifetime
        Destroy(gameObject, lifetime);
    }

    // Called when the bullet hits a collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bullet hits a surface that can be bounced off
        if (collision.gameObject.CompareTag("BounceSurface") && bounces < maxBounces)
        {
            // Reflect the bullet's velocity
            ReflectBullet(collision.contacts[0].normal);

            // Increment the bounce counter
            bounces++;
        }
        else
        {
            // If the bullet hits something else or reaches max bounces, destroy it
            Destroy(gameObject);
        }
    }

    // Reflect the bullet's velocity based on the collision normal
    void ReflectBullet(Vector2 normal)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.Reflect(rb.velocity, normal).normalized * speed;
    }
}
