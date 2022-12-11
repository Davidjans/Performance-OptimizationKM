using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public float3 value;
}

public class TargetPositionBaker : Baker<TargetPosition>
{
    public override void Bake(TargetPosition speed)
    {
        AddComponent(new TargetPositionEC
        {
            value = speed.value
        });
    }
}

public struct TargetPositionEC : IComponentData
{
    public float3 value;
}
