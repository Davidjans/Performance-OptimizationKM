using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct BoidAspect : IAspect
{
    private readonly Entity entity; 
    private readonly RefRW<PersonalizedCenterOfMassEC> centerOfMass;
    private readonly RefRW<VelocityEC> velocity;
    private readonly RefRO<MinMaxVelocityEC> minMaxVelocity;
    private readonly TransformAspect transform;
    public void ChangeVelocity(float3 newVelocity)
    {
        velocity.ValueRW.value.x = Mathf.Clamp(newVelocity.x, minMaxVelocity.ValueRO.value.x, minMaxVelocity.ValueRO.value.y);
        velocity.ValueRW.value.y = Mathf.Clamp(newVelocity.y, minMaxVelocity.ValueRO.value.x, minMaxVelocity.ValueRO.value.y);
        velocity.ValueRW.value.z = Mathf.Clamp(newVelocity.z, minMaxVelocity.ValueRO.value.x, minMaxVelocity.ValueRO.value.y);
    }
    
    public float3 GetPosition()
    {
        return transform.WorldPosition;
    }

    public void DoBoidRules(BoidManagerAspect manager)
    {
        
        float3 centerMassResult = CenterMassRule(manager);
        float3 distancingResult = DistancingRule(manager);
        float3 sharedVelocityResult = SharedVelocityRule(manager);
        //float3 goalResult = GoalRule(manager);
        //Vector3 rule3Result = Vector3.zero;
            
        ChangeVelocity(velocity.ValueRO.value + centerMassResult + distancingResult + sharedVelocityResult /*+ goalResult*/);
        transform.WorldPosition += velocity.ValueRO.value;
    }
    
    private float3 CenterMassRule(BoidManagerAspect manager)
    {
        centerOfMass.ValueRW.value = (manager.centerOfMass.ValueRO.value - transform.WorldPosition) / (manager.boidList.ValueRO.value.Length - 1);
        return ( centerOfMass.ValueRO.value -  transform.WorldPosition) * manager.massPercentagePerFrame.ValueRO.value;
    }

    private float3 DistancingRule(BoidManagerAspect manager)
    {
        float3 result = float3.zero;
        foreach (var currentBoi in manager.boidList.ValueRW.value)
        {
            if (currentBoi.entity != entity && Vector3.Distance(transform.WorldPosition, currentBoi.transform.WorldPosition) <
                manager.distanceToKeep.ValueRO.value)
            {
                result -= (currentBoi.transform.WorldPosition - transform.WorldPosition);
            }
        }
        return result;
    }

    private float3 SharedVelocityRule(BoidManagerAspect manager)
    {
        float3 result = float3.zero;
        foreach (var currentBoi in manager.boidList.ValueRW.value)
        {
            if (currentBoi.entity != entity)
            {
                result += currentBoi.velocity.ValueRO.value;
            }
        }

        result /= (manager.boidList.ValueRO.value.Length - 1);
        return (result - velocity.ValueRO.value) / manager.sharedVelocityDivisionFactor.ValueRO.value;
    }

    /*private Vector3 GoalRule(BoidManagerAspect manager)
    {
        return (manager.goalTransform.ValueRO.value.WorldPosition - transform.WorldPosition) * manager.goalPercentagePerFrame.ValueRO.value;
    }*/
}
