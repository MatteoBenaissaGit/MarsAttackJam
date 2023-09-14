using UnityEngine;

public interface IAttackable
{
    public void TakeDamage(IAttacker attacker, float damage);
    public GameObject AttackerObject { get; set; }
}
