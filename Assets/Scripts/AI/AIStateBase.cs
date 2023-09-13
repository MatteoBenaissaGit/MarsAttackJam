public enum AIState
{
    Idle = 0,
    Walk = 1,
    Attack = 2,
    Death = 3
}

public abstract class AIStateBase
{
    public abstract AIState State { get; set; }
    
    public abstract void Update();

    public abstract void Start();

    public abstract void End();
}