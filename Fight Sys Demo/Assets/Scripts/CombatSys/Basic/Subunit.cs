using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subunit : MonoBehaviour
{
    [HideInInspector]
    public Unit master;
    [HideInInspector]
    public Unit target;
    [HideInInspector]
    public bool isInited = false;
    public int skillLevel = 1;

}
