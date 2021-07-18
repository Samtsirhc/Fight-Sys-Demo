using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_debug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Log");
        Debug.LogWarning("LogWarning");
        Debug.LogError("LogError");
        Debug.LogAssertion("LogAssertion");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
