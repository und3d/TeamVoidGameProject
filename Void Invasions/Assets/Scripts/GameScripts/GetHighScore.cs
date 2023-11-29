using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    private int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (HighScoreManager.Instance != null)
        {
            score = HighScoreManager.Instance.Highscore;
            UpdateScoreText();
        }
        else
        {
            Debug.LogError("HighScoreManager is not initialized!");
        }
    }

    private void UpdateScoreText()
    {
        //updates the text displays the player score
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
            Debug.Log($"Update score text to Score: {score}");
        }
        else
        {
            Debug.LogError("scoreText is not assigned!");
        }
    }
}
