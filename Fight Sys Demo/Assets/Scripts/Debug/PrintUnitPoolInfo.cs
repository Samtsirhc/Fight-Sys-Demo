using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrintUnitPoolInfo : MonoBehaviour
{
    Text text;
    

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        text.text = UnitPool.Instance.FormatUnitInfo();

    }
}
