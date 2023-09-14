public class AIStateAttack : AIStateBase
{
    public AIStateAttack(AIController controller)
    {
        Controller = controller;
    }
    
    public override AIController Controller { get; set; }
    public override AIState State { get; set; } = AIState.Attack;

    public override void Update()
    {
        
    }

    public override void Start()
    {
        if (Controller.EnemyAnimator != null)
        {
            Controller.EnemyAnimator.SetBool("attackAI", true);
        }
    }

    public override void End()
    {
        if (Controller.EnemyAnimator != null)
        {
            Controller.EnemyAnimator.SetBool("attackAI", false);
        }
    }
}