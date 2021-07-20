using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Target : Bullet
{
    public Damage damage = new Damage(DamageType.PHYSICS, 10);
    public UnitInfo target;
    public float speed = 1;
    private void OnTriggerEnter(Collider other)
    {
        Unit unit = other.gameObject.GetComponent<Unit>();
        if (unit.unitInfo.inGameId != target.inGameId)
        {
            return;
        }
        unit.PreDamage(unit.unitInfo, masterInfo, damage);
        Destroy(gameObject);
    }

    private void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        Unit unit = UnitPool.unitPool[target.inGameId];
        rb.velocity = (unit.transform.position - transform.position).normalized * speed;
    }

}
