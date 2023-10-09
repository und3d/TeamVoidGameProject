using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int playerScore = 0;
    public int playerLives = 3;
    public Text scoreText;
    public Text livesText;


    // Start is called before the first frame update
    public void AddScore(int points)
    {
        playerScore += points;
        scoreText.text = "Score: " + playerScore;
    }   
        
        //livesText.text = "Lives: " + playerLives;
 }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
