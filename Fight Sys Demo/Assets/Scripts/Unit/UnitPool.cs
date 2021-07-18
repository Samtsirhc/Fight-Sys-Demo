using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitPool
{
    public static Dictionary<int, UnitInfo> unitPool = new Dictionary<int, UnitInfo>();
    private static int unit_ingame_id = 10000;

    public static void AddUnit(ref UnitInfo unit_info)
    {
        unit_info.inGameId = unit_ingame_id;
        unitPool[unit_ingame_id] = unit_info;
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
            _str += string.Format("\n{0} {1}", key, unitPool[key].name);
        }
        return _str;
    }
}
