using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    private SpawnPoint[] _spawnPoints;

    private bool _isSpawning = true;
    private float _spawnTime = 2f;
    private int _index = 0;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        StartCoroutine(CreateDuringTime());
    }

    private IEnumerator CreateDuringTime()
    {
        while (_isSpawning == true)
        {
            yield return new WaitForSeconds(_spawnTime);

            Spawn();
        }
    }

    private void ChangeSpawner()
    {
        _index = (_index + 1) % _spawnPoints.Length;
    }

    private void Spawn()
    {
        Instantiate(_template, _spawnPoints[_index].transform.position, Quaternion.identity);

        ChangeSpawner();
    }
}
