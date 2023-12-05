using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Score Text
    public float doublePointsDuration = 10.0f;  // Duration for double points

    private void Awake()
    {
        UpdateScoreText();  // Updating Score Text
    }

    public void AddPoints(int points)
    {
        // This gets the player score and adds points for the double points
        int pointsToAdd = HighScoreManager.Instance.doubleActive ? points * 2 : points;
        HighScoreManager.Instance.currScore += pointsToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Updates the text displaying the player score
        scoreText.text = $"Score: {HighScoreManager.Instance.currScore}";
        Debug.Log($"Current score: {HighScoreManager.Instance.currScore}");

        if (HighScoreManager.Instance.currScore >= (HighScoreManager.Instance.nextBossScore) && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            SceneManager.LoadScene("Asteroid Boss");
        }
    }
}
