using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text livesText; // Reference to the UI Text component for displaying lives

    private void Awake()
    {
        UpdateLivesText();
    }

    public void LoseLife()
    {
        HighScoreManager.Instance.currLives--;
        UpdateLivesText();

        if (HighScoreManager.Instance.currLives < 1)
        {
            // Handle game over or other logic when lives are exhausted
            // For example, you can restart the level or end the game.
            Debug.Log("Game Over");
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = $"Lives: {HighScoreManager.Instance.currLives}";
    }
}
