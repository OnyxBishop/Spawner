using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoint;

    public void Spawn()
    {
        Instantiate(_template, _spawnPoint.transform.position, Quaternion.identity);
    }
}
