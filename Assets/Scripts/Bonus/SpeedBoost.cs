using Player;
using UnityEngine;

namespace Bonus
{
    public class SpeedBoost : BonusObject
    {
        protected override void OnTriggerStay(Collider other)
        {
            base.OnTriggerStay(other);
        
            if (CollectableTimer > 0)
            {
                return;
            }

            PlayerController player = other.gameObject.GetComponent<PlayerController>();


            if (player != null)
            {
                player.TimerBoost = Data.TimeSpeedBoost;
                Destroy(this.gameObject);
            }
        }
    }
}
