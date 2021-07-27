using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Data/Weapon")]
public class Weapon_SO : ScriptableObject
{
    public string bulletPrefabName;
    public Bullet_SO bullet_SO;
    public Trajectory_SO trajectory_SO;
    public Emitter_SO emitter_SO;
}
