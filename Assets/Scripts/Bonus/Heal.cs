using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public PlayerLifeController _playerLife;
    [SerializeField] public int _lifeGain;

    private void OnCollisionEnter(Collision collision)
    {
        var script = collision.gameObject.GetComponent<PlayerLifeController>();

        if (script != null)
        {
            if (_playerLife._life < PlayerController.Instance.Data.Life)
                _playerLife._life += _lifeGain;
            else
                _playerLife._life = PlayerController.Instance.Data.Life;
        }
    }
}
