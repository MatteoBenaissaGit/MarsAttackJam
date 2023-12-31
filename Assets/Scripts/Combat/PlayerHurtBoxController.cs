﻿using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerHurtBoxController : MonoBehaviour, IAttacker
    {
        [field:SerializeField] public ParticleSystem ParticleHit { get; private set; }
        [SerializeField] private float _timeBeforeActivation;
        public GameObject AttackerObject { get; set; }

        public bool IsActive { get; set; }

        private List<IAttackable> Attacked = new List<IAttackable>();
        private float _timer;

        private void Start()
        {
            AttackerObject = PlayerController.Instance.transform.gameObject;
        }

        public void Set(bool active)
        {
            Attacked.Clear();
            IsActive = active;
            _timer = _timeBeforeActivation;
        }

        private void Update()
        {
            if (IsActive == false)
            {
                return;
            }

            _timer -= Time.deltaTime;
        }

        private void OnTriggerStay(Collider other)
        {
            if (IsActive == false || _timer > 0)
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
            attackable.TakeDamage(AttackerObject, PlayerController.Instance.Data.Damage);
            ParticleHit.Play();
        }
    }
}