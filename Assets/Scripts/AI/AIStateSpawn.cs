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
            //timer avec animation de spawn puis passage au walk
            Controller.EnemyTransform.localScale = Vector3.zero;
            Controller.gameObject.transform.DOScale(1, _timer);

            _timer = Controller.Data.SpawnTimer;

            if (Controller.EnemyAnimator != null)
            {
                Controller.EnemyAnimator.SetBool("idleAI", true);
            }

            Controller.SetAIState(AIState.Walk);
        }

        public override void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                //Controller.SetAIState(AIState.Walk);
                Debug.Log("timer");
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