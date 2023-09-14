using UnityEngine;

namespace Data.PlayerDataScriptable
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerData", order = 1)]
    public class PlayerData : ScriptableObject
    {
        public int Life;
        public float WalkSpeed;
        [Space(10)]
        [Range(20,200)] public float AngleToResetRotationInIdle;
        public float AttackTime;
        [Space(10)]
        public float CameraYSpeed;
        public float CameraXSpeed;
        [Space(10)]
        public float JumpForce;
        public float GravityAfterApexJump;
        public float VelocityReductionWhenJumpMultiplier;
        [Space(10)] 
        public float BaseFOV;
        public float RunFOV;
        [Space(10)] 
        public float InvincibleTimeAfterHit;
        public Color FullLifeColor;
        public Color LowLifeColor;
        public int Damage;
    }
}