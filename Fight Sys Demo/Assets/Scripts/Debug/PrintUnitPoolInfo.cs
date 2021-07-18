using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintUnitPoolInfo : MonoBehaviour
{
    Text text;
    

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        text.text = UnitPool.FormatUnitInfo();
    }
}
