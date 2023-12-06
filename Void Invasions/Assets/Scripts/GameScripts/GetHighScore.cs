using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    private int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        if (HighScoreManager.Instance != null)
        {
            score = HighScoreManager.Instance.TotalScore;
            UpdateScoreText();
        }
    }

    public void UpdateScoreText()
    {
        //updates the text displays the player score
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}
