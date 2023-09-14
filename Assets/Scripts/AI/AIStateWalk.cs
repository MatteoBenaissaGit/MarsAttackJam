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
        //TODO setup le navmeshagent (Controller.NavMeshAgent) pour se diriger vers le joueur

        //Controller.NavMeshAgent.SetDestination(transform.position);
    }

    public override void Start()
    {
        if (Controller.ChildAnimator != null)
        {
            Controller.ChildAnimator.SetBool("walkAI", true);
        }
    }

    public override void End()
    {
        if (Controller.ChildAnimator != null)
        {
            Controller.ChildAnimator.SetBool("walkAI", false);
        }
    }
}