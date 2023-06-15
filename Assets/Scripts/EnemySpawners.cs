using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;

    private Spawner _currentSpawner;

    private float _spawnTime = 2f;
    private float _elapsedTime;
    private int _index = 0;

    private void Awake()
    {
        _currentSpawner = _spawners[_index];
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnTime)
        {
            _elapsedTime = 0;
            _currentSpawner.Spawn();
            ChangeSpawner();
        }
    }

    private void ChangeSpawner()
    {
        _index = (_index + 1) % _spawners.Length;  

        _currentSpawner = _spawners[_index];
    }
}
