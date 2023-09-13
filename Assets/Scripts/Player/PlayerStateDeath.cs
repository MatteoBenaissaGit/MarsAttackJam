public class PlayerStateDeath : PlayerStateBase
{
    public override PlayerState State { get; set; } = PlayerState.Death;
    public override bool CanBeEnded { get; set; } = false;

    public override void Update()
    {
        
    }

    public override void Start()
    {
        
    }

    public override void End()
    {
        
    }
}