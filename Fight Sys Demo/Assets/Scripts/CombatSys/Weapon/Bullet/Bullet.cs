using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Bullet : Subunit
{
    #region Bullet Info
    public Bullet_SO bullet_SO;
    public BulletType bulletType
    {
        get
        {
            return bullet_SO.bulletType;
        }
    }
    public List<Damage> damages
    {
        get
        {
            List<Damage> _damages = new List<Damage>();
            foreach (DamageData i in bullet_SO.Damages)
            {
                _damages.Add(new Damage(i, master, skillLevel));
            }
            return _damages;
        }
    }

    #endregion
    #region Trajectory Info
    public Trajectory_SO trajectory_SO;
    public TrajectoryType trajectoryType
    {
        get
        {
            return trajectory_SO.trajectoryType;
        }
    }
    public float speed
    {
        get
        {
            return trajectory_SO.speed;
        }
    }
    public float maxAngularSpeed
    {
        get
        {
            return trajectory_SO.maxAngularSpeed;
        }
    }
    public float maxDistance
    {
        get
        {
            return trajectory_SO.maxDistance;
        }
    }
    #endregion

    protected Collider coll;
    protected Rigidbody rb;

    public Vector3 targetPostion;

    float distance = 0;

    #region init
    public void InitSubunit(Unit target, Unit master, Bullet_SO bullet_so, Trajectory_SO trajectory_so)
    {
        this.target = target;
        this.master = master;
        this.bullet_SO = bullet_so;
        this.trajectory_SO = trajectory_so;



        isInited = true;
    }

    #endregion
    protected virtual void Awake()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    protected virtual void Start()
    {
        if (bulletType == BulletType.ONLY_TO_TARGET_NO_OBJ)
        {
            DoDamage(target);
            Destroy(gameObject);
        }
        rb.velocity = transform.forward.normalized * speed;
    }
    protected virtual void FixedUpdate()
    {
        Move();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        Unit _unit;
        if (!other.TryGetComponent<Unit>(out _unit))
        {
            return;
        }
        switch (bulletType)
        {
            case BulletType.ONLY_TO_TARGET:
                if (_unit.inGameId == target.inGameId)
                {
                    OnHit(_unit);
                    Destroy(gameObject);
                }
                break;
            case BulletType.ALL_ENEMY:
                break;
            case BulletType.ALL_FRIEND_BUT_ME:
                break;
            case BulletType.ALL_FRIEND_AND_ME:
                break;
            case BulletType.EVERYONE:
                break;
            default:
                break;
        }
    }
    protected void DoDamage(Unit target)
    {
        foreach (Damage i in damages)
        {
            target.OnDamageIn(i);
        }
    }

    protected virtual void OnHit(Unit target)
    {
        DoDamage(target);
    }

    void Move()
    {
        // ??????????????????
        if (target.unitStatus != UnitStatus.ALIVE)
        {
            Destroy(gameObject);
        }

        if (maxDistance > 0)
        {
            distance += rb.velocity.magnitude * Time.fixedDeltaTime;
            if (distance >= maxDistance)
            {
                Destroy(gameObject);
            }
        }
        switch (trajectoryType)
        {
            case TrajectoryType.FLY_TO_TARGET:
                Vector3 _target_pos = target.transform.position - transform.position;
                if (maxAngularSpeed < 0.0001f)
                {
                    rb.velocity = _target_pos.normalized * speed;
                }
                else
                {
                    rb.velocity = Vector3.RotateTowards(rb.velocity, _target_pos, BasicMath.Angle2Radian(maxAngularSpeed) * Time.fixedDeltaTime, 0);
                }
                break;
            case TrajectoryType.STRAIGHT:
                break;
            default:
                break;
        }
    }

}
