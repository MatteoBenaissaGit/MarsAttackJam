using Player;
using UnityEngine;

namespace Bonus
{
    public class Heal : BonusObject
    {
        protected override void OnTriggerStay(Collider other)
        {
            base.OnTriggerStay(other);
        
            if (CollectableTimer > 0)
            {
                return;
            }

            var script = other.gameObject.GetComponent<PlayerLifeController>();

            if (script != null)
            {
                script.Heal(Data.LifeGain);
                Destroy(this.gameObject);
            }
        }
    }
}
