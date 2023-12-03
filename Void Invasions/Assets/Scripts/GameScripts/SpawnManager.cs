using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] Camera _camera;
    [SerializeField] int _offsetX;
    [SerializeField] int _offsetY;
    [SerializeField] float _spawnDuration = 10f;
    GameObject upgrade;

    private void Awake()
    {
        InvokeRepeating(nameof(Spawn), _spawnDuration, _spawnDuration);
    }

    void Spawn()
    {
        upgrade = GetRandomUpgrade();
        Vector2 position = GetRandomCoordinates();
        Instantiate(upgrade, position, Quaternion.identity);
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
                upgrade = _objects[0];
                break;
            case > 15 and <= 30:
                upgrade = _objects[1];
                break;
            case > 30 and <= 45:
                upgrade = _objects[2];
                break;
            case > 45 and <= 60:
                upgrade = _objects[3];
                break;
            case > 60 and <= 75:
                upgrade = _objects[4];
                break;
            case > 75 and <= 90:
                upgrade = _objects[5];
                break;
            case > 90 and <= 95:
                upgrade = _objects[6];
                break;
            case > 95 and <= 100:
                upgrade = _objects[7];
                break;
        }

        return upgrade;
    }
}
