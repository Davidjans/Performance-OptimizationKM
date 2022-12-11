using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MinMaxVelocity : MonoBehaviour
{
    public float2 value;
}

public class MinMaxVelocityBaker : Baker<MinMaxVelocity>
{
    public override void Bake(MinMaxVelocity authoring)
    {
        AddComponent(new MinMaxVelocityEC
        {
            value = authoring.value
        });
    }
}

public struct MinMaxVelocityEC : IComponentData
{
    public float2 value;
}