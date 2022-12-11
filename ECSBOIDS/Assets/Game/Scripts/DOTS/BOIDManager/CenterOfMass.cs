using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public float3 value;
}

public class CenterOfMassBaker : Baker<CenterOfMass>
{
    public override void Bake(CenterOfMass authoring)
    {
        AddComponent(new CenterOfMassEC
        {
            value = authoring.value
        });
    }
}

public struct CenterOfMassEC : IComponentData
{
    public float3 value;
}