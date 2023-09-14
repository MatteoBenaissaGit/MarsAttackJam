using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    None = 0,
    Spawn = 1,
    Walk = 2,
    Attack = 3,
    Death = 4
}

public abstract class AIStateBase
{

    public abstract AIController Controller { get; set; }
    
    public abstract AIState State { get; set; }

    public abstract void Update();

    public abstract void Start();

    public abstract void End();
}