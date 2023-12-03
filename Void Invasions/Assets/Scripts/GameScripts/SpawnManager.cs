using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] Camera _camera;
    [SerializeField] int _offsetX;
    [SerializeField] int _offsetY;
    GameObject powerUp;

    private void Awake()
    {
        InvokeRepeating(nameof(Spawn), HighScoreManager.Instance.powerUpSpawnTimer, HighScoreManager.Instance.powerUpSpawnTimer);
    }

    void Spawn()
    {
        powerUp = GetRandomUpgrade();
        Vector2 position = GetRandomCoordinates();
        Instantiate(powerUp, position, Quaternion.identity);
    }

    Vector2 GetRandomCoordinates()
    {
        int randomX = Random.Range(0 + _offsetX, Screen.width - _offsetX);
        int randomY = Random.Range(0 + _offsetY, Screen.height - _offsetY);

        Vector2 screenCoordinates = new Vector2(randomX, randomY);
        Vector2 screenToWorldPosition = _camera.ScreenToWorldPoint(screenCoordinates);

        return screenToWorldPosition;
    }

    GameObject GetRandomUpgrade()
    {
        int objectNum = Random.Range(1, 81);

        switch(objectNum)
        {
            case > 0 and <= 15:
                if (!HighScoreManager.Instance.shieldActive)
                {
                    powerUp = _objects[0];      //Shield
                }
                else if (HighScoreManager.Instance.shieldActive)
                {
                    GetRandomUpgrade();
                }
                break;
            case > 15 and <= 30:
                powerUp = _objects[1];      //Random Power Up
                break;
            case > 30 and <= 45:
                if (!HighScoreManager.Instance.autoWeaponActive)
                {
                    powerUp = _objects[2];      //Weapon
                }
                else if (HighScoreManager.Instance.autoWeaponActive)
                {
                    GetRandomUpgrade();
                }
                break;
            case > 45 and <= 60:
                if (!HighScoreManager.Instance.instaKillActive)
                {
                    powerUp = _objects[3];      //Instakill
                }
                else if (HighScoreManager.Instance.instaKillActive)
                {
                    GetRandomUpgrade();
                }
                break;
            case > 60 and <= 75:
                if (!HighScoreManager.Instance.doubleActive)
                {
                    powerUp = _objects[4];      //Double Points
                }
                else if (HighScoreManager.Instance.doubleActive)
                {
                    GetRandomUpgrade();
                }
                break;
            case > 75 and <= 90:
                powerUp = _objects[5];      //Nuke
                break;
            case > 90 and <= 95:
                if (!HighScoreManager.Instance.bouncyActive)
                {
                    powerUp = _objects[6];      //Bouncy Bullets
                }
                else if (HighScoreManager.Instance.bouncyActive)
                {
                    GetRandomUpgrade();
                }
                break;
            case > 95 and <= 100:
                if (!HighScoreManager.Instance.invincActive)
                {
                    powerUp = _objects[7];      //Invincibility
                }
                else if (HighScoreManager.Instance.invincActive)
                {
                    GetRandomUpgrade();
                }
                break;
        }

        return powerUp;
    }
}
