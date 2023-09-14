using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class RagdollManager : MonoBehaviour
    {
        [SerializeField] private GameObject _ragdoll;
        [SerializeField] private List<RagdollLimb> _limbs;

        private void Awake()
        {
            _ragdoll.SetActive(false);
        }

        public void SetRagdollActive()
        {
            _ragdoll.SetActive(true);
            
            _limbs.ForEach(x => x.SetLimb());
        }
    }
}