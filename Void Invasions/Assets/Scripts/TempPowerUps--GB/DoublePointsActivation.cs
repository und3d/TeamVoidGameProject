using UnityEngine;

public class DoublePointsActivator : MonoBehaviour
{
    public ScoreManager scoreManager;  // Reference to the ScoreManager script

    private void Start()
    {
      
        scoreManager = GetComponent<ScoreManager>();

        ActivateDoublePoints();
    }

    //activates double points in the attached ScoreManager script
    private void ActivateDoublePoints()
    {
        if (scoreManager != null)
        {
            scoreManager.ActivateDoublePoints();
        }
        else
        {
            Debug.LogWarning("ScoreManager script not found.");
        }
    }
}
