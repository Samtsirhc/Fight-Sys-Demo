using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public DamageType damageType = DamageType.PHYSICS;
    public int value = 1;

    public Damage(DamageType damage_type, int value)
    {
        this.damageType = damage_type;
        this.value = value;
    }

}
