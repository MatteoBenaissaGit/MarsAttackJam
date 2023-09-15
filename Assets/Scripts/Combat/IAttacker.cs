using UnityEngine;

public interface IAttacker
{
    public void GiveDamage(IAttackable attackable);
    
    public GameObject AttackerObject { get; set; }

}