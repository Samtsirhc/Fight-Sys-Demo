using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Unit : MonoBehaviour
{
    public UnitInfo unitInfo;
    public CombatInfo combatInfo;

    private void Awake()
    {
        unitInfo = new UnitInfo();
        combatInfo = new CombatInfo();
    }


    private void Start()
    {
        UnitPool.AddUnit(this);
        CreateHpBar();
    }

    // take the damage from other unit
    public void PreDamage(UnitInfo target, UnitInfo source, Damage damage)
    {
        if (target.inGameId != unitInfo.inGameId)
        {
            return;
        }
        combatInfo.hp.curValue -= damage.value;
        EventCenter.Broadcast(EventType.AFTER_DAMAGE, source, damage);
    }


    
    public void AfterDamage(UnitInfo target, UnitInfo source, Damage damage)
    {
        if (source.inGameId != unitInfo.inGameId)
        {
            return;
        }

        // something need to do after damage has been took
        if (true)
        {

        }
    }

    public void CreateHpBar()
    {
        string _path = "Assets/Prefabs/HpBar.prefab";
        GameObject hp_bar_obj = AssetDatabase.LoadAssetAtPath(_path, typeof(GameObject)) as GameObject;
        HpBar hp_bar = Instantiate(hp_bar_obj, GameObject.Find("Canvas").transform).GetComponent<HpBar>();
        hp_bar.SetMaster(this);
    }

}
