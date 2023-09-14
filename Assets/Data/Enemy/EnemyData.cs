using UnityEngine;

namespace Data.Enemy
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyData", order = 1)]
    public class EnemyData : ScriptableObject
    {
        public int Life;
        public float WalkSpeed;
        public float AttackRange;
        public float Damage;
        public float InvincibilityTimeAfterHit;
    }
}