using System;
using System.Collections;
using Data.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class SpawnAIManager : MonoBehaviour
    {
        [field: SerializeField] public SpawnAIData Data { get; private set; }
    
        [SerializeField] private Transform[] _spawnAIPoints;
        [SerializeField] private float _spawnTimeRateMinimum;
        [SerializeField] private float _spawnTimeRateMaximum;
    
        private float _timerSpawn;
        
        private void Start()
        {
            _timerSpawn = Random.Range(Data.SpawnTimeRateMinimum, Data.SpawnTimeRateMaximum);
            _spawnTimeRateMinimum = Data.SpawnTimeRateMinimum;
            _spawnTimeRateMaximum = Data.SpawnTimeRateMaximum;
        }

        private void Update()
        {
            _timerSpawn -= Time.deltaTime;
            if (_timerSpawn < 0)
            {
                _timerSpawn = Random.Range(_spawnTimeRateMinimum, _spawnTimeRateMaximum);

                if(_spawnTimeRateMaximum > 2)
                    _spawnTimeRateMaximum = _spawnTimeRateMaximum / 1.01f;

                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            if (_spawnAIPoints.Length == 0)
            {
                return;
            }

            int spawnPoint = Random.Range(0, _spawnAIPoints.Length);

            Instantiate(Data.EnemyPrefab, _spawnAIPoints[spawnPoint].position, Quaternion.identity);
        }
    }
}
