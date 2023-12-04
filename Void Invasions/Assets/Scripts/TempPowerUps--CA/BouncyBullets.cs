using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBullets : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public int maxBounces = 3;
    public int bounces = 0;

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
            Debug.Log("Activate bouncy");
            HighScoreManager.Instance.bouncyActive = true;
            HighScoreManager.Instance.DeactivateBouncy();
            Destroy(gameObject);
        }
    }

    
}
