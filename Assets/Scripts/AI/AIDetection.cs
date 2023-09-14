using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetection
{
    public AIDetection(Transform player, AIController controller, LayerMask playerLayer)
    {
        _player = player;
        _controller = controller;
        _layerMask = playerLayer;
    }

    private Transform _player;
    private AIController _controller;
    private LayerMask _layerMask;
    private Ray _ray;

    public bool SeePlayer()
    {
        Ray ray = new Ray(_controller.EnemyTransform.position, _player.position - _controller.EnemyTransform.position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000,_layerMask))
        {
            return true;
        }

        return false;
    }

}
