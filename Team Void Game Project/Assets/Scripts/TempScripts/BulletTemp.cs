using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletTemp : MonoBehaviour
{
    public float speed = 10f; //Speed
    public float lifetime = 10f; //is the life of the bullet

    void Update()
    {
        // Moving up in a new position
        Vector3 newPosition = transform.position + Vector3.up * speed * Time.deltaTime;

        //Updating Location
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Astroid")
        {
            Destroy(gameObject);
        }
    }
}