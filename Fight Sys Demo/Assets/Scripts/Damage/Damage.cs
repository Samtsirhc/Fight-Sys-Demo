using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public int sourceId;
    public int targetId;
    public DamageType damageType = DamageType.PHYSICS;
    public float preValue = 1;
    public float afterValue = 0;

    public Damage(DamageType damage_type, float value)
    {
        this.damageType = damage_type;
        this.preValue = value;
    }

}
