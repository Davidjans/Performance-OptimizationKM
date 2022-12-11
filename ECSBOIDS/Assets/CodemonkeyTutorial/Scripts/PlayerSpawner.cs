using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
}

public class PlayerSpawnerBaker : Baker<PlayerSpawner>
{
    public override void Bake(PlayerSpawner playerSpawner)
    {
        AddComponent(new PlayerSpawnerEC
        {
            playerPrefab = GetEntity(playerSpawner.playerPrefab)
        });
    }
}


public struct PlayerSpawnerEC : IComponentData
{
    public Entity playerPrefab;
}
