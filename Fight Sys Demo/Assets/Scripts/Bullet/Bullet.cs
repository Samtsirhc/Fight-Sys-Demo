using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    protected SphereCollider coll;
    protected Rigidbody rb;

    protected BulletType bulletType = BulletType.ONLY_TO_TARGET;

    public int targetId = 0;
    public int masterId;



    private void Awake()
    {
        coll = GetComponent<SphereCollider>();
        coll.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void DoDamage(Unit target, Damage damage)
    {
        damage.sourceId = masterId;
        damage.targetId = target.inGameId;
        target.OnDamageIn(damage);
    }
    


}
