using DG.Tweening;
using Player;
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

    public override void FixedUpdate()
    {
        
    }

    public override void Start()
    {
        PlayerController.Instance.Rigidbody.velocity = Vector3.zero;

        _attackTime = PlayerController.Instance.Data.AttackTime;
        
        //rotation
        Vector3 cameraForward = PlayerController.Instance.Camera.transform.forward;
        cameraForward.y = 0f;
        if (cameraForward != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(cameraForward);
            PlayerController.Instance.Character.transform.DORotateQuaternion(newRotation, 0.2f);
        }
        
        //anim
        PlayerController.Instance.Animator.SetTrigger("Attack");
        
        //lock cam
        PlayerController.Instance.FreeLookCamera.m_XAxis.m_MaxSpeed = 0;
        PlayerController.Instance.FreeLookCamera.m_YAxis.m_MaxSpeed = 0;
        
        //hurtbox
        PlayerController.Instance.HurtBoxes.ForEach(x => x.Set(true));
    }

    public override void End()
    {
        //unlock cam
        PlayerController.Instance.FreeLookCamera.m_XAxis.m_MaxSpeed = PlayerController.Instance.Data.CameraXSpeed;
        PlayerController.Instance.FreeLookCamera.m_YAxis.m_MaxSpeed = PlayerController.Instance.Data.CameraYSpeed;
        
        //hurtbox
        PlayerController.Instance.HurtBoxes.ForEach(x => x.Set(false));

    }
}