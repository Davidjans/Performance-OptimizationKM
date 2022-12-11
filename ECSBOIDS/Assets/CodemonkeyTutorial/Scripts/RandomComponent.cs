
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RandomComponent : MonoBehaviour
{
    public uint seed;
}

public class RandomBaker : Baker<RandomComponent>
{
    public override void Bake(RandomComponent random)
    {
        AddComponent(new RandomEC
        {
            random = new Random(random.seed)
        });
    }
}


public struct RandomEC : IComponentData
{
    public Random random;
}
