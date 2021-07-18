using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitInfo unitInfo;
    public CombatInfo combatInfo;

    private void Awake()
    {
        unitInfo = new UnitInfo();
        combatInfo = new CombatInfo();
        UnitPool.AddUnit(ref this.unitInfo);
        EventCenter.AddListener<UnitInfo, UnitInfo, Damage>(EventType.TAKE_DAMAGE, TakeDamage);
        EventCenter.AddListener<UnitInfo, UnitInfo, Damage>(EventType.DO_DAMAGE, DoDamage);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<UnitInfo, UnitInfo, Damage>(EventType.TAKE_DAMAGE, TakeDamage);
        EventCenter.RemoveListener<UnitInfo, UnitInfo, Damage>(EventType.DO_DAMAGE, DoDamage);
    }

    // take the damage from other unit
    public void TakeDamage(UnitInfo target, UnitInfo source, Damage damage)
    {
        if (target.inGameId != unitInfo.inGameId)
        {
            return;
        }
        combatInfo.hp.curValue -= damage.value;
        EventCenter.Broadcast(EventType.DO_DAMAGE, target, source, damage);
    }


    
    public void DoDamage(UnitInfo target, UnitInfo source, Damage damage)
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


}
