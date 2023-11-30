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
    [SerializeField] int _spawnCountPerWave = 1;
    [SerializeField] int _numberOfWaves = 1; // Adjust the number of waves as needed

    List<GameObject> _spawnedObjects = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        // You can add any other update logic here if needed
    }

    IEnumerator SpawnWaves()
    {
        for (int wave = 0; wave < _numberOfWaves; wave++)
        {
            yield return StartCoroutine(SpawnUpgrades());
            yield return new WaitForSeconds(_spawnDuration);
            ClearSpawnedObjects();
        }

        // Game over logic can be added here
    }

    IEnumerator SpawnUpgrades()
    {
        for (int i = 0; i < _spawnCountPerWave; i++)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnDuration / _spawnCountPerWave);
        }
    }

    void Spawn()
    {
        GameObject upgrade = GetRandomUpgrade();      //Random.Range(0, _objects.Length);
        Vector2 position = GetRandomCoordinates();
        GameObject spawnedObject = Instantiate(upgrade, position, Quaternion.identity);
        _spawnedObjects.Add(spawnedObject);
    }

    Vector2 GetRandomCoordinates()
    {
        int randomX = Random.Range(0 + _offsetX, Screen.width - _offsetX);
        int randomY = Random.Range(0 + _offsetY, Screen.height - _offsetY);

        Vector2 screenCoordinates = new Vector2(randomX, randomY);
        Vector2 screenToWorldPosition = _camera.ScreenToWorldPoint(screenCoordinates);

        return screenToWorldPosition;
    }

    void ClearSpawnedObjects()
    {
        foreach (var spawnedObject in _spawnedObjects)
        {
            Destroy(spawnedObject);
        }
        _spawnedObjects.Clear();
    }

    GameObject GetRandomUpgrade()
    {
        GameObject upgrade = Instantiate(gameObject);

        int objectNum = Random.Range(1, 81);

        switch(objectNum)
        {
            case < 11 and >= 1:
                upgrade = _objects[0];
                break;
            case < 21 and >= 11:
                upgrade = _objects[1];
                break;
            case < 31 and >= 21:
                upgrade = _objects[2];
                break;
            case < 41 and >= 31:
                upgrade = _objects[3];
                break;
            case < 51 and >= 41:
                upgrade = _objects[4];
                break;
            case < 61 and >= 51:
                upgrade = _objects[5];
                break;
            case < 71 and >= 61:
                upgrade = _objects[6];
                break;
            case < 81 and >= 71:
                upgrade = _objects[7];
                break;
        }

        return upgrade;
    }
}
