using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 500f;
    public float maxLifetime = 2f;


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
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the bullet as soon as it collides with anything
        Destroy(gameObject);
    }
    */
}