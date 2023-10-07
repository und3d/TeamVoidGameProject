using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;//Score Text
    private int playerScore = 0;// player score

    //private void Start()
    //{
        //UpdateScoreText(); //updating Score Text
    
    //}
    public void AddPoints(int points)
    {
        //This getts the player score and adds points
        playerScore += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        
        if (scoreText != null)
        {
            //updates the text displays the player score (not working only on console)
            scoreText.text = $"Score: {playerScore}";
            Debug.Log($"Update score text to Score: {playerScore}");
        }
    }
}


