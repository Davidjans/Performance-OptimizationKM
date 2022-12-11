using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        /*RefRW<RandomEC> random = SystemAPI.GetSingletonRW<RandomEC>();
        foreach (MoveToPositionAspect moveAspect in
                 SystemAPI.Query<MoveToPositionAspect>())
        {
            moveAspect.Move(SystemAPI.Time.DeltaTime,random);
        }*/
    }
}