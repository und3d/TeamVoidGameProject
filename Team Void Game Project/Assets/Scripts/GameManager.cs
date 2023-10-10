using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public LivesManager livesManager;
    public float respawnTime = 3.0f;

    public void PlayerDied()
    {
        livesManager.LoseLife();

        if (livesManager.playerLives < 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    private void Respawn()
    {
        Debug.Log("Respawn");
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);

        player.TurnOffCollisions();
        Invoke(nameof(player.TurnOnCollisions), player.respawnInvulnerability);
    }

    private void GameOver()
    {
        // TODO
    }
}