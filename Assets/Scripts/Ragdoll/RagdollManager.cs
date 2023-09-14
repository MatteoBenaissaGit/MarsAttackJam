using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class RagdollManager : MonoBehaviour
    {
        [SerializeField] private GameObject _ragdoll;
        [SerializeField] private List<RagdollLimb> _limbs;
        [SerializeField] private Rigidbody _hips;

        private void Awake()
        {
            _ragdoll.SetActive(false);
        }

        public void SetRagdollActive(params bool[] addForce)
        {
            _ragdoll.SetActive(true);
            
            _limbs.ForEach(x => x.SetLimb());

            if (addForce == null || addForce.Length == 0 || _hips == null)
            {
                return;
            }
            
            _hips.AddForce(Vector3.up * 2000);
            _hips.AddForce(-_hips.gameObject.transform.forward * 2000);
        }
    }
}