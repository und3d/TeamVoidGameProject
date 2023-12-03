using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, HighScoreManager.Instance.powerUpSpawnTimer);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Activate Shield");
            HighScoreManager.Instance.shieldActive = true;
            Destroy(gameObject);
        }
    }
}
