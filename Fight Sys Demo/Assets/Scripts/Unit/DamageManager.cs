using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{
    private UnitInfo unitInfo;

    private void Awake()
    {

    }
    public DamageManager(UnitInfo unit_info)
    {
        this.unitInfo = unit_info;
    }


}
