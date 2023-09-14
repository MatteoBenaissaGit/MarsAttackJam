using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerLifeController : MonoBehaviour, IAttackable
    {
        [field: SerializeField] public Image LifeBar;
        
        public Action<float> onDamage;
        public Action onDeath;

        public GameObject AttackerObject { get; set; }

        public float _life;
        private float _invincibleTime;

        private void Awake()
        {
            onDamage += Damage;
            LifeBar.fillAmount = 1;
            AttackerObject = gameObject;
        }

        private void Start()
        {
            _life = PlayerController.Instance.Data.Life;
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
            if (_invincibleTime > 0)
            {
                return;
            }
            
            _invincibleTime = PlayerController.Instance.Data.InvincibleTimeAfterHit;

            _life -= damage;
            
            LifeBar.DOFillAmount(_life / PlayerController.Instance.Data.Life,0.2f);
            LifeBar.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f);
            LifeBar.DOColor(Color.Lerp(PlayerController.Instance.Data.LowLifeColor, PlayerController.Instance.Data.FullLifeColor, LifeBar.fillAmount), 0.2f);

            if (_life <= 0)
            {
                onDeath.Invoke();
            }
        }

        public void Heal(int gain)
        {
            if (_life < PlayerController.Instance.Data.Life)
                _life += gain;
            else
                _life = PlayerController.Instance.Data.Life;
        }
    }
}