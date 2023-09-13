using UnityEngine;

namespace Player
{
    public class PlayerStateJump : PlayerStateBase
    {
        public override PlayerState State { get; set; } = PlayerState.Jump;
        public override bool CanBeEnded { get; set; } = false;
        
        private float _raycastDistance = 0.1f;

        public override void Update()
        {
            if (PlayerController.Instance.Rigidbody.velocity.y > 0)
            {
                return;
            }

            PlayerController.Instance.Rigidbody.AddForce(Vector3.down * PlayerController.Instance.Data.GravityAfterApexJump);
            if (Physics.Raycast(PlayerController.Instance.Character.transform.position, Vector3.down, _raycastDistance))
            {
                PlayerController.Instance.SetPlayerState(PlayerState.Idle);
            }
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Start()
        {
            PlayerController.Instance.Rigidbody.velocity *= PlayerController.Instance.Data.VelocityReductionWhenJumpMultiplier;
            PlayerController.Instance.Rigidbody.AddForce(Vector3.up * PlayerController.Instance.Data.JumpForce);
            PlayerController.Instance.Animator.SetBool("Jump", true);
        }

        public override void End()
        {
            PlayerController.Instance.Animator.SetBool("Jump", false);
        }

    }
}