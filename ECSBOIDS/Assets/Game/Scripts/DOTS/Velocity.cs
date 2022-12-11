using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    public float3 value;
}

public class VelocityBaker : Baker<Velocity>
{
    public override void Bake(Velocity authoring)
    {
        AddComponent(new VelocityEC
        {
            value = authoring.value
        });
    }
}

public struct VelocityEC : IComponentData
{
    public float3 value;
}