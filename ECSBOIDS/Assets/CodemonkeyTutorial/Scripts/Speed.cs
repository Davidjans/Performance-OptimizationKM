using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float value;
}

public class SpeedBaker : Baker<Speed>
{
    public override void Bake(Speed speed)
    {
            AddComponent(new SpeedEC
            {
                value = speed.value
            });
    }
}

public struct SpeedEC : IComponentData
{
    public float value;
}
