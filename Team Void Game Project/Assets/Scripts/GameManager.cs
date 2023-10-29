using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerControls player;
    public LivesManager livesManager;
    public float respawnTime = 3.0f;

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

    private void Respawn()
    {
        Debug.Log("Respawn");
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
        player.canShoot = true;
        player.isAlive = true;

        player.TurnOffCollisions();
        Invoke(nameof(TurnOnCollisions), player.respawnInvulnerability);
    }

    private void GameOver()
    {
        // TODO
    }
}