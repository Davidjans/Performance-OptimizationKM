using Unity.Entities;
using UnityEngine;

public class GoalPercentagePerFrame : MonoBehaviour
{
    public float value;
}

public class GoalPercentagePerFrameBaker : Baker<GoalPercentagePerFrame>
{
    public override void Bake(GoalPercentagePerFrame authoring)
    {
        AddComponent(new GoalPercentagePerFrameEC
        {
            value = authoring.value
        });
    }
}
public struct GoalPercentagePerFrameEC : IComponentData
{
    public float value;
}