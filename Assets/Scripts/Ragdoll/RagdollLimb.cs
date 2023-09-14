using UnityEngine;

namespace Player
{
    public class RagdollLimb : MonoBehaviour
    {
        [SerializeField] private Transform _copy;

        public void SetLimb()
        {
            transform.rotation = _copy.rotation;
            transform.position = _copy.position;
            transform.localScale = _copy.localScale;
        }
    }
}