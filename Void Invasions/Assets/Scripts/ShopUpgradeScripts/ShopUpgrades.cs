using UnityEngine;
using TMPro;
using UnityEngine.UI;

// class to represent an upgrade in the game
[System.Serializable]
public class Upgrade
{
    public string upgradeName; // the name of the upgrade
    public int costPerLevel;
    public int currentLevel; 
    public int maxLevel; 
    public TextMeshProUGUI levelText; // the ui text that displays the level
    public Text scoreText;

    // method to increase the upgrade's level
    public void IncrementLevel(int index)
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            UpdateLevelText(); // update the level text in the ui
            switch (index)
            {
                case 0:
                    HighScoreManager.Instance.shootDelay -= 0.1f;
                    break;
                case 1:
                    HighScoreManager.Instance.powerUpDuration += 2;
                    break;
                case 2:
                    HighScoreManager.Instance.powerUpSpawnTimer -= 2;
                    break;
            }
        }
    }

    // method to update the level text in the ui
    private void UpdateLevelText()
    {
        levelText.text = upgradeName + ": Level " + currentLevel; // set the text to display the current level
    }
}


// a class to manage all the upgrades in the shop
public class ShopUpgrades : MonoBehaviour
{
    public Upgrade[] upgrades; // array to hold all possible upgrades

    // method to increment the level of an upgrade
    public void IncrementUpgrade(int upgradeIndex)
    {
        // check if the index is within the bounds of the upgrades array
        if (upgradeIndex >= 0 && upgradeIndex < upgrades.Length)
        {
            if (HighScoreManager.Instance.TotalScore >= upgrades[upgradeIndex].costPerLevel)
            {
                upgrades[upgradeIndex].IncrementLevel(upgradeIndex); // increment the level of the specified upgrade if enough score
                HighScoreManager.Instance.TotalScore -= upgrades[upgradeIndex].costPerLevel;
            }
        }
    }
}
