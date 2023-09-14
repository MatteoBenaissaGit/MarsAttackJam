using UnityEngine;
using UnityEngine.Serialization;

namespace Data.Enemy
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnAIData", order = 1)]
    public class SpawnAIData : ScriptableObject
    {
        public GameObject Ennemy;
        public int SpawnTimeRate;
        public Vector3[] SpawnPoints;
    }
}