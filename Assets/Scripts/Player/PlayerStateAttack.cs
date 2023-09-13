using UnityEngine;

public class PlayerStateAttack : PlayerStateBase
{
    public override PlayerState State { get; set; } = PlayerState.Attack;
    public override bool CanBeEnded { get; set; } = false;

    private float _attackTime;

    public override void Update()
    {
        _attackTime -= Time.deltaTime;

        if (_attackTime <= 0)
        {
            PlayerController.Instance.SetPlayerState(PlayerState.Idle);
        }
    }

    public override void Start()
    {
        Debug.Log("attack start");
        _attackTime = 0.5f; //TODO data this
        PlayerController.Instance.Animator.SetTrigger("Attack");
    }

    public override void End()
    {
        Debug.Log("attack end");
    }
}