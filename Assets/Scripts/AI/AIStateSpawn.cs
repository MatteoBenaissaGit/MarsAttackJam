﻿using UnityEngine;
using DG.Tweening;

namespace AI
{
    public class AIStateSpawn : AIStateBase
    {
        public AIStateSpawn(AIController controller)
        {
            Controller = controller;
        }

        public override AIController Controller { get; set; }
        public override AIState State { get; set; } = AIState.Spawn;

        public int timer;
    
        public override void Update()
        {
            //timer avec animation de spawn puis passage au walk

            Controller.gameObject.transform.DOScale(1, timer);
        }

        public override void Start()
        {
            timer = Controller.Data.SpawnTimer;

            if (Controller.EnemyAnimator != null)
            {
                Controller.EnemyAnimator.SetBool("idleAI", true);
            }
            
            Controller.SetAIState(AIState.Walk);
        }

        public override void End()
        {
            if (Controller.EnemyAnimator != null)
            {
                Controller.EnemyAnimator.SetBool("idleAI", false);
            }
        }
    }
}