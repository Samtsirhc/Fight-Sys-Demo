using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float cooldown;

    Unit master;
    UnitInfo masterInfo;
    GameObject bulletObj;
    Bullet2Target bullet;
    float damage_value;
    float _cooldown;
    private void Awake()
    {
        if (TryGetComponent<Unit>(out master))
        {
            masterInfo = master.unitInfo;
        }
        else
        {
            masterInfo = new UnitInfo();
        }
    }
    // Update is called once per frame
    void Update()
    {
        _cooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && _cooldown < 0)
        {
            CreateBullet();
            _cooldown = cooldown;
        }
    }

    void CreateBullet()
    {
        damage_value = master.combatInfo.physicalATK;
        bulletObj = Instantiate(bulletPrefab);
        bulletObj.transform.position = transform.position;
        bullet = bulletObj.GetComponent<Bullet2Target>();
        bullet.masterInfo = masterInfo;
        bullet.damage = new Damage(DamageType.PHYSICS, damage_value);
        bullet.target = UnitPool.unitPool[10001].unitInfo;
    }
}
