using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class PlayerSpawnerSystem : SystemBase
{
    protected override void OnCreate()
    {
        base.OnCreate();
        /*PlayerSpawnerEC playerSpawner = SystemAPI.GetSingleton<PlayerSpawnerEC>();

        for (int i = 0; i < 100000; i++)
        {
            EntityManager.Instantiate(playerSpawner.playerPrefab);
        }*/
    }

    protected override void OnUpdate()
    {
      
        /*
        RefRW<RandomEC> randomComponent = SystemAPI.GetSingletonRW<RandomEC>();


        PlayerSpawnerEC playerSpawner = SystemAPI.GetSingleton<PlayerSpawnerEC>();
        
        EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
        int spawnAmount = 10;
        EntityQuery playerEntityQuery = EntityManager.CreateEntityQuery(typeof(PlayerTagEC));
        if (playerEntityQuery.CalculateEntityCount() < spawnAmount)
        {
            for (int i = 0; i < 200000; i++)
            {
                Entity spawnedEntity = entityCommandBuffer.Instantiate(playerSpawner.playerPrefab);
                entityCommandBuffer.SetComponent(spawnedEntity,new SpeedEC
                {
                    value = randomComponent.ValueRW.random.NextFloat(10f,30f)
                });
            }
        }*/
    }
}
