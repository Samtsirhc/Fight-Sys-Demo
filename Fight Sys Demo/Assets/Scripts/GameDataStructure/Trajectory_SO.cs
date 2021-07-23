using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trajectory", menuName = "Data/Trajectory")]
public class Trajectory_SO : ScriptableObject
{
    [Header("Trajectory Info")]
    public TrajectoryType trajectoryType = TrajectoryType.FLY_TO_TARGET;
    public float speed = 1;
    public float maxDistance = 0;

    [Header("Fly to Target")]
    public float maxAngularSpeed = 0;

    [Header("Straight")]
    public float t = 0;
}
