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
        score = HighScoreManager.Instance.Highscore;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        //updates the text displays the player score
        scoreText.text = $"Score: {score}";
        Debug.Log($"Update score text to Score: {score}");
    }
}
