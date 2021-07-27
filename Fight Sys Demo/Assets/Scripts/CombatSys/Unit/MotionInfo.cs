using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MotionInfo : MonoBehaviour
{
    Rigidbody rb;
    float _velocityLim = 99999;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public Vector3 position
    {
        get
        {
            return position;
        }
        set
        {
            gameObject.transform.position = value;
        }
    }
    public float velocityLim
    {
        get
        {
            return _velocityLim;
        }
        set
        {
            _velocityLim = value;
        }
    }
    public Vector3 velocity
    {
        get
        {
            return rb.velocity;
        }
        set
        {
            if (value.magnitude > velocityLim)
            {
                rb.velocity = value.normalized * velocityLim;
            }
            else
            {
                rb.velocity = value;
            }
        }
    }
    public Vector3 toward;
    public Vector3 angularVelocity;
    public Vector3 angularVelocityLim;

    private void Update()
    {
        position = transform.position;
        Debug.Log(position);
    }
}
