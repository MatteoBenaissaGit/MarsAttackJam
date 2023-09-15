using UnityEngine;

namespace DefaultNamespace.Physic
{
    public class ObjectPunchable : MonoBehaviour, IAttackable
    {
        [field:SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field:SerializeField] public float Force { get; private set; }
        [field:SerializeField] public float UpForce { get; private set; }
        
        public void TakeDamage(GameObject attacker, float damage)
        {
            if (Rigidbody == null)
            {
                return;
            }
            
            Vector3 direction = transform.position - attacker.transform.position;
            direction.Normalize();
            Rigidbody.AddForce((direction * Force) + Vector3.up * UpForce);
            
            Debug.Log("punch");
        }
    }
}