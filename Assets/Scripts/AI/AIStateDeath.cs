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

        Controller.Collider.enabled = false;
        Controller.Rigidbody.isKinematic = true;

        PlayerController.Instance.SetKill();
        
        Controller.CharacterMesh.SetActive(false);
        Controller.Ragdoll.SetRagdollActive();
    }

    public override void End()
    {
        
    }
}