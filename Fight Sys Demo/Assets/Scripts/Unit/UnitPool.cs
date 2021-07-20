using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitPool
{
    /// <summary>
    /// Pool 是一个以 Unit 的 inGameId 为索引的 Dictionary，值如下：
    /// Item1：UnitInfo
    /// Item2：Gameobject
    /// </summary>
    public static Dictionary<int, Unit> unitPool = new Dictionary<int, Unit>();
    private static int unit_ingame_id = 10000;

    public static void AddUnit(Unit unit)
    {
        unit.unitInfo.inGameId = unit_ingame_id;
        unitPool[unit_ingame_id] = unit;
        unit_ingame_id += 1;

    }

    public static void RemoveUnit(int ingame_id)
    {
        if (unitPool.ContainsKey(ingame_id))
        {
            unitPool.Remove(ingame_id);
        }
        else
        {
            throw new Exception("There is not ingame_id");
        }
    }

    public static string FormatUnitInfo()
    {
        string _str = "Unit Pool: ";
        foreach (int key in unitPool.Keys)
        {
            _str += string.Format("\n{0} {1}", key, unitPool[key].unitInfo.name);
        }
        return _str;
    }
}
