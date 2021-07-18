using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class Bullet : MonoBehaviour
{
    public SphereCollider coll;

    public BulletType bulletType = BulletType.ONLY_TO_TARGET;
    public int targetId = 0;
    public UnitInfo masterInfo;

    private void Awake()
    {
        masterInfo = gameObject.GetComponent<Unit>().unitInfo;
        coll = GetComponent<SphereCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        UnitInfo _unit_info = collision.gameObject.GetComponent<Unit>().unitInfo;
        int _unit_id = _unit_info.inGameId;
        int _unit_camp = _unit_info.campId;

        if (this.bulletType == BulletType.ONLY_TO_TARGET && _unit_id == targetId)
        {
            OnHit(_unit_info);
        }
        if (this.bulletType == BulletType.ALL_ENEMY && _unit_camp != masterInfo.campId)
        {
            OnHit(_unit_info);
        }
        if (this.bulletType == BulletType.ALL_FRIEND_AND_ME && _unit_camp == masterInfo.campId)
        {
            OnHit(_unit_info);
        }
        if (this.bulletType == BulletType.ALL_FRIEND_BUT_ME && _unit_camp == masterInfo.campId && _unit_id != masterInfo.inGameId)
        {
            OnHit(_unit_info);
        }
    }

    void OnDestroy()
    {
        OnEnd();
    }


    void OnHit(UnitInfo target)
    {
        
    }

    void OnStart()
    {

    }

   void OnEnd()
    {

    }
}
