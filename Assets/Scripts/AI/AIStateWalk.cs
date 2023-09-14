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
        Controller.NavMeshAgent.SetDestination(PlayerController.Instance.Character.transform.position);

        float distance = Vector3.Distance(Controller.transform.position, PlayerController.Instance.Character.transform.position;
        //Debug.Log($"see {Controller.SeePlayer}");
        Debug.Log($"distance {distance}");
        
        if (Controller.SeePlayer
            && Vector3.Distance(Controller.transform.position, PlayerController.Instance.Character.transform.position) < Controller.Data.DistanceToAttack)
        {
            Controller.SetAIState(AIState.Attack);
        }
    }

    public override void Start()
    {
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