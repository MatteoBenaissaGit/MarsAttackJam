namespace AI
{
    public class AIStateIdle : AIStateBase
    {
        public AIStateIdle(AIController controller)
        {
            Controller = controller;
        }

        public override AIController Controller { get; set; }
        public override AIState State { get; set; } = AIState.Idle;
    
        public override void Update()
        {
        
        }

        public override void Start()
        {
            if (Controller.ChildAnimator != null)
            {
                Controller.ChildAnimator.SetBool("idle", true);
            }
        }

        public override void End()
        {
            if (Controller.ChildAnimator != null)
            {
                Controller.ChildAnimator.SetBool("idle", false);
            }
        }
    }
}