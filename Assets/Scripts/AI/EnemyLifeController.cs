using System;
using System.Threading.Tasks;
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
        [field:SerializeField] public Transform LifeBarParent { get; private set; }
        [field:SerializeField] public AIController AIController { get; private set; }
        public float HoldTimeShoot { get; set; }
        public GameObject AttackerObject { get; set; }

        private float _life;
        private float _invicibility;

        private void Awake()
        {
            onDamage += Damage;
            
            _life = AIController.Data.Life;
            LifeBar.DOFillAmount(_life / AIController.Data.Life,0.2f);

            AttackerObject = gameObject;
        }

        private void Update()
        {
            _invicibility -= Time.deltaTime;
            HoldTimeShoot -= Time.deltaTime;
            
            LifeBarParent.transform.LookAt(PlayerController.Instance.Camera.transform);
        }

        private void Damage(float damage)
        {
            if (_invicibility > 0)
            {
                return;
            }
            
            _life -= damage;

            LifeBar.DOFillAmount(_life / AIController.Data.Life,0.2f);
            LifeBar.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f);

            HoldTimeShoot = 2f;
            
            PlayerController.Instance.HitStopEffectController.StartHitStop();
            
            if (_life <= 0)
            {
                onDeath.Invoke();
                return;
            }

            _invicibility = AIController.Data.InvincibilityTimeAfterHit;
            AIController.SetAIState(AIState.Walk);
            
            HitImpactRigidbody();
            
        }

        private async void HitImpactRigidbody()
        {
            Vector3 direction = PlayerController.Instance.Character.transform.position - AIController.transform.position;
            AIController.Rigidbody.AddForce(-direction * 100);
            await StopVelocity(AIController);
        }

        private static async Task StopVelocity(AIController controller)
        {
            await Task.Delay(250);
            controller.Rigidbody.velocity = Vector3.zero;
        }
        
        public void TakeDamage(IAttacker attacker, float damage)
        {
            onDamage.Invoke(damage);
        }
    }
}