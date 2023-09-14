using Data.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAIManager : MonoBehaviour
{
    [field: SerializeField] public SpawnAIData Data { get; private set; }
    public float SpawnAITimeRate;
    public int PointSpawn;
    public Vector3[] SpawnAIPoints;

    private void Start()
    {
        SpawnAITimeRate = Data.SpawnTimeRate;
        PointSpawn = 0;
        SpawnAIPoints = Data.SpawnPoints;

        StartCoroutine(WaitForTime(SpawnAITimeRate));
    }

    public IEnumerator WaitForTime(float time)
    {
        yield return new WaitForSeconds(time * Time.deltaTime);

        if (PointSpawn < SpawnAIPoints.Length)
        {
            Instantiate(Data.Ennemy, SpawnAIPoints[PointSpawn], Quaternion.identity);
            PointSpawn++;
        }
        else
        {
            PointSpawn = 0;
            Instantiate(Data.Ennemy, SpawnAIPoints[PointSpawn], Quaternion.identity);
        }

        StartCoroutine(WaitForTime(SpawnAITimeRate));
    }
}
