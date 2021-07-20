using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge
{
    private float _max_value;
    private float _cur_value;
    private float _min_value;


    public Gauge(float max, float min)
    {
        maxValue = max;
        curValue = max;
        minValue = min;
    }
    public float maxValue
    {
        get
        {
            return _max_value;
        }
        set
        {
            if (value >= _min_value)
            {
                _max_value = value;
            }
            else
            {
                Debug.LogError("_max_value is less than _min_value");
            }
        }
    }
    public float curValue
    {
        get
        {
            return _cur_value;
        }
        set
        {
            if (value >= _max_value)
            {
                _cur_value = _max_value;
                //Debug.Log("_cur_value is more than _max_value, set it as _max_value");
            }
            else if (value <= _min_value)
            {
                _cur_value = _min_value;
                //Debug.Log("_cur_value is less than _max_value, set it as _min_value");
            }
            else
            {
                _cur_value = value;
            }
        }
    }
    public float minValue
    {
        get
        {
            return _min_value;
        }
        set
        {
            if (value <= _max_value)
            {
                _min_value = value;
            }
            else
            {
                Debug.LogError("_min_value is more than _max_value");
            }
        }
    }


}
