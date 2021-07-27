using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class Unit : MonoBehaviour
{
    #region Unit Info
    private UnitInfo_SO unitInfo_SO;
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
    #region Unit Property
    private UnitProperty_SO unitProperty_SO;
    // 状态
    [HideInInspector]
    public UnitStatus unitStatus = UnitStatus.OUT_GAME;

    // Hp
    public float maxHp { get { return unitProperty_SO.basicMaxHp; } }
    
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
    public float physicalAtk { get { return unitProperty_SO.basicPhysicalAtk; } }
    public float physicalDef { get { return unitProperty_SO.basicPhysicalDef; } }

    // 攻速
    public float atkSpeed { get { return unitProperty_SO.basicAtkSpeed; } }
    public int atkInterval { get { return unitProperty_SO.basicAtkInterval; } }


    // 护盾
    //public List<Shield> shields = new List<Shield>();


    // 幸运值
    public int luckPoint { get { return unitProperty_SO.basicLuckPoint; } }
    #endregion


    private void Awake()
    {
        tag = "Unit";
    }


    private void Start()
    {
        EventCenter.Broadcast(EventType.ADD_UNIT, this);
        unitStatus = UnitStatus.ALIVE;
        CreateHpBar();
    }

    private void FixedUpdate()
    {
        if (unitStatus == UnitStatus.DEAD)
        {
            gameObject.SetActive(false);
        }
    }
    // 受到伤害的时候
    public void OnDamageIn(Damage damage)
    {
        switch (unitStatus)
        {
            case UnitStatus.OUT_GAME:
                return;
            case UnitStatus.ALIVE:
                break;
            case UnitStatus.DEAD:
                return;
            default:
                break;
        }
        damage.target = this;
        curHp -= damage.preValue;
        damage.master.OnDamageDone(damage);
        if (curHp < 0.0001f)
        {
            unitStatus = UnitStatus.DEAD;
            //EventCenter.Broadcast(I dead);
        }
        //EventCenter.Broadcast(EventType.DAMAGE_DONE, damage);
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
        string path = "AssetBundles/ui.prefab";
        AssetBundle _asset_bundle = AssetBundle.LoadFromFileAsync(path).assetBundle;
        GameObject hp_bar_obj = _asset_bundle.LoadAsset("HpBar") as GameObject;
        HpBar hp_bar = Instantiate(hp_bar_obj, GameObject.Find("Canvas").transform).GetComponent<HpBar>();
        hp_bar.SetMaster(this);
    }

}
