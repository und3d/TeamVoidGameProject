using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 500f;
    public float maxLifetime = 2f;

    public BouncyBullets bouncyBulletsPrefab;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        if (rigidbody != null)
        {
            rigidbody.AddForce(direction * speed);
            Destroy(gameObject, maxLifetime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(bouncyBulletsPrefab.bouncyActive)
        {
            case false:
                if (collision.gameObject.tag == "Asteroid")
                {
                    Destroy(gameObject);
                }
                break;
            case true:
                if (collision.gameObject.CompareTag("BounceSurface") && bouncyBulletsPrefab.bounces < bouncyBulletsPrefab.maxBounces)
                {
                    // Reflect the bullet's velocity
                    ReflectBullet(collision.contacts[0].normal);

                    // Increment the bounce counter
                    bouncyBulletsPrefab.bounces++;
                }
                else
                {
                    // If the bullet hits something else or reaches max bounces, destroy it
                    Destroy(gameObject);
                }
                break;
        }

        void ReflectBullet(Vector2 normal)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.Reflect(rb.velocity, normal).normalized * speed;
        }
    }
}