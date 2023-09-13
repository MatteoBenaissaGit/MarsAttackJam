using UnityEngine;

namespace Data.PlayerDataScriptable
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerData", order = 1)]
    public class PlayerData : ScriptableObject
    {
        public int Life;
        [Range(200,1000)] public float WalkSpeed;
        [Range(20,200)] public float AngleToResetRotationInIdle;
    }
}