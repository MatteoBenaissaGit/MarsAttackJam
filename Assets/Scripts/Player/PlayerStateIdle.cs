using DG.Tweening;
using Player;
using UnityEngine;

public class PlayerStateIdle : PlayerStateBase
{
    public override PlayerState State { get; set; } = PlayerState.Idle;
    public override bool CanBeEnded { get; set; } = true;
    
    public override void Update()
    {
        ManageRotation();
    }

    public override void FixedUpdate()
    {
        PlayerController.Instance.Rigidbody.AddForce(Vector3.down * PlayerController.Instance.Data.GravityAfterApexJump);
    }

    public override void Start()
    {
        PlayerController.Instance.Rigidbody.velocity = Vector3.zero;
        PlayerController.Instance.CheckForMovementInput();
    }

    public override void End()
    {
    }
    
    private void ManageRotation()
    {
        Vector3 cameraForward = PlayerController.Instance.Camera.transform.forward;
        cameraForward.y = 0f;

        if (cameraForward != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(cameraForward);

            float angle = PlayerController.Instance.Data.AngleToResetRotationInIdle;
            bool isTurning = Quaternion.Angle(newRotation, PlayerController.Instance.Character.transform.rotation) > angle;
            if (isTurning == false)
            {
                return;
            }
            
            PlayerController.Instance.Character.transform.DORotateQuaternion(newRotation,0.5f) ;
        }
    }
}