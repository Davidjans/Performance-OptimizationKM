using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BoidList : MonoBehaviour
{
}

public class BoidListBaker : Baker<BoidList>
{
    public override void Bake(BoidList authoring)
    {
        AddComponent(new BoidListEC());
    }
}
public struct BoidListEC : IComponentData
{
    public NativeArray<BoidAspect> value;
}