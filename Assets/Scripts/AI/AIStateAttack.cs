using DG.Tweening;
using Player;
using UnityEngine;

public class AIStateAttack : AIStateBase
{
    public AIStateAttack(AIController controller)
    {
        Controller = controller;
    }
    
    public override AIController Controller { get; set; }
    public override AIState State { get; set; } = AIState.Attack;

    private float _attackTimer;
    private float _attackLaunchTimer;

    private Vector3 _playerPosition;
    private bool _attackLaunched;

    public override void Update()
    {
        if (Controller.LifeController.HoldTimeShoot > 0)
        {
            Controller.SetAIState(AIState.Walk);
            return;
        }
        
        _attackTimer -= Time.deltaTime;
        _attackLaunchTimer -= Time.deltaTime;

        if (_attackLaunchTimer <= 0 && _attackLaunched == false)
        {
            _playerPosition = new Vector3(_playerPosition.x, _playerPosition.y, _playerPosition.z);
            
            Controller.LineShootRenderer.useWorldSpace = true;

            Vector3 gun = Controller.GunTransform.position;
            Controller.LineShootRenderer.SetPosition(0,gun);
            Vector3 direction = (_playerPosition - gun).normalized;
            float currentDistance = Vector3.Distance(gun, _playerPosition);
            Vector3 newEndPoint = gun + direction * (currentDistance * 2);
            Controller.LineShootRenderer.SetPosition(1,newEndPoint);

            _attackLaunched = true;
            Controller.AISound.ShootSoundEffect();
        }

        if (_attackLaunched)
        {
            if (Controller.Detection.AttackableInRay(_playerPosition) != null)
            {
                Controller.Detection.AttackableInRay(_playerPosition).TakeDamage(Controller.transform.gameObject, Controller.Data.Damage);
            }
        }

        if (_attackTimer <= 0)
        {
            Controller.LineShootRenderer.SetPosition(0,Vector3.zero);
            Controller.LineShootRenderer.SetPosition(1,Vector3.zero);
            Controller.SetAIState(AIState.Walk);
        }
        
        Controller.Rigidbody.velocity = Vector3.Lerp(Controller.Rigidbody.velocity, Vector3.zero, 0.01f);
    }

    public override void Start()
    {
        if (Controller.EnemyAnimator != null)
        {
            Controller.EnemyAnimator.SetBool("attackAI", true);
        }

        Controller.NavMeshAgent.isStopped = true;

        _attackLaunchTimer = Controller.Data.TimeToAttackAfterDetection;
        _attackTimer = Controller.Data.AttackTime;

        _playerPosition = PlayerController.Instance.RaycastTarget.position;
        
        //rotate
        Vector3 lookAtPosition = new Vector3(_playerPosition.x, Controller.EnemyTransform.transform.position.y, _playerPosition.z);
        Vector3 direction = lookAtPosition - Controller.EnemyTransform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Controller.EnemyTransform.DORotateQuaternion(targetRotation, 0.25f);
    }

    public override void End()
    {
        if (Controller.EnemyAnimator != null)
        {
            Controller.EnemyAnimator.SetBool("attackAI", false);
        }

        _attackLaunched = false;
    }

    public void GiveDamage(IAttackable attackable)
    {
        
    }
}