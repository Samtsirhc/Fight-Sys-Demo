using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkill : Skill
{
    public Weapon_SO weapon_SO;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateWeapon(UnitPool.Get(10001));
        }
    }
    Weapon _CreateWeapon()
    {
        GameObject _weapon_obj = new GameObject();
        Weapon _weapon = _weapon_obj.AddComponent<Weapon>();
        _weapon.InitSubunit(master, weapon_SO, skillLevel);
        return _weapon;
    }

    public void CreateWeapon()
    {
        Weapon _weapon = _CreateWeapon();
        _weapon.target = new Unit();

    }
    public void CreateWeapon(Unit target)
    {
        Weapon _weapon = _CreateWeapon();
        _weapon.target = target;
    }
}
