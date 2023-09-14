using UnityEngine;
using UnityEngine.Serialization;

namespace Data.Enemy
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyData", order = 1)]
    public class EnemyData : ScriptableObject
    {
        public int Life;
        public int SpawnTimer;
        public float WalkSpeed;
        [Space(10)]
        public float AttackRange;
        public float AttackTime;
        public float Damage;
        public float InvincibilityTimeAfterHit;
        public float DistanceToAttack;
        public float TimeToAttackAfterDetection;

        public float CollectTimeMinimum { get; internal set; }
    }
}