using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class HitStopEffect : MonoBehaviour
    {
        [SerializeField] private float _hitStopDuration;
        private bool _hitStopActive;
        
        public void StartHitStop()
        {
            if (_hitStopActive)
            {
                return;
            }

            Time.timeScale = 0f;
            _hitStopActive = true;
            StartCoroutine(StopTime(false));
        }

        public void StartHitStopFrame()
        {
            if (_hitStopActive)
            {
                return;
            }

            Time.timeScale = 0f;
            _hitStopActive = true;
            StartCoroutine(StopTime(true));
        }

        private IEnumerator StopTime(bool isFrame)
        {
            if (isFrame)
            {
                yield return new WaitForEndOfFrame();
            }
            else
            {
                yield return new WaitForSecondsRealtime(_hitStopDuration);
            }

            Time.timeScale = 1f;
            _hitStopActive = false;
        }
    }
}