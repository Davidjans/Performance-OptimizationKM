using Unity.Entities;
using UnityEngine;

public class SharedVelocityDivisionFactor : MonoBehaviour
{
    public float value;
}

public class SharedVelocityDivisionBaker : Baker<SharedVelocityDivisionFactor>
{
    public override void Bake(SharedVelocityDivisionFactor authoring)
    {
        AddComponent(new SharedVelocityDivisionFactorEC
        {
            value = authoring.value
        });
    }
}

public struct SharedVelocityDivisionFactorEC : IComponentData
{
    public float value;
}