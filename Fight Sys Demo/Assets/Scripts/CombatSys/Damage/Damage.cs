using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Subunit
{
    public DamageData damageData;
    public float preValue = 0;
    public float afterValue = 0;

    public Damage(DamageData damage_data, Unit source, int skill_level = 1)
    {
        this.master = source;
        this.damageData = damage_data;
        this.skillLevel = skill_level;
        int _index = this.skillLevel - 1;
        this.damageData.atkRate = BasicMath.ExpbandList(damage_data.atkRate, this.skillLevel);
        this.damageData.constValue = BasicMath.ExpbandList(damage_data.constValue, this.skillLevel);
        switch (damageData.damageType)
        {
            case DamageType.PHYSICS:
                preValue = damageData.constValue[_index] + damageData.atkRate[_index] * source.physicalAtk;
                break;
            default:
                break;
        }
        isInited = true;
    }

}
