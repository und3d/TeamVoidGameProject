using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    float duration;
    int coinFlip;

    private void Awake()
    {
        duration = HighScoreManager.Instance.upgradeDuration;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Activate Auto Weapon");
            HighScoreManager.Instance.autoWeaponActive = true;
            HighScoreManager.Instance.DeactivateAutoWeapon();
            Destroy(gameObject);
        }
    }
}
