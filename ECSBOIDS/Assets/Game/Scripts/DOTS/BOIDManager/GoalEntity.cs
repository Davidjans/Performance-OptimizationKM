using Unity.Entities;
using UnityEngine;

public class GoalEntity : MonoBehaviour
{
    public Entity value;
}

public class GoalEntityBaker : Baker<GoalEntity>
{
    public override void Bake(GoalEntity authoring)
    {
        AddComponent(new GoalEntityEC
        {
            value = authoring.value
        });
    }
}

public struct GoalEntityEC : IComponentData
{
    public Entity value;
}