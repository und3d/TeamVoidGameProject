using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public float invincibilityDuration = 5f;
    private bool isInvincible = false;

    // method to activate invincibility
    public void ActivateInvincibility()
    {
        if (!isInvincible)
        {
            isInvincible = true;
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    // Coroutine to handle the duration of invincibility
    private IEnumerator InvincibilityCoroutine()
    {
        yield return new WaitForSeconds(invincibilityDuration);

        // Reset to normal state after the invincibility duration
        isInvincible = false;
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
