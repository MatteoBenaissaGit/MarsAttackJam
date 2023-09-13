using UnityEngine;

namespace Data.PlayerDataScriptable
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerData", order = 1)]
    public class PlayerData : ScriptableObject
    {
        public int Life;
        public float WalkSpeed;
        [Range(20,200)] public float AngleToResetRotationInIdle;
        public float AttackTime;
        public float CameraYSpeed;
        public float CameraXSpeed;
        public float JumpForce;
        public float GravityAfterApexJump;
        public float VelocityReductionWhenJumpMultiplier;
    }
}