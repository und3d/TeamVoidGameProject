using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    float duration;

    private void Awake()
    {
        duration = HighScoreManager.Instance.powerUpDuration;
        Destroy(gameObject, HighScoreManager.Instance.powerUpSpawnTimer * .75f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Activate Invinc");
            HighScoreManager.Instance.invincActive = true;
            HighScoreManager.Instance.DeactivateInvinc();
            Destroy(gameObject);
        }
    }
}
