using System;
using AI;
using Data.Enemy;
using Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class AIController : MonoBehaviour
{
    [field:SerializeField] public Transform EnemyTransform { get; private set; }
    [field:SerializeField] public Animator EnemyAnimator { get; private set; }
    [field:SerializeField] public EnemyLifeController LifeController { get; private set; }
    [field:SerializeField] public EnemyData Data { get; private set; }
    [field:SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }
    [field:SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field:SerializeField] public LineRenderer LineShootRenderer { get; private set; }
    [field:SerializeField] public Transform GunTransform { get; private set; }
    [field:SerializeField] public ParticleSystem DeathParticle { get; private set; }
    [field:SerializeField] public RagdollManager Ragdoll { get; private set; }
    [field:SerializeField] public GameObject CharacterMesh { get; private set; }
    [field:SerializeField] public Collider Collider { get; private set; }
    [field:SerializeField] public Data.Bonus.BonusData Bonus { get; private set; }
    
    public AIDetection Detection { get; private set; }
    public bool SeePlayer { get; private set; } 

    private AIStateBase _currentAIState;

    private float _timerCollect;

    private void Awake()
    {
        _currentAIState = new AIStateSpawn(this);
        _currentAIState.Start();
    }
    
    private void Start()
    {
        LifeController.onDeath += SetDeath;

        NavMeshAgent.speed = Data.WalkSpeed;
        
        Detection = new AIDetection(PlayerController.Instance.RaycastTarget, this);
    }
    
    private void Update()
    {
        UpdateCurrentState();

        SeePlayer = Detection.SeePlayer();
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
    
    public void SetAIState(AIState state)
    {
        if (_currentAIState.State == state)
        {
            return;
        }

        _currentAIState.End();
        
        switch (state)
        {
            case AIState.Spawn:
                _currentAIState = new AIStateSpawn(this);
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

    public void DropBonus(GameObject bonus)
    {
        Instantiate(bonus, CharacterMesh.transform.position, Quaternion.identity);
    }
}