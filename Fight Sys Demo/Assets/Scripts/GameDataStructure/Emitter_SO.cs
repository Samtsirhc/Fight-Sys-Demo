using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Emitter", menuName = "Data/Emitter")]
public class Emitter_SO : ScriptableObject
{
    public float radius = 0;
    public List<float> mouthPosition = new List<float>();
    public List<float> fireTime = new List<float>();
    
}
