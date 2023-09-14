using Player;

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