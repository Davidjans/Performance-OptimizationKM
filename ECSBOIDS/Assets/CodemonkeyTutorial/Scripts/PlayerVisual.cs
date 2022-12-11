using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class PlayerVisual : MonoBehaviour
{
    private Entity targetEntity;
    
    
    
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            targetEntity = GetRandomEntity();
        if (targetEntity != Entity.Null)
        {
            Vector3 followPosition = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(targetEntity).Position;
            transform.position = followPosition;
        }
    }

    private Entity GetRandomEntity()
    { 
        EntityQuery playerTagEntityQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(PlayerTagEC));
       NativeArray<Entity> entityNativeArray = playerTagEntityQuery.ToEntityArray(Allocator.Temp);
       if (entityNativeArray.Length > 0)
       {
           return entityNativeArray[UnityEngine.Random.Range(0, entityNativeArray.Length)];
       }
       else
       {
           return Entity.Null;
       }
    }
}
