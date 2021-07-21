using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill001 : Skill
{
    public GameObject bulletPrefab;
    public float cooldown;

    Bullet2Target bullet;
    float damage_value;
    float _cooldown;

    void CreateBullet(GameObject prefab)
    {
        damage_value = master.physicalAtk;
        GameObject bulletObj = Instantiate(prefab);
        bulletObj.transform.position = transform.position;
        bullet = bulletObj.GetComponent<Bullet2Target>();
        bullet.masterId = master.inGameId;
        bullet.damage = new Damage(DamageType.PHYSICS, damage_value);
        bullet.targetId = 10000;
    }
    private void Update()
    {
        _cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && _cooldown < 0)
        {
            CreateBullet(bulletPrefab);
            _cooldown = cooldown;
        }
    }
}
