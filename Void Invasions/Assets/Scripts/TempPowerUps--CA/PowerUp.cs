using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool activateShield;
    public bool activateMaxBounces;
    public bool instaKill;
    public bool invincibility;


    // Power-up duration in seconds
    public float powerUpDuration = 10f;

    // Flag to track whether the power-up has been collected
    private bool isCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            ApplyPowerUp(other.GetComponent<Player>());
            isCollected = true;
        }
    }

    void ApplyPowerUp(Player player)
    {
        if (activateShield)
        {
            player.ActivateShield();
        }

        if (activateMaxBounces)
        {
            // Activate maxBounces and start a timer
            player.ActivateMaxBounces();
            StartCoroutine(DeactivateMaxBouncesAfterDuration(player));
        }

        if (invincibility)
        {
            player.ActivateInvincibility();
        }

        if (instaKill)
        {
            player.ActivateInstakill();
        }


        Destroy(gameObject);
    }

    IEnumerator DeactivateMaxBouncesAfterDuration(Player player)
    {
        yield return new WaitForSeconds(powerUpDuration);

        // Deactivate maxBounces after the duration
        player.DeactivateMaxBounces();
    }
}