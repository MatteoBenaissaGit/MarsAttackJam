using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetection
{
    public AIDetection(Transform player, AIController controller)
    {
        _player = player;
        _controller = controller;
    }

    private Transform _player;
    private AIController _controller;
    private int _playerLayer = 6;
    private Ray _ray;

    public bool SeePlayer()
    {
        Ray ray = new Ray(_controller.EnemyTransform.position, _player.position - _controller.EnemyTransform.position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000))
        {
            if (hit.collider.gameObject.layer != _playerLayer)
            {
                return false;
            }
            
            return true;
        }

        return false;
    }

}
