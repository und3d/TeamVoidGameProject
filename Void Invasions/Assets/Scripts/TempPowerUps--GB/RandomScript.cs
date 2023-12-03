using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour
{
    float duration;

    private void Awake()
    {
        duration = HighScoreManager.Instance.powerUpDuration;
        Destroy(gameObject, HighScoreManager.Instance.powerUpSpawnTimer);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Activate Random Upgrade");
            GetRandomScript();
            Destroy(gameObject);
        }
    }

    void GetRandomScript()
    {
        int num = Random.Range(1, 100);
        switch (num)
        {
            case > 0 and <= 25:         //Shield    25%
                if (HighScoreManager.Instance.shieldActive)
                {
                    GetRandomScript();
                    break;
                }
                Debug.Log("Activate Shield");
                HighScoreManager.Instance.shieldActive = true;
                break;
            case > 25 and <= 45:        //Weapon    20%
                if (HighScoreManager.Instance.autoWeaponActive)
                {
                    GetRandomScript();
                    break;
                }
                Debug.Log("Activate Auto Weapon");
                HighScoreManager.Instance.autoWeaponActive = true;
                HighScoreManager.Instance.DeactivateAutoWeapon();
                break;
            case > 45 and <= 60:        //Instakill 15%
                if (HighScoreManager.Instance.instaKillActive)
                {
                    GetRandomScript();
                    break;
                }
                Debug.Log("Activate Insta");
                HighScoreManager.Instance.instaKillActive = true;
                HighScoreManager.Instance.DeactivateInsta();
                break;
            case > 60 and <= 75:        //Double Points 15%
                if (HighScoreManager.Instance.doubleActive)
                {
                    GetRandomScript();
                    break;
                }
                Debug.Log("Activate Double");
                HighScoreManager.Instance.doubleActive = true;
                HighScoreManager.Instance.DeactivateDouble();
                break;
            case > 75 and <= 90:        //Nuke      15%
                Debug.Log("Activate Nuke");
                HighScoreManager.Instance.ActivateNuke();
                Destroy(gameObject);
                break;
            case > 90 and <= 95:        //Bouncy Bullets    5%
                if (HighScoreManager.Instance.bouncyActive)
                {
                    GetRandomScript();
                    break;
                }
                Debug.Log("Activate bouncy");
                HighScoreManager.Instance.bouncyActive = true;
                HighScoreManager.Instance.DeactivateBouncy();
                break;
            case > 95 and <= 100:        //Invincibility     5%
                if (HighScoreManager.Instance.invincActive)
                {
                    GetRandomScript();
                    break;
                }
                Debug.Log("Activate Invinc");
                HighScoreManager.Instance.invincActive = true;
                HighScoreManager.Instance.DeactivateInvinc();
                break;
        }
    }
}
