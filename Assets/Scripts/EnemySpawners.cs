using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private SpawnEnemy[] _spawners;

    public bool IsTimeOver => _elapsedTime >= _spawnTime;

    private SpawnEnemy _currentSpawner;

    private float _spawnTime = 2f;
    private float _elapsedTime = 0f;
    private int _index = 0;

    private void Start()
    {
        _currentSpawner = _spawners[_index];

        StartCoroutine(CreateDuringTime());   
    }

    private IEnumerator CreateDuringTime()
    {
        while (IsTimeOver == false)
        {
            _elapsedTime += Time.deltaTime;
           
            SpawnDuringTime();

            yield return null;
        }
    }

    private void ChangeSpawner()
    {
        _index = (_index + 1) % _spawners.Length;

        _currentSpawner = _spawners[_index];
    }

    private void SpawnDuringTime()
    {
        if (IsTimeOver == true)
        {
            _currentSpawner.Spawn();

            ChangeSpawner();

            _elapsedTime = 0f;
        }
    }
}
