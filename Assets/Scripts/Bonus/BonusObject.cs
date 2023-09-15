using System;
using Data.Bonus;
using Player;
using UnityEngine;

namespace Bonus
{
    public class BonusObject : MonoBehaviour
    {
        [field: SerializeField] public BonusData Data { get; private set; }

        protected float CollectableTimer;

        protected virtual void Start()
        {
            CollectableTimer = Data.TimeCollect;
        }

        protected virtual void Update()
        {
            CollectableTimer -= Time.deltaTime;

            transform.RotateAround(transform.position,Vector3.up, 1f);
        }
        
        protected virtual void OnTriggerStay(Collider other)
        {
            
        }
    }
}