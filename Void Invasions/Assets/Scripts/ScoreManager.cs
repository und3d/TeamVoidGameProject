using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Score Text
    public int playerScore = 0;  // Player score
    public bool doublePoints = true;  // Flag to enable/disable double points

    private void Start()
    {
        UpdateScoreText();  // Updating Score Text
    }

    public void AddPoints(int points)
    {
        // This gets the player score and adds points
        int pointsToAdd = doublePoints ? points * 2 : points;
        playerScore += pointsToAdd;
        HighScoreManager.Instance.Highscore = playerScore;
        UpdateScoreText();
    }

   
    public void ActivateDoublePoints()
    {
        doublePoints = true;

    }

    
    public void DeactivateDoublePoints()
    {
        doublePoints = false;
    }

    private void UpdateScoreText()
    {
        // Updates the text, displaying the player score (not working only on console)
        scoreText.text = $"Score: {playerScore}";
        Debug.Log($"Update score text to Score: {playerScore}");
    }
}
