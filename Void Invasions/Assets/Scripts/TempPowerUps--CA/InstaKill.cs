using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
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
            Debug.Log("Activate Insta");
            HighScoreManager.Instance.instaKillActive = true;
            HighScoreManager.Instance.DeactivateInsta();
            Destroy(gameObject);
        }
    }
}
