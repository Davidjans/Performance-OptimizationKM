using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class GoalTransform : MonoBehaviour
{
}

public class GoalTransformBaker : Baker<GoalTransform>
{
    public override void Bake(GoalTransform authoring)
    {
        AddComponent(new GoalTransformEC());
    }
}

public struct GoalTransformEC : IComponentData
{
    public TransformAspect value;
}