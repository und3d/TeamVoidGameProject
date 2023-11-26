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
    [SerializeField] int _spawnCountPerWave = 5;
    [SerializeField] int _numberOfWaves = 3; // Adjust the number of waves as needed

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
        int randomObjectID = Random.Range(0, _objects.Length);
        Vector2 position = GetRandomCoordinates();
        GameObject spawnedObject = Instantiate(_objects[randomObjectID], position, Quaternion.identity);
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
}
