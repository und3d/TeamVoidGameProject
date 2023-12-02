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
            coinFlip = Random.Range(1, 1);
            switch(coinFlip)
            {
                case 1:
                    Debug.Log("Activate Auto Weapon");
                    HighScoreManager.Instance.autoWeaponActive = true;
                    HighScoreManager.Instance.DeactivateAutoWeapon();
                    break;
                case 2:
                    Debug.Log("Activate Shotgun Weapon");
                    HighScoreManager.Instance.shotgunWeaponActive = true;
                    HighScoreManager.Instance.DeactivateShotgunWeapon();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
