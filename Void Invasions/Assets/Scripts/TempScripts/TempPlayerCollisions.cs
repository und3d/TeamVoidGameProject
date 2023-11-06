using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerCollisions : MonoBehaviour
{
    public float playerSpeed = 10f;
    // Start is called before the first frame update
    void Update()
    {
        Vector3 newPosition = transform.position + Vector3.up * playerSpeed * Time.deltaTime;

        //Updating Location
        transform.position = newPosition;

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Astroid")
        {
            Destroy(gameObject);
        } 
    }
}
