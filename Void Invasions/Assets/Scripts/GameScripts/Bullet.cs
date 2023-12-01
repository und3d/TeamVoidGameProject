using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 1f;
    public float maxLifetime = 2f;

    public BouncyBullets bouncyBulletsPrefab;

    Vector3 lastVelocity;
    float curVelocity;
    Vector3 dir;
    int curBounces;
    int maxBounces;

    private void Awake()
    {
        curBounces = bouncyBulletsPrefab.bounces;
        maxBounces = bouncyBulletsPrefab.maxBounces;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        lastVelocity = rigidbody.velocity;
    }

    public void Shoot(Vector2 direction)
    {
        if (rigidbody != null)
        {
            rigidbody.velocity = direction.normalized * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (HighScoreManager.Instance.bouncyActive) 
        {
            case false:
                //if (collision.gameObject.tag == "Asteroid")
                //{
                    Destroy(gameObject);
                //}
                break;
            case true:
                if (collision.gameObject.CompareTag("Border") && curBounces < maxBounces)
                {
                    curVelocity = lastVelocity.magnitude;
                    dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

                    rigidbody.velocity = dir * Mathf.Max(curVelocity, 0);
                    curBounces++;
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
        }
        
    }
}