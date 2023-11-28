using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;//Score Text
    public int playerScore = 0;// player score

    private void Start()
    {
        UpdateScoreText(); //updating Score Text
    
    }
    public void AddPoints(int points)
    {
        //This getts the player score and adds points
        playerScore += points;
        HighScoreManager.Instance.Highscore = playerScore;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        //updates the text displays the player score (not working only on console)
        scoreText.text = $"Score: {playerScore}";
        Debug.Log($"Update score text to Score: {playerScore}");

        if (playerScore >= 100 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            SceneManager.LoadScene("Asteroid Boss");
        }
    }
}


