using UnityEngine;
using UnityEngine.Serialization;

namespace Data.Bonus
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BonusData", order = 1)]
    public class BonusData : ScriptableObject
    {
        public GameObject[] BonusPrefab;
        public float TimeCollect;
        public int LifeGain;
        public float TimeSpeedBoost;
        public float SpeedBoostMultiplier;
    }
}