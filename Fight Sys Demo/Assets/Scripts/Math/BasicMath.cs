using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicMath
{
    public class Circle
    {
        public Vector3 normal;
        public Vector3 center;
        public Vector3 initDirection;

        public Circle(Vector3 normal, Vector3 center, Vector3 initDirection)
        {
            if (Vector3.Dot(initDirection, normal) != 0)
            {
                throw new Exception("initDirection和normal不正交");
            }
            this.normal = normal;
            this.center = center;
            this.initDirection = initDirection;
        }
    }

    public static float Radian2Angle(float radian)
    {
        return 180 * radian / Mathf.PI;
    }
    public static float Angle2Radian(float angle)
    {
        return Mathf.PI * angle / 180;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="radius">圆的半径</param>
    /// <param name="theta">世界坐标下的圆心角，角度制</param>
    /// <param name="plane">此圆所垂直的向量</param>
    /// <param name="center">圆心坐标</param>
    /// <returns></returns>
    public static Vector3 GetPointOnCircle(float radius, float theta, Vector3 plane, Vector3 center, Vector3 initDirection)
    {
        Vector3 _z = plane.normalized;
        Vector3 _x = initDirection.normalized;
        Vector3 _y = Vector3.Cross(_z, _x);
        float _theta = Angle2Radian(theta);
        return radius *(Mathf.Sin(_theta) * _y + Mathf.Cos(_theta) * _x);
    }

}
