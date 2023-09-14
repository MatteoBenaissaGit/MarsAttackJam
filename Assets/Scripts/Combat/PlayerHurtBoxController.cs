using System;
using UnityEngine;

namespace Player
{
    public class PlayerHurtBoxController : MonoBehaviour, IAttacker
    {
        public bool IsActive { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (IsActive == false)
            {
                return;
            }

            IAttackable attackable = other.GetComponent<IAttackable>();
            if (attackable != null)
            {
                GiveDamage(attackable);
            }
        }

        public void GiveDamage(IAttackable attackable)
        {
            attackable.TakeDamage(this, PlayerController.Instance.Data.Damage);
        }
    }
}