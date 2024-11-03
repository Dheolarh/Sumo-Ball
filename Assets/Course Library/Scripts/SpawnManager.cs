using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject _enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_enemyPrefab, RandomSpawning(), _enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }



    Vector3 RandomSpawning()
    {
        float value = 10;
        float spawnRangeX = Random.Range(-value, value);
        float spawnRangeZ = Random.Range(-value, value);
        Vector3 spawnZone = new Vector3(spawnRangeX, 0, spawnRangeZ);

        return spawnZone;
    }
}
