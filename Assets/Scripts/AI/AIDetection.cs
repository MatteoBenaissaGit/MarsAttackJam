using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetection : MonoBehaviour
{
    public Ray ray;

    private void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.GetChild(0).transform.forward;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(ray.origin, ray.direction);
    }
}
