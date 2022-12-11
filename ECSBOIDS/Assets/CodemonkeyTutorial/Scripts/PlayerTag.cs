using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
public class PlayerTag : MonoBehaviour
{
}

public class PlayerTagBaker : Baker<PlayerTag>
{
    public override void Bake(PlayerTag authoring)
    {
        AddComponent(new PlayerTagEC());
    }
}

public struct PlayerTagEC : IComponentData
{
}
