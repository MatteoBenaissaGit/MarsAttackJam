public class AIStateIdle : AIStateBase
{
    public override AIState State { get; set; } = AIState.Idle;


    public override void Update()
    {
        
    }

    public override void Start()
    {
        AIController.Instance.childAnimator.SetBool("idle", true);
    }

    public override void End()
    {
        AIController.Instance.childAnimator.SetBool("idle", false);
    }
}