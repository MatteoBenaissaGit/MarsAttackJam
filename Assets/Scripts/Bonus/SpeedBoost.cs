using Data.Bonus;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [field: SerializeField] public BonusData Data { get; private set; }

    private float _timer;

    private void Start()
    {
        _timer = Data.TimeCollect;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        
        transform.RotateAround(transform.position,Vector3.up, 1f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (_timer > 0)
        {
            return;
        }

        var script = other.gameObject.GetComponent<PlayerController>();
       

        if (script != null)
        {
            script.Boost = Data.intencitySpeedBoost;
            script._timerBoost = Data.timeSpeedBoost;
            Destroy(this.gameObject);
        }
    }
}
