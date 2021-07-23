using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Data/Bullet")]
public class Bullet_SO : ScriptableObject
{
    [Header("Bullet Info")]
    public BulletType bulletType = BulletType.ONLY_TO_TARGET;


    [Header("Shape Info")]
    public float basicRadius = 0.5f;

    [Header("OnHit")]
    public List<DamageData> Damages;

}
