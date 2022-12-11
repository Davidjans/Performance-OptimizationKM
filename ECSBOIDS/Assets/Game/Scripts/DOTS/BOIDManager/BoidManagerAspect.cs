using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct BoidManagerAspect : IAspect
{
    public readonly RefRW<BoidListEC> boidList;
    public readonly RefRO<MassPercentagePerFrameEC> massPercentagePerFrame;
    public readonly RefRO<DistanceToKeepEC>  distanceToKeep;
    public readonly RefRO<SharedVelocityDivisionFactorEC>  sharedVelocityDivisionFactor;
    public readonly RefRO<GoalPercentagePerFrameEC>  goalPercentagePerFrame;
    public readonly RefRW<CenterOfMassEC> centerOfMass;
    //public readonly RefRW<GoalEntityEC> goalEntity;
    //public readonly RefRW<GoalTransformEC> goalTransform;

    public void Setup(EntityManager em)
    {
        // i can probably optimize this better by seperating it less or executing it less but i'm not sure where yet or just generally finding a way to do it better.
        EntityQuery boidsQuery = em.CreateEntityQuery(typeof(BoidTagEC));
        NativeArray<Entity> boidEntities = boidsQuery.ToEntityArray(Allocator.Temp);  //boidManager.ValueRW.boidList = boidsQuery.ToEntityArray(Allocator.Temp);
        boidList.ValueRW.value = new NativeArray<BoidAspect>(boidEntities.Length, Allocator.Temp);
        
        for (int i = 0; i < boidEntities.Length; i++)
        {
            boidList.ValueRW.value[i] = em.GetAspect<BoidAspect>(boidEntities[i]);
        } 
    }

    public void SetCenterMass()
    {
        centerOfMass.ValueRW.value = float3.zero;
        foreach (var boi in boidList.ValueRW.value)
        {
            centerOfMass.ValueRW.value += boi.GetPosition();
        }
    }

    public void SetGoal(EntityManager em)
    {
        //goalTransform.ValueRW.value = em.GetAspect<TransformAspect>(goalEntity.ValueRO.value);
    }
}