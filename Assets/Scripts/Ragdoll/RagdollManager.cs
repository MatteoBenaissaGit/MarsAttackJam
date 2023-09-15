using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class RagdollManager : MonoBehaviour
    {
        [SerializeField] private GameObject _ragdoll;
        [SerializeField] private List<RagdollLimb> _limbs;
        [SerializeField] private Rigidbody _hips;
        [SerializeField] private float _timeBeforeDeactivatingPhysic;

        private float _timer = 1;
        private bool _isActive;

        private void Awake()
        {
            _ragdoll.SetActive(false);
        }

        private void Update()
        {
            if (_isActive == false)
            {
                return;
            }

            _timer -= Time.deltaTime;

            if (_timer < 0)
            {
                _isActive = false;
                _limbs.ForEach(x => x.GetComponent<Rigidbody>().isKinematic = true);
                _limbs.ForEach(x => Destroy(x.GetComponent<Collider>()));
                _limbs.ForEach(x => x.transform.gameObject.isStatic = true);
            }
        }

        public void SetRagdollActive(params bool[] addForce)
        {
            _ragdoll.SetActive(true);
            _isActive = true;
            _timer = _timeBeforeDeactivatingPhysic;
            
            _limbs.ForEach(x => x.SetLimb());

            if (addForce == null || addForce.Length == 0 || _hips == null)
            {
                return;
            }
            
            Vector3 direction = transform.position - PlayerController.Instance.transform.position;
            direction.Normalize();
            _hips.AddForce(Vector3.up * Random.Range(1500,3000));
            _hips.AddForce(direction * Random.Range(1500,3000));
        }
    }
}