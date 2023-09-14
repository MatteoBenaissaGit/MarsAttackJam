using System;
using DG.Tweening;
using Player;
using UnityEngine;

public class PlayerStateWalk : PlayerStateBase
{
    public override PlayerState State { get; set; } = PlayerState.Walk;
    public override bool CanBeEnded { get; set; } = true;

    private Vector3 _movementVector;
    private WalkDirection _walkDirectionCurrent;
    
    public override void Update()
    {
        ManageAnimationMovement();
        ManageRotation();
    }

    public override void FixedUpdate()
    {
        ManageMovement();
    }

    public override void Start()
    {
        PlayerController.Instance.Animator.SetBool("Walk",true);
        PlayerController.Instance.CurrentFOV = PlayerController.Instance.Data.RunFOV;
    }

    public override void End()
    {
        PlayerController.Instance.Animator.SetBool("Walk",false);
        PlayerController.Instance.CurrentFOV = PlayerController.Instance.Data.BaseFOV;
    }

    private Vector3 GetMoveDirection()
    {
        Vector3 cameraForward = PlayerController.Instance.Camera.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        float horizontalInput = PlayerController.Instance.MoveInput.x;
        float verticalInput = PlayerController.Instance.MoveInput.y;
        
        return cameraForward * verticalInput + PlayerController.Instance.Camera.transform.right * horizontalInput;
    }
    
    private void ManageMovement()
    {
        Vector3 moveDirection = GetMoveDirection();

        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        Rigidbody rb = PlayerController.Instance.Rigidbody;
        float speed = PlayerController.Instance.Data.WalkSpeed;
        rb.velocity = (moveDirection * speed) + new Vector3(0,-PlayerController.Instance.Data.GravityAfterApexJump,0);
    }
    
    private void ManageAnimationMovement()
    {
        Vector3 cameraForward = PlayerController.Instance.Camera.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        float horizontalInput = PlayerController.Instance.MoveInput.x;
        float verticalInput = PlayerController.Instance.MoveInput.y;
        
        Animator animator = PlayerController.Instance.Animator;
        WalkDirection direction = WalkDirection.None;
        if (verticalInput != 0)
        {
            direction = verticalInput > 0 ? WalkDirection.Front : WalkDirection.Back;
        }
        else
        {
            direction = horizontalInput > 0 ? WalkDirection.Right : WalkDirection.Left;
        }

        if (direction == _walkDirectionCurrent)
        {
            return;
        }

        _walkDirectionCurrent = direction;
        switch (_walkDirectionCurrent)
        {
            case WalkDirection.Front:
                animator.SetTrigger("Front");
                break;
            case WalkDirection.Back:
                animator.SetTrigger("Back");
                break;
            case WalkDirection.Left:
                animator.SetTrigger("Left");
                break;
            case WalkDirection.Right:
                animator.SetTrigger("Right");
                break;
        }
    }

    private void ManageRotation()
    {
        Vector3 cameraForward = PlayerController.Instance.Camera.transform.forward;
        cameraForward.y = 0f;

        if (cameraForward != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(cameraForward);
            PlayerController.Instance.Character.transform.DOKill();
            PlayerController.Instance.Character.transform.DORotateQuaternion(newRotation, 0.2f);
        }
        
        float horizontalInput = PlayerController.Instance.MoveInput.x;
        float verticalInput = PlayerController.Instance.MoveInput.y;
        if (verticalInput != 0 && horizontalInput != 0)
        {
            Quaternion rotation = PlayerController.Instance.Character.transform.rotation;
            Vector3 euler = rotation.eulerAngles;
            float diff = horizontalInput > 0 ? 60 : -60;
            Quaternion newRotation = Quaternion.Euler(euler.x,euler.y + diff,euler.z);
            PlayerController.Instance.Character.transform.DORotateQuaternion(newRotation, 0.2f);
        }
    }
}

public enum WalkDirection
{
    None = 0,
    Back = 1,
    Left = 2,
    Right = 3,
    Front = 4
}