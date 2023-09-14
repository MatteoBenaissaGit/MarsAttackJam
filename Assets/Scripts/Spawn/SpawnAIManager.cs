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
    
        private float _timerSpawn;
        
        private void Start()
        {
            _timerSpawn = Random.Range(Data.SpawnTimeRateMinimum, Data.SpawnTimeRateMaximum);
        }

        private void Update()
        {
            _timerSpawn -= Time.deltaTime;
            if (_timerSpawn < 0)
            {
                _timerSpawn = Random.Range(Data.SpawnTimeRateMinimum, Data.SpawnTimeRateMaximum);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            int spawnPoint = Random.Range(0, _spawnAIPoints.Length);

            Instantiate(Data.EnemyPrefab, _spawnAIPoints[spawnPoint].position, Quaternion.identity);
        }
    }
}
