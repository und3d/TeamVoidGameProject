using UnityEngine;

public class DoublePointsScript : MonoBehaviour
{
    public ScoreManager scoreManager;  // Reference to the ScoreManager script 
    private void Start()
    {
        // Make sure to assign the ScoreManager script in the inspector
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not assigned!");
        }
    }
    public void DoublePoints()
    {
        // Double the players score using the add points method in ScoreManager
        scoreManager.AddPoints(scoreManager.playerScore);
    }
}