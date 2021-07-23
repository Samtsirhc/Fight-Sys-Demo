using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill : MonoBehaviour
{
    [HideInInspector]
    public Unit master;
    public GameObject weaponObj;


    private void Awake()
    {
        if (TryGetComponent<Unit>(out master))
        {
            
        }
        else
        {
            throw new Exception("Can not get master");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateWeapon(UnitPool.Get(10000));
        }
    }

    public void CreateWeapon()
    {
        GameObject _weapon_obj = Instantiate(weaponObj, transform);
        Weapon _weapon = _weapon_obj.GetComponent<Weapon>();
        _weapon.master = this.master;
        _weapon.target = new Unit();
    }
    public void CreateWeapon(Unit target)
    {
        GameObject _weapon_obj = Instantiate(weaponObj, transform);
        Weapon _weapon = _weapon_obj.GetComponent<Weapon>();
        _weapon.master = this.master;
        _weapon.target = target;
    }


}
