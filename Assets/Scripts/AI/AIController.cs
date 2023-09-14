using System;
using AI;
using Data.Enemy;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    
    [field:SerializeField] public Animator ChildAnimator { get; private set; }
    [field:SerializeField] public EnemyLifeController LifeController { get; private set; }
    [field:SerializeField] public EnemyData Data { get; private set; }
    [field:SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }
    
    public Camera cam;

    private AIStateBase _currentAIState;
    
    private void Awake()
    {
        ChildAnimator = transform.GetChild(0).GetComponent<Animator>();
        _currentAIState = new AIStateIdle(this);

        NavMeshAgent = GetComponent<NavMeshAgent>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    
    private void Start()
    {
        LifeController.onDeath += SetDeath;

        NavMeshAgent.speed = Data.WalkSpeed;
    }
    
    private void Update()
    {
        UpdateCurrentState();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                SetAIState(AIState.Walk);
                NavMeshAgent.SetDestination(hit.point);
            }
        }

        if(NavMeshAgent.acceleration == 0)
        {
            SetAIState(AIState.Idle);
        }
    }

    #region StateControl

    private void UpdateCurrentState()
    {
        _currentAIState.Update();
    }

    private void SetDeath()
    {
        SetAIState(AIState.Death);
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
                _currentAIState = new AIStateIdle(this);
                break;
            case AIState.Walk:
                _currentAIState = new AIStateWalk(this);
                break;
            case AIState.Attack:
                _currentAIState = new AIStateAttack(this);
                break;
            case AIState.Death:
                _currentAIState = new AIStateDeath(this);
                break;
        }
        
        _currentAIState.Start();
    }

    #endregion

    public void DestroyItself()
    {
        Destroy(this.gameObject);
    }
    
}