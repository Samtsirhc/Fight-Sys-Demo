using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Everyone : Bullet
{
    public Damage damage = new Damage(DamageType.PHYSICS, 10);

    private void OnTriggerEnter(Collider other)
    {
        Unit unit = other.gameObject.GetComponent<Unit>();
        unit.PreDamage(unit.unitInfo, masterInfo, damage);
    }

}
