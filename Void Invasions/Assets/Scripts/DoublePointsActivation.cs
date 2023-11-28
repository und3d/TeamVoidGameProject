using UnityEngine;

public class DoublePointsActivator : MonoBehaviour
{
    public ScoreManager scoreManager;  // Reference to the ScoreManager script

    private void Start()
    {
        // Assuming the ScoreManager script is attached to the same GameObject
        scoreManager = GetComponent<ScoreManager>();

        // Activate double points when the script is used (e.g., when the game starts)
        ActivateDoublePoints();
    }

    // Method to activate double points in the attached ScoreManager script
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
