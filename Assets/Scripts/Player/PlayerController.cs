using System;
using UnityEngine;

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
    }

    #endregion

    private PlayerStateBase _currentPlayerState;
    
    private void Update()
    {
        UpdateCurrentState();
    }

    #region StateControl

    private void UpdateCurrentState()
    {
        _currentPlayerState.Update();
    }

    private void SetPlayerState(PlayerState state)
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
        }
        
        _currentPlayerState.Start();
    }

    #endregion
    
    
}