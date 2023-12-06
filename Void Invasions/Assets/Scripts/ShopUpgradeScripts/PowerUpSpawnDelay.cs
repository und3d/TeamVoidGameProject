using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerUpSpawnDelay : MonoBehaviour
{
    public string upgradeName; // the name of the upgrade
    public int costPerLevel;
    public int currentLevel;
    public int maxLevel;
    public TextMeshProUGUI levelText; // the ui text that displays the level
    public Text scoreText;

    private void Awake()
    {
        currentLevel = HighScoreManager.Instance.powerUpSpawnLevel;
        UpdateLevelText();
    }

    // method to increase the upgrade's level
    public void IncrementLevel()
    {
        if (currentLevel < maxLevel && HighScoreManager.Instance.TotalScore >= costPerLevel)
        {
            HighScoreManager.Instance.TotalScore -= costPerLevel;
            currentLevel++;
            HighScoreManager.Instance.powerUpSpawnLevel = currentLevel;
            UpdateLevelText(); // update the level text in the ui
            HighScoreManager.Instance.powerUpSpawnTimer -= 2;
        }
    }

    // method to update the level text in the ui
    private void UpdateLevelText()
    {
        levelText.text = upgradeName + ": Level " + currentLevel; // set the text to display the current level
        scoreText.text = $"Score: {HighScoreManager.Instance.TotalScore}";
    }
}
