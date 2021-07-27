using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Weapon : Subunit
{
    #region Weapon_SO
    public Weapon_SO weapon_SO;
    
    public Bullet_SO bullet_SO
    {
        get
        {
            return weapon_SO.bullet_SO;
        }
    }
    public GameObject bulletPrefab
    {
        get
        {
            return bullet_SO.bulletPrefab;
            //string path = "AssetBundles/bullets.prefab";
            //AssetBundle _asset_bundle = AssetBundle.LoadFromFileAsync(path).assetBundle;
            //if (_asset_bundle.Contains(weapon_SO.bulletPrefabName))
            //{
            //    return _asset_bundle.LoadAsset(weapon_SO.bulletPrefabName) as GameObject;
            //}
            //else
            //{
            //    return _asset_bundle.LoadAsset("SampleBullet") as GameObject;
            //}
        }
    }
    public Trajectory_SO trajectory_SO
    {
        get
        {
            return weapon_SO.trajectory_SO;
        }
    }
    public Emitter_SO emitter_SO
    {
        get
        {
            return weapon_SO.emitter_SO;
        }
    }
    #endregion

    float existTime = 0;
    int fireCount = 0;

    #region Init
    public void InitSubunit(Unit master, Weapon_SO weapon_so, int skill_level)
    {
        this.weapon_SO = weapon_so;
        this.master = master;
        transform.parent = master.transform;
        this.skillLevel = skill_level;
        isInited = true;
    }
    #endregion

    protected virtual void Start()
    {
        if (!isInited)
        {
            throw new Exception("Weapon did not init");
        }
    }
    // Update is called once per frame

    protected virtual void FixedUpdate()
    {
        Fire();
    }
    protected virtual void Fire()
    {
        if (target.unitStatus != UnitStatus.ALIVE)
        {
            Destroy(gameObject);
        }
        existTime += Time.fixedDeltaTime;
        // 按波次时间生成子弹
        if (existTime >= emitter_SO.fireTime[fireCount] && fireCount < emitter_SO.fireTime.Count)
        {
            Vector3 _center = transform.position;
            Vector3 _direction = transform.forward;
            Vector3 _plane = transform.up;
            List<Vector3> _mouthPosition = new List<Vector3>();
            // 子弹出生点位置
            foreach (float i in emitter_SO.mouthPosition)
            {
                _mouthPosition.Add(BasicMath.GetPointOnCircle(emitter_SO.radius, i, _plane, _center, _direction)); 
            }
            // 生成子弹
            foreach (Vector3 i in _mouthPosition)
            {
                GameObject _bullet = Instantiate(bulletPrefab);
                _bullet.transform.position = i;
                _bullet.transform.forward = i - _center;
                Bullet _bullet_script = _bullet.AddComponent<Bullet>();
                _bullet_script.InitSubunit(target, master, bullet_SO, trajectory_SO);
                _bullet_script.skillLevel = skillLevel;
            }
            fireCount += 1;
        }
        if (fireCount >= emitter_SO.fireTime.Count)
        {
            Destroy(gameObject);
        }
    }
}
