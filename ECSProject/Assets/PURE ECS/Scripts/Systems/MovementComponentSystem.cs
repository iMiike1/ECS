﻿using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using System;

public class MovementComponentSystem : Unity.Entities.JobComponentSystem
{
    //public JobHandle MoveHandle { get; private set; }
    [ComputeJobOptimization]
    struct MovementJob : Unity.Entities.IJobProcessComponentData<Unity.Transforms.Position, Unity.Transforms.Rotation, Speed>
    {

        public float DeltaTime;
        //public float SValue;
        public void Execute(ref Unity.Transforms.Position pos, ref Unity.Transforms.Rotation rot, ref Speed speed)
        {

            float3 PositionValue = pos.Value;
            float SValue = speed.Value;
            PositionValue.y -= 1.0f * DeltaTime;
            pos.Value.y = PositionValue.y;

            speed.Value = SValue;
        }
        
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        MovementJob MJob = new MovementJob
        {
            DeltaTime = UnityEngine.Time.deltaTime,
            
            
    };
       
        JobHandle MoveHandle = MJob.Schedule(this, inputDeps);

        return MoveHandle;
    }
}