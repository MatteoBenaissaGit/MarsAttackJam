﻿using System.Collections.Generic;
using Cinemachine;
using Data.PlayerDataScriptable;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Singleton

        public static PlayerController Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            _currentPlayerState = new PlayerStateIdle();
            Cursor.visible = false;
        }

        #endregion

        [field:SerializeField] public Camera Camera { get; private set; }
        [field:SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field:SerializeField] public GameObject Character { get; private set; }
        [field:SerializeField] public Animator Animator { get; private set; }
        [field:SerializeField] public PlayerData Data { get; private set; }
        [field:SerializeField] public CinemachineFreeLook FreeLookCamera { get; private set; }
        [field:SerializeField] public PlayerLifeController LifeController { get; private set; }
        [field:SerializeField] public List<PlayerHurtBoxController> HurtBoxes { get; private set; }
        public Vector2 MoveInput { get; private set; }
        public float CurrentFOV { get; set; }
    
        private PlayerStateBase _currentPlayerState;
        private CharacterInput _characterInputAction;

        private void Start()
        {
            _characterInputAction = new CharacterInput();
            _characterInputAction.Enable();

            Rigidbody.interpolation = RigidbodyInterpolation.Extrapolate;

            CurrentFOV = Instance.Data.BaseFOV;

            LifeController.onDeath += SetDeath;
        }

        private void Update()
        {
            UpdateCurrentState();
            SetFOV();
        }

        private void FixedUpdate()
        {
            FixedUpdateCurrentState();
        }

        #region StateControl

        private void UpdateCurrentState()
        {
            _currentPlayerState.Update();
        }

        private void FixedUpdateCurrentState()
        {
            _currentPlayerState.FixedUpdate();
        }

        private void SetDeath()
        {
            SetPlayerState(PlayerState.Death);
        }
        
        public void SetPlayerState(PlayerState state)
        {
            if (_currentPlayerState.State == state)
            {
                return;
            }

            _currentPlayerState.End();
        
            switch (state)
            {
                case PlayerState.Idle:
                    _currentPlayerState = new PlayerStateIdle();
                    break;
                case PlayerState.Walk:
                    _currentPlayerState = new PlayerStateWalk();
                    break;
                case PlayerState.Attack:
                    _currentPlayerState = new PlayerStateAttack();
                    break;
                case PlayerState.Death:
                    _currentPlayerState = new PlayerStateDeath();
                    break;
                case PlayerState.Jump:
                    _currentPlayerState = new PlayerStateJump();
                    break;
            }
        
            _currentPlayerState.Start();
        }

        #endregion

        #region Inputs

        public void SetAttack(InputAction.CallbackContext context)
        {
            if (_currentPlayerState.State == PlayerState.Attack
                || context.performed == false
                || _currentPlayerState.CanBeEnded == false)
            {
                return;
            }        
        
            SetPlayerState(PlayerState.Attack);
        }

        public void CheckForMovementInput()
        {
            Vector2 movement = _characterInputAction.Controls.Movement.ReadValue<Vector2>();
            if (movement.magnitude != 0)
            {
                SetPlayerState(PlayerState.Walk);
            }
        }
    
        public void SetMovement(InputAction.CallbackContext context)
        {
            MoveInput = context.ReadValue<Vector2>();

            if (MoveInput.magnitude == 0 
                && _currentPlayerState.State == PlayerState.Walk
                && _currentPlayerState.CanBeEnded)
            {
                SetPlayerState(PlayerState.Idle);
                return;
            }

            if (MoveInput.magnitude == 0
                || _currentPlayerState.CanBeEnded == false)
            {
                return;
            }
        
            SetPlayerState(PlayerState.Walk);
        }

        public void SetJump(InputAction.CallbackContext context)
        {
            if (_currentPlayerState.CanBeEnded == false)
            {
                return;
            }
        
            SetPlayerState(PlayerState.Jump);
        }

        #endregion

        private void SetFOV()
        {
            float lerpAmount = CurrentFOV > FreeLookCamera.m_Lens.FieldOfView ? 0.1f : 0.01f;
            FreeLookCamera.m_Lens.FieldOfView = Mathf.Lerp(FreeLookCamera.m_Lens.FieldOfView, CurrentFOV, lerpAmount);
        }
    }
}