using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetection
{
    public AIDetection(Transform player, Transform mTransform, LayerMask playerLayer)
    {
        _player = player;
        m_transform = mTransform;
        _layerMask = playerLayer;
    }

    private Transform _player;
    private Transform m_transform;
    private LayerMask _layerMask;
    private Ray _ray;

    public bool SeePlayer()
    {
        Ray ray = new Ray(m_transform.position, _player.position - m_transform.position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Vector3.Distance(m_transform.position, _player.position) + 10,_layerMask))
        {
            return true;
        }

        return false;
    }

}
