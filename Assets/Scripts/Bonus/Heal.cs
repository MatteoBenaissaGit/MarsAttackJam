using Data.Bonus;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [field: SerializeField] public BonusData Data { get; private set; }

    private float _timer;

    //void updt

    private void OnTriggerStay(Collider other)
    {
        if (_timer > 0)
        {
            return;
        }

        var script = other.gameObject.GetComponent<PlayerLifeController>();

        if (script != null)
        {
            script.Heal(Data.LifeGain);
            Destroy(this.gameObject);
        }
    }
}
