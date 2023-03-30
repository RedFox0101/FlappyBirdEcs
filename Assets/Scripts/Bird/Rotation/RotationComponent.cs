using System.Collections;
using UnityEngine;

[System.Serializable]
public struct RotationComponent
{
    public Quaternion topRotation;
    public Quaternion buttomRotation;
    public float Speed;
    public Transform Transform;
}
