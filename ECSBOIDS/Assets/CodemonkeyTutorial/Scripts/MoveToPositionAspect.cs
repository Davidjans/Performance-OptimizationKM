
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity entity; 
    private readonly TransformAspect transform;
    private readonly RefRO<SpeedEC> speed;
    private readonly RefRW<TargetPositionEC> targetPosition;

    public void Move(float deltaTime)
    {
        float3 direction = math.normalize(targetPosition.ValueRW.value - transform.WorldPosition);
        transform.WorldPosition += direction * (deltaTime * speed.ValueRO.value);
    }
    
    
    // splitting the functionality because of the multiple threads.
    public void TestReachedPosition(RefRW<RandomEC> randomComponent)
    {
        float reachedTargetDistance = 0.5f;
        float distance = math.distancesq(transform.WorldPosition,targetPosition.ValueRW.value);
        if(distance < reachedTargetDistance)
        {
            targetPosition.ValueRW.value = GetRandomPosition(randomComponent);
            //Debug.Log(targetPosition.ValueRW.value);
        }
    }
    
    private float3 GetRandomPosition(RefRW<RandomEC> randomComponent)
    {
        return new float3(
            randomComponent.ValueRW.random.NextFloat(-400f,400f)
            , 0.5f,
            randomComponent.ValueRW.random.NextFloat(-400f,400f));
    }
}
