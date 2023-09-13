public enum PlayerState
{
    Idle = 0,
    Walk = 1,
    Attack = 2,
    Death = 3
}

public abstract class PlayerStateBase
{
    public abstract PlayerState State { get; set; }
    public abstract bool CanBeEnded { get; set; }
    
    public abstract void Update();

    public abstract void Start();

    public abstract void End();
}