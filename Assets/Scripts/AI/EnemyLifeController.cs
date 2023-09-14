using System;
using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace AI
{
    public class EnemyLifeController : MonoBehaviour, IAttackable
    {
        public Action<float> onDamage;
        public Action onDeath;
        
        [field:SerializeField] public Image LifeBar { get; private set; }
        [field:SerializeField] public AIController AIController { get; private set; }

        private float _life;
        private float _invicibility;

        private void Awake()
        {
            onDamage += Damage;
            
            _life = AIController.Data.Life;
            LifeBar.DOFillAmount(_life / AIController.Data.Life,0.2f);
        }

        private void Update()
        {
            _invicibility -= Time.deltaTime;
            
            LifeBar.transform.LookAt(PlayerController.Instance.Camera.transform);
        }

        private void Damage(float damage)
        {
            if (_invicibility > 0)
            {
                return;
            }
            
            LifeBar.DOFillAmount(_life / AIController.Data.Life,0.2f);
            LifeBar.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f);

            _life -= damage;
            Debug.Log(_life);
            if (_life < 0)
            {
                onDeath.Invoke();
            }

            _invicibility = AIController.Data.InvincibilityTimeAfterHit;
        }
        
        public void TakeDamage(IAttacker attacker, float damage)
        {
            onDamage.Invoke(damage);
        }
    }
}