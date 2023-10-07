using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text livesText; // Reference to the UI Text component for displaying lives
    public int startingLives = 3; // Adjust the starting lives as needed

    private int playerLives;

    private void Start()
    {
        playerLives = startingLives;
        UpdateLivesText();
    }

    public void LoseLife()
    {
        playerLives--;
        UpdateLivesText();

        if (playerLives <= 0)
        {
            // Handle game over or other logic when lives are exhausted
            // For example, you can restart the level or end the game.
            Debug.Log("Game Over");
        }
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = $"Lives: {playerLives}";
        }
    }
}
