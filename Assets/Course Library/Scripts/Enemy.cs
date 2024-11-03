using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _enemy;
    private GameObject _player;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _enemy.AddForce((_player.transform.position - transform.position).normalized * enemySpeed);
    }
}
