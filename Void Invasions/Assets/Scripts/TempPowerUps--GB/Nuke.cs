using UnityEngine;

public class Nuke : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, HighScoreManager.Instance.powerUpSpawnTimer);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Activate Nuke");
            HighScoreManager.Instance.ActivateNuke();
            Destroy(gameObject);
        }
    }
}
