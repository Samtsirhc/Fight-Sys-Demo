using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Info", menuName = "Data/Unit Info")]
public class UnitInfo_SO : ScriptableObject
{
    [Header("Static Info")]
    public string unitName = "Ä¬ÈÏµ¥Î»";
    public int unitId = 0;
    public UnitType unitType = UnitType.DEFAULT;

}
