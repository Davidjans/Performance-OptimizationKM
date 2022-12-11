using Unity.Entities;
using UnityEngine;

public class MassPercentagePerFrame : MonoBehaviour
{
    public float value;
}

public class MassPercentagePerFrameBaker : Baker<MassPercentagePerFrame>
{
    public override void Bake(MassPercentagePerFrame authoring)
    {
        AddComponent(new MassPercentagePerFrameEC
        {
            value = authoring.value
        });
    }
}

public struct MassPercentagePerFrameEC : IComponentData
{
    public float value;
}