using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using System;
using Unity.Transforms;
using UnityEngine;
using Unity.Rendering;
using Unity.Burst;

public class MovementComponentSystem : JobComponentSystem
{
    public static float n;
    public static float3 RotateAroundPoint(float3 position, float3 pivot, float3 axis, float delta) => math.mul(quaternion.AxisAngle(axis, delta), position - pivot) + pivot;


    [BurstCompile(CompileSynchronously = true)]
    struct MovementJob : IJobProcessComponentData<Position, Rotation, Speed>
    {
        

        public float DeltaTime;
       
        

        //public float SValue;
        public void Execute(ref Position pos, ref Rotation rot, ref Speed speed)
        {
            float3 PositionValue = pos.Value;
            float SValue = speed.Value;
            
            PositionValue.y -= 0.0f * DeltaTime;
            //pos.Value.y = PositionValue.y;
            float4 RotationValue = rot.Value.value;

            Quaternion rotation = new Quaternion(RotationValue.x, RotationValue.y, RotationValue.z, RotationValue.w);
            Vector3 euler = rotation.eulerAngles;
            euler.y += DeltaTime * 0;

            rotation.eulerAngles = euler;

            RotationValue = new float4(rotation.x, rotation.y, rotation.z, rotation.w);

            rot.Value.value = RotationValue;
            

            PositionValue = RotateAroundPoint(PositionValue, new float3(0, 0, 0), new float3(0,1,0), speed.RValue/10 * DeltaTime);

            pos.Value = PositionValue;
            
            speed.Value = SValue;
        }
        
    }

   



    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        MovementJob MJob = new MovementJob
        {
            DeltaTime = Time.deltaTime,
            
        };
       
        JobHandle MoveHandle = MJob.Schedule(this, inputDeps);

        return MoveHandle;
    }
}