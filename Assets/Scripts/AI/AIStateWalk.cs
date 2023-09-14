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
    }

    public override void Start()
    {
        
    }

    public override void End()
    {
        
    }
}