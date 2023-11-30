using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Shield shield;

    private void Start()
    {
        shield = GetComponent<Shield>();

        if (shield != null)
        {
            shield.OnShieldCollected += HandleShieldCollected;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void HandleShieldCollected()
    {
        Debug.Log("Player collected a shield!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            // Check if the 'Shield' component is attached to the 'other' GameObject
            Shield otherShield = other.GetComponent<Shield>();

            if (otherShield != null)
            {
                // Assuming you have an ActivateShield method in the Shield class
                otherShield.ActivateShield();

                // Assuming you want to destroy the 'Shield' GameObject, not 'this' GameObject
                Destroy(other.gameObject);
            }
        }
    }
}
