using Player;
using UnityEngine;

public class AIStateDeath : AIStateBase
{
    public AIStateDeath(AIController controller)
    {
        Controller = controller;
    }
    
    public override AIController Controller { get; set; }
    public override AIState State { get; set; } = AIState.Death;

    public override void Update()
    {
        
    }

    public override void Start()
    {
        Controller.DeathParticle.Play();

        Controller.Collider.enabled = false;
        Controller.Rigidbody.isKinematic = true;

        PlayerController.Instance.SetKill();
        
        Controller.CharacterMesh.SetActive(false);
        Controller.Ragdoll.SetRagdollActive(new []{true});

        Controller.LineShootRenderer.enabled = false;
        
        DropBonus();
    }

    public override void End()
    {
        
    }

    public void DropBonus()
    {
        int random = Random.Range(0, Controller.Bonus.BonusPrefab.Length);
        bool drop = Random.Range(0, 100) < 50;

        if (drop == false)
        {
            return;
        }

        GameObject go = Controller.Bonus.BonusPrefab[random];
        Controller.DropBonus(go);
    }
}