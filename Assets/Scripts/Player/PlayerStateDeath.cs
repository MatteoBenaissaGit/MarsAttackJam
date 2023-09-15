using Player;
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
        PlayerController.Instance.Ragdoll.SetRagdollActive();
        PlayerController.Instance.Character.SetActive(false);

        PlayerController.Instance.CurrentFOV = PlayerController.Instance.Data.DeathFOV;
        PlayerController.Instance.CameraTarget.parent = PlayerController.Instance.Data.DeathCameraParent;
        
        //lock cam
        PlayerController.Instance.FreeLookCamera.m_XAxis.m_MaxSpeed = 0;
        PlayerController.Instance.FreeLookCamera.m_YAxis.m_MaxSpeed = 0;
        
        //game over
        PlayerController.Instance.GameOverAnimator.SetTrigger("GameOver");
        PlayerController.Instance.GameOverAnimator.gameObject.SetActive(true);
    }

    public override void End()
    {
        
    }
}