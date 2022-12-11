using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BoidTag : MonoBehaviour
{
}

public class BoidTagBaker : Baker<BoidTag>
{
    public override void Bake(BoidTag authoring)
    {
        AddComponent(new BoidTagEC());
    }
}

public struct BoidTagEC : IComponentData
{
}