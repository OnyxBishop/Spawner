using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    public bool IsTimeOver => _elapsedTime >= _spawnTime;

    private SpawnPoint[] _spawnPoints;

    private float _spawnTime = 2f;
    private float _elapsedTime = 0f;
    private int _index = 0;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        StartCoroutine(CreateDuringTime());
    }

    private IEnumerator CreateDuringTime()
    {
        while (IsTimeOver == false)
        {
            _elapsedTime += Time.deltaTime;

            Spawn();

            yield return null;
        }
    }

    private void ChangeSpawner()
    {
        _index = (_index + 1) % _spawnPoints.Length;
    }

    private void Spawn()
    {
        if (IsTimeOver == true)
        {
            Instantiate(_template, _spawnPoints[_index].transform.position, Quaternion.identity);

            ChangeSpawner();

            _elapsedTime = 0f;
        }
    }
}
