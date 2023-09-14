using UnityEngine;

namespace Data.Bonus
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BonusData", order = 1)]
    public class BonusData : ScriptableObject
    {
        public GameObject[] BonusPrefab;
        public int CollectTimeMinimum;
        public int CollectTimeMaximum;
        public int LifeGain;
    }
}