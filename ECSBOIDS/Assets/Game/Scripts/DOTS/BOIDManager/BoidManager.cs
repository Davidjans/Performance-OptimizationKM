using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
}

public class BoidManagerBaker : Baker<BoidManager>
{
    public override void Bake(BoidManager authoring)
    {
        AddComponent(new BoidManagerEC
        {
            singletonplaceholder = 5
        });
    }
}
public struct BoidManagerEC : IComponentData
{
    public float singletonplaceholder;
}