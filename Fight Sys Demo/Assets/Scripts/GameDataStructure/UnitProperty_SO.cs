using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Status", menuName = "Data/Unit Status")]
public class UnitProperty_SO : ScriptableObject
{
    [Header("Hp")]
    public float basicMaxHp = 1000;

    [Header("Physics Data")]
    public float basicPhysicalAtk = 100;
    public float basicPhysicalDef = 0;

    [Header("Attack Data")]
    public float basicAtkSpeed = 100;
    public int basicAtkInterval = 2000;

    [Header("Lcuk Data")]
    public int basicLuckPoint = 0;
}
