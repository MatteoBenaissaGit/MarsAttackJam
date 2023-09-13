using System;
using UnityEngine;

public class AIController : MonoBehaviour
{
    #region Singleton

    public static AIController Instance;
    public Animator childAnimator;

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

        _currentAIState = new AIStateIdle();

        childAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    #endregion

    private AIStateBase _currentAIState;
    
    private void Update()
    {
        UpdateCurrentState();
    }

    #region StateControl

    private void UpdateCurrentState()
    {
        _currentAIState.Update();
    }

    private void SetAIState(AIState state)
    {
        if (_currentAIState.State == state)
        {
            return;
        }

        _currentAIState.End();
        
        switch (state)
        {
            case AIState.Idle:
                _currentAIState = new AIStateIdle();
                break;
            case AIState.Walk:
                _currentAIState = new AIStateWalk();
                break;
            case AIState.Attack:
                _currentAIState = new AIStateAttack();
                break;
            case AIState.Death:
                _currentAIState = new AIStateDeath();
                break;
        }
        
        _currentAIState.Start();
    }

    #endregion
    
    
}