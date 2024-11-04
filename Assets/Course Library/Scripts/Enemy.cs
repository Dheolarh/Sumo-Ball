using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _enemy;
    private GameObject _player;
    public float enemySpeed;
    public int enemyCount;

    private int yRange = 5;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -yRange)
        {
            Destroy(gameObject);
        }
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _enemy.AddForce(lookDirection * enemySpeed);
    }
}
