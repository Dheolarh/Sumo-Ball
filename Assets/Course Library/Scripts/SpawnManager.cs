using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject _enemyPrefab;
    public GameObject _powerUpPrefab;
    public int enemyCount;
    private int waveCount = 1;

    // Start is called before the first frame update

    private void Start()
    {
        SpawnEnemies(waveCount);
        Instantiate(_powerUpPrefab, RandomSpawning(), _powerUpPrefab.transform.rotation);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveCount++;
            SpawnEnemies(waveCount);
            Instantiate(_powerUpPrefab, RandomSpawning(), _powerUpPrefab.transform.rotation);
        }
    }

    void SpawnEnemies(int _enemies)
    {
        for (int i = 0; i < _enemies; i++)
        {
            Instantiate(_enemyPrefab, RandomSpawning(), _enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame



    Vector3 RandomSpawning()
    {
        float value = 10;
        float spawnRangeX = Random.Range(-value, value);
        float spawnRangeZ = Random.Range(-value, value);
        Vector3 spawnZone = new Vector3(spawnRangeX, 0, spawnRangeZ);

        return spawnZone;
    }
}
