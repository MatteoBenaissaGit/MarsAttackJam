using UnityEngine;

namespace Player
{
    public class PlayerStateJump : PlayerStateBase
    {
        public override PlayerState State { get; set; } = PlayerState.Jump;
        public override bool CanBeEnded { get; set; } = false;
        
        private float _raycastDistance = 0.1f;
        private float _timer = 1f;
        
        public override void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > 2)
            {
                PlayerController.Instance.SetPlayerState(PlayerState.Idle);
            }
            
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
            ManageMovement();
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

        private void ManageMovement()
        {
            Vector3 moveDirection = PlayerStateWalk.GetMoveDirection();

            if (moveDirection.magnitude > 1)
            {
                moveDirection.Normalize();
            }

            Rigidbody rb = PlayerController.Instance.Rigidbody;
            float speed = PlayerController.Instance.Data.WalkSpeed;
            Vector3 velocity = (moveDirection * speed * 0.5f);
            rb.velocity = new Vector3(velocity.x,rb.velocity.y,velocity.z);
        }
    }
}