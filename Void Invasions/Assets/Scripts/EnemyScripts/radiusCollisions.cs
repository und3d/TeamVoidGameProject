using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiusCollisions : MonoBehaviour
{
    public List<GameObject> ObjsInRadius = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Player")
        {
            ObjsInRadius.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Collision exit");
        if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Player")
        {
            ObjsInRadius.Remove(other.gameObject);
        }
    }
}
