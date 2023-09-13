using UnityEngine;

public class PlayerStateDeath : PlayerStateBase
{
    public override PlayerState State { get; set; } = PlayerState.Death;
    public override bool CanBeEnded { get; set; } = false;

    public override void Update()
    {
        
    }

    public override void FixedUpdate()
    {
        
    }

    public override void Start()
    {
        PlayerController.Instance.Rigidbody.velocity = Vector3.zero;
    }

    public override void End()
    {
        
    }
}