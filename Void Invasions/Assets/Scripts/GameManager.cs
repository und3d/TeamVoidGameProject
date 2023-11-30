using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerControls player;
    public LivesManager livesManager;
    public Text GameOverText;
    public GameObject gameOverGroup;
    public GameObject GUI_Group;
    public float respawnTime = 3.0f;
    public GameObject playerPrefab; // Reference to your player prefab
    public Vector3 respawnPosition; // Set this to the starting position for player respawn
    

    private void Start()
    {
        // Instantiate or find the player object
        player = InstantiatePlayer();
    }

    private PlayerControls InstantiatePlayer()
    {
        // Replace with your instantiation logic or use GameObject.Find
        return GameObject.Find("Player").GetComponent<PlayerControls>();
    }

    public void PlayerDied()
    {
        livesManager.LoseLife();
        player.canShoot = false;

        if (livesManager.playerLives < 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    public void TurnOnCollisions()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void Respawn()
    {
        Debug.Log("Respawn");

        // Check if the player object is null before accessing it
        if (player != null)
        {
            player.transform.position = Vector3.zero;
            player.gameObject.SetActive(true);
            player.canShoot = true;
            player.isAlive = true;

            player.TurnOffCollisions();
            Invoke(nameof(TurnOnCollisions), player.respawnInvulnerability);
        }
        else
        {
            // Handle the case where the player object is null (e.g., provide a default respawn behavior)
            Debug.LogWarning("Player object is null. Handle this case appropriately.");
        }
    }

    private void Awake()
    {
        GUI_Group = GameObject.Find("GUI_Group"); // Replace with your actual hierarchy name
        gameOverGroup = GameObject.Find("GameOverGroup"); // Replace with your actual hierarchy name
    }

    private void GameOver()
    {
        GUI_Group.gameObject.SetActive(false);
        gameOverGroup.gameObject.SetActive(true);
        GameOverText.text = $" GAME OVER \n\n TOTAL SCORE \n\n {HighScoreManager.Instance.Highscore} ";
    }
}

