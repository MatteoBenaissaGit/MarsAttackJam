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

    public override void Update()
    {
        _attackTimer -= Time.deltaTime;

        if (_attackTimer <= 0)
        {
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
        _attackTimer = Controller.Data.AttackTime;
    }

    public override void End()
    {
        if (Controller.EnemyAnimator != null)
        {
            Controller.EnemyAnimator.SetBool("attackAI", false);
        }
    }
}