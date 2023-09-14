using UnityEngine;

namespace AI
{
    public class AIStateIdle : AIStateBase
    {
        public AIStateIdle(AIController controller)
        {
            Controller = controller;
        }

        public override AIController Controller { get; set; }
        public override AIState State { get; set; } = AIState.Idle;
    
        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Controller.cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Controller.NavMeshAgent.SetDestination(hit.point);
                }
            }
        }

        public override void Start()
        {
            if (Controller.ChildAnimator != null)
            {
                Controller.ChildAnimator.SetBool("idleAI", true);
            }
        }

        public override void End()
        {
            if (Controller.ChildAnimator != null)
            {
                Controller.ChildAnimator.SetBool("idleAI", false);
            }
        }
    }
}