using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
public class PersonalizedCenterOfMass : MonoBehaviour
{
    public float3 value;
}

public class PersonalizedCenterOfMassBaker : Baker<PersonalizedCenterOfMass>
{
    public override void Bake(PersonalizedCenterOfMass authoring)
    {
        AddComponent(new PersonalizedCenterOfMassEC
        {
            value = authoring.value
        });
    }
}

public struct PersonalizedCenterOfMassEC : IComponentData
{
    public float3 value;
}
