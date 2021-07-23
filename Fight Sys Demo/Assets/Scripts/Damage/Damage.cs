using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public int sourceId;
    public int targetId;
    public DamageType damageType = DamageType.PHYSICS;
    public float constValue = 0;
    public float atkRate = 0;
    public float preValue = 0;
    public float afterValue = 0;

    public Damage(DamageData damage_data, int master_id)
    {
        sourceId = master_id;
        damageType = damage_data.damageType;
        constValue = damage_data.constValue;
        atkRate = damage_data.atkRate;
        preValue = constValue + atkRate * UnitPool.Get(master_id).physicalAtk;
    }

}
