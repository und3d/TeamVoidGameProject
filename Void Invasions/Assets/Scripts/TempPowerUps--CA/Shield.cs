using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public event System.Action OnShieldCollected; // using System added here

    public float shieldDuration = 10f;
    private bool hasShield = false;

    public void ActivateShield()
    {
        if (!hasShield)
        {
            StartCoroutine(ShieldCoroutine());
            OnShieldCollected?.Invoke();
        }
    }

    private IEnumerator ShieldCoroutine()
    {
        hasShield = true;
        yield return new WaitForSeconds(shieldDuration);
        hasShield = false;
        Destroy(gameObject);
    }

    // This method can be used to check if the shield is currently active
    public bool HasShield()
    {
        return hasShield;
    }
}
