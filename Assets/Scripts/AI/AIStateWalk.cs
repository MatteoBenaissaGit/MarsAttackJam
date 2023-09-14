using Player;
using UnityEngine;

public class AIStateWalk : AIStateBase
{
    public AIStateWalk(AIController controller)
    {
        Controller = controller;
    }

    public override AIController Controller { get; set; }
    public override AIState State { get; set; } = AIState.Walk;

    public override void Update()
    {
        Vector3 playerPosition = PlayerController.Instance.Character.transform.position;
        Controller.NavMeshAgent.SetDestination(playerPosition);

        float distance = Vector3.Distance(Controller.EnemyTransform.position, playerPosition);
        
        if (Controller.SeePlayer && distance < Controller.Data.DistanceToAttack)
        {
            Controller.SetAIState(AIState.Attack);
        }
        
        Controller.Rigidbody.velocity = Vector3.Lerp(Controller.Rigidbody.velocity, Vector3.zero, 0.01f);
    }

    public override void Start()
    {
        Controller.NavMeshAgent.isStopped = false;
        
        if (Controller.EnemyAnimator != null)
        {
            Controller.EnemyAnimator.SetBool("walkAI", true);
        }
    }

    public override void End()
    {
        if (Controller.EnemyAnimator != null)
        {
            Controller.EnemyAnimator.SetBool("walkAI", false);
        }
    }
}