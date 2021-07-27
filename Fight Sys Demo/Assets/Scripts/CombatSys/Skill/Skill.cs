using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill : Subunit
{

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
}
