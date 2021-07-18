using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet001 : Bullet
{
    Damage damage = new Damage(DamageType.PHYSICS, 1000);



    void OnHit(UnitInfo target)
    {
        EventCenter.Broadcast(EventType.DO_DAMAGE, target, this.masterInfo, damage);
        Destroy(gameObject);
    }
}
