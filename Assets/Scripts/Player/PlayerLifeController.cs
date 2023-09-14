using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerLifeController : MonoBehaviour, IAttackable
    {
        [field: SerializeField] public Image LifeBar;
        
        public Action<float> onDamage;
        public Action onDeath;

        private float _life;
        private float _invincibleTime;

        private void Awake()
        {
            onDamage += Damage;
            LifeBar.fillAmount = 1;
        }

        private void Update()
        {
            _invincibleTime -= Time.deltaTime;
        }

        public void TakeDamage(IAttacker attacker, float damage)
        {
            if (_invincibleTime > 0)
            {
                return;
            }
            
            onDamage.Invoke(damage);
        }

        private void Damage(float damage)
        {
            _invincibleTime = PlayerController.Instance.Data.InvincibleTimeAfterHit;
            
            LifeBar.DOFillAmount(_life / PlayerController.Instance.Data.Life,0.2f);
            LifeBar.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f);
            LifeBar.DOColor(Color.Lerp(PlayerController.Instance.Data.LowLifeColor, PlayerController.Instance.Data.FullLifeColor, LifeBar.fillAmount), 0.2f);

            _life -= damage;
            if (_life < 0)
            {
                onDeath.Invoke();
            }
        }
    }
}