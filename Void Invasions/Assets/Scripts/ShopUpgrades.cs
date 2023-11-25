using UnityEngine;
using TMPro;

// class to represent an upgrade in the game
[System.Serializable]
public class Upgrade
{
    public string upgradeName; // the name of the upgrade
    public int currentLevel; 
    public int maxLevel; 
    public TextMeshProUGUI levelText; // the ui text that displays the level

    // method to increase the upgrade's level
    public void IncrementLevel()
    {

        if (currentLevel < maxLevel)
        {
            currentLevel++; 
            UpdateLevelText(); // update the level text in the ui
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
            upgrades[upgradeIndex].IncrementLevel(); // increment the level of the specified upgrade
        }
    }
}
