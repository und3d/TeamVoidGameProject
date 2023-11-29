using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Score Text
    public int playerScore = 0;  // Player score
    public bool doublePoints = false;  // Flag to enable/disable double points
    public float doublePointsDuration = 10.0f;  // Duration for double points

    private void Start()
    {
        UpdateScoreText();  // Updating Score Text

        // activates double points after 15 seconds
        Invoke("ActivateDoublePoints", 15f);
    }

    public void AddPoints(int points)
    {
        // This gets the player score and adds points for the double points
        int pointsToAdd = doublePoints ? points * 2 : points;
        playerScore += pointsToAdd;
        HighScoreManager.Instance.Highscore = playerScore;
        UpdateScoreText();
    }

    public void ActivateDoublePoints()
    {
        doublePoints = true;

        //Deactivate double points after the specified duration
        Invoke("DeactivateDoublePoints", doublePointsDuration);
    }

    public void DeactivateDoublePoints()
    {
        doublePoints = false;
    }

    private void UpdateScoreText()
    {
        // Updates the text displaying the player score
        scoreText.text = $"Score: {playerScore}";
        Debug.Log($"Update score text to Score: {playerScore}");
    }
}
