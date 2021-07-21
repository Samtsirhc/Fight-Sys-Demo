using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Unit : MonoBehaviour
{
    #region Unit Info
    public UnitInfo_SO unitInfo_SO;
    public string unitName { get { return unitInfo_SO.unitName; } }
    public int unitId { get { return unitInfo_SO.unitId; } }
    public UnitType unitType
    {
        get
        {
            return unitInfo_SO.unitType;
        }
        set
        {
            unitInfo_SO.unitType = value;
        }
    }
    [HideInInspector]
    public int inGameId = 0;
    [HideInInspector]
    public int campId = 0;
    [HideInInspector]
    public int masterId = 0;
    [HideInInspector]
    public int playerId = 0;
    #endregion
    #region Unit Status
    public UnitStatus_SO unitStatus_SO;

    // Hp

    public float maxHp { get { return unitStatus_SO.basicMaxHp; } }
    
    private float _cur_hp = -1;
    public float curHp
    {
        get
        {
            if (_cur_hp < 0)
            {
                _cur_hp = maxHp;
            }
            return _cur_hp; 
        }
        set
        {
            if (value <= 0) 
            { 
                _cur_hp = 0; 
            }
            else if (value >= maxHp) 
            { 
                _cur_hp = maxHp; 
            }
            else 
            { 
                _cur_hp = value; 
            }
        }
    }

    // 物理攻击/防御
    public float physicalAtk { get { return unitStatus_SO.basicPhysicalAtk; } }
    public float physicalDef { get { return unitStatus_SO.basicPhysicalDef; } }

    // 攻速
    public float atkSpeed { get { return unitStatus_SO.basicAtkSpeed; } }
    public int atkInterval { get { return unitStatus_SO.basicAtkInterval; } }


    // 护盾
    //public List<Shield> shields = new List<Shield>();


    // 幸运值
    public int luckPoint { get { return unitStatus_SO.basicLuckPoint; } }
    #endregion





    private void Awake()
    {
        tag = "Unit";
    }


    private void Start()
    {
        EventCenter.Broadcast(EventType.ADD_UNIT, this);
        CreateHpBar();
    }

    // 受到伤害的时候
    public void OnDamageIn(Damage damage)
    {
        if (damage.targetId != inGameId)
        {
            return;
        }
        curHp -= damage.preValue;
        UnitPool.Instance.unitPool[damage.sourceId].OnDamageDone(damage);
        EventCenter.Broadcast(EventType.DAMAGE_DONE, damage);
    }

    // 已经给别人造成伤害的时候
    public void OnDamageDone(Damage damage)
    {
        //if (damage.source.inGameId != unitInfo.inGameId)
        //{
        //    return;
        //}

        // something need to do after damage has been took
        if (true)
        {

        }
    }


    // 生成可视的血条
    public void CreateHpBar()
    {
        string _path = "Assets/Prefabs/HpBar.prefab";
        GameObject hp_bar_obj = AssetDatabase.LoadAssetAtPath(_path, typeof(GameObject)) as GameObject;
        HpBar hp_bar = Instantiate(hp_bar_obj, GameObject.Find("Canvas").transform).GetComponent<HpBar>();
        hp_bar.SetMaster(this);
    }

}
