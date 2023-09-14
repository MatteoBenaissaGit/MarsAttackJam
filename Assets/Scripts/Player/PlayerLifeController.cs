using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Player
{
    public class PlayerLifeController : MonoBehaviour, IAttackable
    {
        [field: SerializeField] public Image LifeBar;
        [field: SerializeField] public ParticleSystem HitParticle;
        
        public Action<float> onDamage;
        public Action onDeath;

        public GameObject AttackerObject { get; set; }

        [HideInInspector] public float Life;
        private float _invincibleTime;

        private void Awake()
        {
            onDamage += Damage;
            LifeBar.fillAmount = 1;
            AttackerObject = gameObject;
        }

        private void Start()
        {
            Life = PlayerController.Instance.Data.Life;
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

            Life -= damage;
            
            HitParticle.Play();
            
            SetLifeBar();

            if (Life <= 0)
            {
                onDeath.Invoke();
            }
        }

        private void SetLifeBar()
        {
            LifeBar.DOFillAmount(Life / PlayerController.Instance.Data.Life, 0.2f);
            LifeBar.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f);
            LifeBar.DOColor(
                Color.Lerp(PlayerController.Instance.Data.LowLifeColor, PlayerController.Instance.Data.FullLifeColor,
                    LifeBar.fillAmount), 0.2f);
        }

        public void Heal(int gain)
        {
            if (Life < PlayerController.Instance.Data.Life)
            {
                Life += gain;
            }
            else
            {
                Life = PlayerController.Instance.Data.Life;
            }
            
            SetLifeBar();
        }
    }
}