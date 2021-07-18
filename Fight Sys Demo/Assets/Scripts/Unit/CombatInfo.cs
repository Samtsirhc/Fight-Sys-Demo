using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInfo
{
    public Gauge hp = new Gauge(1000);
    public int luckPoint = 0;
    public int physicalATK = 100;
    public int physicalDef = 0;
    public List<Shield> shields = new List<Shield>();
    public int atkSpeed = 100;
    public int atkInterval = 2000;
}
