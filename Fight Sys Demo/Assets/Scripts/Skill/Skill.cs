using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill : MonoBehaviour
{
    protected Unit master;


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
    }


}
