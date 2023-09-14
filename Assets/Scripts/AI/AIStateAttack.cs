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

    public override void Update()
    {
        _attackTimer -= Time.deltaTime;
        _attackLaunchTimer -= Time.deltaTime;

        if (_attackLaunchTimer <= 0)
        {
            Controller.LineShootRenderer.SetPosition(0,Controller.GunTransform.position);
            Controller.LineShootRenderer.SetPosition(1,PlayerController.Instance.RaycastTarget.position);
        }

        if (_attackTimer <= 0)
        {
            Controller.LineShootRenderer.SetPosition(0,Vector3.zero);
            Controller.LineShootRenderer.SetPosition(1,Vector3.zero);
            Controller.SetAIState(AIState.Walk);
        }
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
    }

    public override void End()
    {
        if (Controller.EnemyAnimator != null)
        {
            Controller.EnemyAnimator.SetBool("attackAI", false);
        }
    }
}