using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private bool isShieldActive = false;

    // Define the event
    public delegate void ShieldCollectedEventHandler();
    public event ShieldCollectedEventHandler OnShieldCollected;

    void Update()
    {
        // Only update the shield visibility if it is active and the spriteRenderer is not null
        if (isShieldActive && spriteRenderer != null)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
    }

    // Method to activate the shield
    public void ActivateShield()
    {
        // Code to activate the shield...
        isShieldActive = true;

        // Trigger the event when the shield is collected
        if (OnShieldCollected != null)
        {
            OnShieldCollected();
        }
    }

    // Method to deactivate the shield
    public void DeactivateShield()
    {
        // Code to deactivate the shield...
        isShieldActive = false;
    }

    // Method to check if the shield is active
    public bool IsShieldActive()
    {
        return isShieldActive;
    }
}
