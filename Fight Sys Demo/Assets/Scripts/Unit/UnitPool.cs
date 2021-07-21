using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitPool : MonoBehaviour
{
    public static UnitPool Instance;

    /// <summary>
    /// Pool 是一个以 Unit 的 inGameId 为索引的 Dictionary，值如下：
    /// Item1：UnitInfo
    /// Item2：Gameobject
    /// </summary>
    public Dictionary<int, Unit> unitPool = new Dictionary<int, Unit>();
    private int unit_ingame_id = 10000;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        EventCenter.AddListener<Unit>(EventType.ADD_UNIT, AddUnit);
    }

    private void FixedUpdate()
    {
        UpdateUnitPool();
    }
    public void AddUnit(Unit unit)
    {
        unit.inGameId = unit_ingame_id;
        unitPool[unit_ingame_id] = unit;
        unit_ingame_id += 1;

    }

    public void RemoveUnit(int ingame_id)
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

    public string FormatUnitInfo()
    {
        string _str = "Unit Pool: ";
        foreach (int key in unitPool.Keys)
        {
            _str += string.Format("\n{0} {1}", key, unitPool[key].unitName);
        }
        return _str;
    }

    private void UpdateUnitPool()
    {
        Array _units = GameObject.FindGameObjectsWithTag("Unit");
        Dictionary<int, Unit> _unit_pool = new Dictionary<int, Unit>();
        foreach (GameObject i in _units)
        {
            Unit _unit = i.GetComponent<Unit>();
            if (_unit.inGameId != 0)
            {
                _unit_pool[_unit.inGameId] = _unit;
            }
            else
            {
                _unit.inGameId = unit_ingame_id;
                _unit_pool[unit_ingame_id] = _unit;
                unit_ingame_id += 1;
            }
        }
        unitPool = _unit_pool;
    }
}
