using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerHurtBoxController : MonoBehaviour, IAttacker
    {
        [field:SerializeField] public ParticleSystem ParticleHit { get; private set; }
        
        public bool IsActive { get; set; }

        private List<IAttackable> Attacked = new List<IAttackable>();

        public void Set(bool active)
        {
            Attacked.Clear();
            IsActive = active;
        }        
        
        private void OnTriggerStay(Collider other)
        {
            if (IsActive == false)
            {
                return;
            }
            
            IAttackable attackable = other.GetComponent<IAttackable>();
            if (attackable == null)
            {
                attackable = other.GetComponentInParent<IAttackable>();
            }
            if (attackable != null
                && Attacked.Contains(attackable) == false)
            {
                GiveDamage(attackable);
                Attacked.Add(attackable);
            }
        }

        public void GiveDamage(IAttackable attackable)
        {
            attackable.TakeDamage(this, PlayerController.Instance.Data.Damage);
            ParticleHit.Play();
        }
    }
}