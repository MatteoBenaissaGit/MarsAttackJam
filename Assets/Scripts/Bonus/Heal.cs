using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] public int _lifeGain;

    private void OnTriggerEnter(Collider other)
    {
        var script = other.gameObject.GetComponent<PlayerLifeController>();

        if (script != null)
        {
            script.Heal(_lifeGain);
            Destroy(this.gameObject);
        }
    }
}
