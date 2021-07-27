using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Data/Bullet")]
public class Bullet_SO : ScriptableObject
{
    [Header("Bullet Info")]
    public BulletType bulletType = BulletType.ONLY_TO_TARGET;
    public GameObject bulletPrefab;

    [Header("OnHit")]
    public List<DamageData> Damages;



    [System.Serializable]
    public struct SphereColl
    {
        public float radius;
    }

    [System.Serializable]
    public struct HexagonColl
    {
        public float side;
        public float height;
    }
}
