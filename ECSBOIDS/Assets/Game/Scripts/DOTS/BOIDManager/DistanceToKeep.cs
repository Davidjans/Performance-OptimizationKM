using Unity.Entities;
using UnityEngine;

public class DistanceToKeep : MonoBehaviour
{
    public float value;
}

public class DistanceToKeepBaker : Baker<DistanceToKeep>
{
    public override void Bake(DistanceToKeep authoring)
    {
        AddComponent(new DistanceToKeepEC
        {
            value = authoring.value
        });
    }
}
public struct DistanceToKeepEC : IComponentData
{
    public float value;
}