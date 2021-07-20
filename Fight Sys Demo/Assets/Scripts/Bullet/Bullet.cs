using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public SphereCollider coll;
    public Rigidbody rb;

    public BulletType bulletType = BulletType.ONLY_TO_TARGET;
    public int targetId = 0;
    public UnitInfo masterInfo = new UnitInfo();


    private void Awake()
    {
        coll = GetComponent<SphereCollider>();
        coll.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }


    private void OnTriggerEnter(Collider collision)
    {
        ////Debug.Log(collision.gameObject);
        //Unit unit = collision.gameObject.GetComponent<Unit>();
        //UnitInfo _unit_info = unit.unitInfo;
        //int _unit_id = _unit_info.inGameId;
        //int _unit_camp = _unit_info.campId;

        //if (this.bulletType == BulletType.ONLY_TO_TARGET && _unit_id == targetId)
        //{
        //    OnHit.Invoke(_unit_info);
        //    Destroy(gameObject);
        //}
        //if (this.bulletType == BulletType.ALL_ENEMY && _unit_camp != masterInfo.campId)
        //{
        //    OnHit.Invoke(_unit_info);
        //}
        //if (this.bulletType == BulletType.ALL_FRIEND_AND_ME && _unit_camp == masterInfo.campId)
        //{
        //    OnHit.Invoke(_unit_info);
        //}
        //if (this.bulletType == BulletType.ALL_FRIEND_BUT_ME && _unit_camp == masterInfo.campId && _unit_id != masterInfo.inGameId)
        //{
        //    OnHit.Invoke(_unit_info);
        //}
        //if (this.bulletType == BulletType.EVERYONE)
        //{
        //    OnHit.Invoke(_unit_info);
        //}
    }


}
