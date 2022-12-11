using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct BoidManageISystem : ISystem
{
    
    private BoidManagerAspect boidManager;
    private bool started;
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
        Debug.LogError("it actually did oncreate for boidmanagesystem");
    }
    
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
    
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if (!started)
        {
            EntityQuery playerTagEntityQuery = state.EntityManager.CreateEntityQuery(typeof(BoidManagerEC));
            //Entity manager = playerTagEntityQuery.ToEntityArray(Allocator.Temp)[0];
            Entity manager = SystemAPI.GetSingletonEntity<BoidManagerEC>();
            boidManager = SystemAPI.GetAspectRW<BoidManagerAspect>(manager);
            boidManager.SetGoal(state.EntityManager);
        
            new SetupBoidManagerJob()
            {
                em = state.EntityManager
            }.Run();
            started = true;
        }
        
        JobHandle massHandle = new GetCenterMassJob
        {
            em = state.EntityManager
        }.Schedule(state.Dependency);
        
        massHandle.Complete();
        
        JobHandle rulesHandle = new BoidRuleJob()
        {
            manager = boidManager
        }.ScheduleParallel(state.Dependency);
        
        rulesHandle.Complete();
    }
}

[BurstCompile]
public partial struct BoidRuleJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction]
    public BoidManagerAspect manager;
    [BurstCompile]
    public void Execute(BoidAspect boidAspect)
    {
        boidAspect.DoBoidRules(manager);
    }
}

[BurstCompile]
public partial struct GetCenterMassJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction]
    public EntityManager em;
    [BurstCompile]
    public void Execute(BoidManagerAspect boidManager)
    {
        boidManager.SetCenterMass();
        
    }
}
[BurstCompile]
public partial struct SetupBoidManagerJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction]
    public EntityManager em;
    [BurstCompile]
    public void Execute(BoidManagerAspect boidManager)
    {
        boidManager.Setup(em);
    }
}
