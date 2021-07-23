using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_debug : MonoBehaviour
{
    public GameObject ttt;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Log");
        Debug.LogWarning("LogWarning");
        Debug.LogError("LogError");
        Debug.LogAssertion("LogAssertion");
        Debug.Log(BasicMath.GetPointOnCircle(10, 180, new Vector3(0, 0, 1), new Vector3(0, 0, 0), new Vector3(1, 0, 0)));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
