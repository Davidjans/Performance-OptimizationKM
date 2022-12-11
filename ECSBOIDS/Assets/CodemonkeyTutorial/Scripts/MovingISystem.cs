using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[BurstCompile]
public partial struct MovingISystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        /*RefRW<RandomEC> randomComponent = SystemAPI.GetSingletonRW<RandomEC>();
        float deltaTime = SystemAPI.Time.DeltaTime;
        JobHandle jobHandle = new MoveJob()
        {
            deltaTime =  deltaTime
        }.ScheduleParallel(state.Dependency);
        
        jobHandle.Complete();
        
        new TargetReached
        {
            random = randomComponent 
        }.Schedule();*/
    }
}
[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float deltaTime;
    [BurstCompile]
    public void Execute(MoveToPositionAspect moveAspect)
    {
        moveAspect.Move(deltaTime);     
    }
}
[BurstCompile]
public partial struct TargetReached : IJobEntity
{
    [NativeDisableUnsafePtrRestriction]
    public RefRW<RandomEC> random;
    [BurstCompile]
    public void Execute(MoveToPositionAspect moveAspect)
    {
        moveAspect.TestReachedPosition(random);     
    }
}