using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShootDelayReduction : MonoBehaviour
{
    public string upgradeName; // the name of the upgrade
    public int costPerLevel;
    public int currentLevel;
    public int maxLevel;
    public TextMeshProUGUI levelText; // the ui text that displays the level
    public Text scoreText;

    private void Awake()
    {
        currentLevel = HighScoreManager.Instance.shootDelayLevel;
        UpdateLevelText();
    }

    // method to increase the upgrade's level
    public void IncrementLevel()
    {
        if (currentLevel < maxLevel && HighScoreManager.Instance.TotalScore >= costPerLevel)
        {
            HighScoreManager.Instance.TotalScore -= costPerLevel;
            currentLevel++;
            HighScoreManager.Instance.shootDelayLevel = currentLevel;
            UpdateLevelText(); // update the level text in the ui
            HighScoreManager.Instance.shootDelay -= 0.1f;
        }
    }

    // method to update the level text in the ui
    private void UpdateLevelText()
    {
        levelText.text = upgradeName + ": Level " + currentLevel + "\nCost: " + costPerLevel; // set the text to display the current level
        scoreText.text = $"Score: {HighScoreManager.Instance.TotalScore}";
    }
}
