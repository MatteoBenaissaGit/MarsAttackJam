using Player;

public class AIStateDeath : AIStateBase
{
    public AIStateDeath(AIController controller)
    {
        Controller = controller;
    }
    
    public override AIController Controller { get; set; }
    public override AIState State { get; set; } = AIState.Death;

    public override void Update()
    {
        
    }

    public override void Start()
    {
        Controller.DeathParticle.Play();
        Controller.DeathParticle.transform.parent = null;
        Controller.DestroyItself();
        
        PlayerController.Instance.SetKill();
    }

    public override void End()
    {
        
    }
}