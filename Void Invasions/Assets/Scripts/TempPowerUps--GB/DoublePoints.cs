using UnityEngine;

public class DoublePoints : MonoBehaviour
{
    float duration;

    private void Awake()
    {
        duration = HighScoreManager.Instance.upgradeDuration;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Activate upgrade");
            HighScoreManager.Instance.doubleActive = true;
            HighScoreManager.Instance.DeactivateDouble();
            Destroy(gameObject);
        }
    }

    void Deactivate()
    {
        Debug.Log("Deactivate Upgrade");
        HighScoreManager.Instance.doubleActive = false;
    }
}
