using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Target : Bullet
{
    public Damage damage = new Damage(DamageType.PHYSICS, 10);
    public float speed = 1;
    private void OnTriggerEnter(Collider other)
    {
        Unit unit = other.gameObject.GetComponent<Unit>();
        if (unit.inGameId != targetId)
        {
            return;
        }
        DoDamage(unit, damage);
        Destroy(gameObject);
    }

    private void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        Unit unit = UnitPool.Instance.unitPool[targetId];
        rb.velocity = (unit.transform.position - transform.position).normalized * speed;
    }

}
