using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletObj;
    public Bullet_SO bullet_SO;
    public Trajectory_SO trajectory_SO;
    public Emitter_SO emitter_SO;
    [HideInInspector]
    public Unit master;
    [HideInInspector]
    public Unit target;

    float existTime = 0;
    int fireCount = 0;

    #region Init
    public void InitWeapon(Unit master, Unit target)
    {
        this.master = master;
        transform.position = master.transform.position;
        transform.rotation = master.transform.rotation;
        this.target = target;
    }
    #endregion

    // Update is called once per frame

    private void FixedUpdate()
    {
        Fire();
    }
    public void Fire()
    {
        existTime += Time.fixedDeltaTime;
        if (existTime >= emitter_SO.fireTime[fireCount] && fireCount < emitter_SO.fireTime.Count)
        {
            Vector3 _center = transform.position;
            Vector3 _direction = transform.forward;
            Vector3 _plane = transform.up;
            List<Vector3> _mouthPosition = new List<Vector3>();
            foreach (float i in emitter_SO.mouthPosition)
            {
                _mouthPosition.Add(BasicMath.GetPointOnCircle(emitter_SO.radius, i, _plane, _center, _direction)); 
            }
            foreach (Vector3 i in _mouthPosition)
            {
                GameObject _bullet = Instantiate(bulletObj);
                _bullet.transform.position = i;
                _bullet.transform.forward = i - _center;
                Bullet _bullet_script = _bullet.AddComponent<Bullet>();
                _bullet_script.InitBullet(target, master, bullet_SO, trajectory_SO);
            }
            fireCount += 1;
        }
        if (fireCount >= emitter_SO.fireTime.Count)
        {
            Destroy(gameObject);
        }
    }
}
