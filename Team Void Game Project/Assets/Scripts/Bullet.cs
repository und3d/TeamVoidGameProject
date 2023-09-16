using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveSpriteUp : MonoBehaviour
{
    public float speed = 10f; //Speed

    void Update()
    {
        // Moving up in a new position
        Vector3 newPosition = transform.position + Vector3.up * speed * Time.deltaTime;

        //Updating Location
        transform.position = newPosition;
    }
}

