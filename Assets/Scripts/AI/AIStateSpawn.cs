using UnityEngine;
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

        private float _timer;


        public override void Start()
        {
            _timer = Controller.Data.SpawnTimer;
            
            Controller.EnemyTransform.localScale = Vector3.zero;
            Controller.EnemyTransform.DOScale(Vector3.one, _timer);

            if (Controller.EnemyAnimator != null)
            {
                Controller.EnemyAnimator.SetBool("idleAI", true);
            }
        }

        public override void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer < 0)
            {
                Controller.SetAIState(AIState.Walk);
            }
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