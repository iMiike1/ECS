using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using System;
using Unity.Transforms;
using UnityEngine;

public class MovementComponentSystem : JobComponentSystem
{
    struct MovementJob : IJobProcessComponentData<Position, Rotation, Speed>
    {
        public float DeltaTime;
        public static float3 RotateAroundPoint(float3 position, float3 pivot, float3 axis, float delta) => math.mul(quaternion.AxisAngle(axis, delta), position - pivot) + pivot;
        //public float SValue;
        public void Execute(ref Position pos, ref Rotation rot, ref Speed speed)
        {          
            float3 PositionValue = pos.Value;
            float SValue = speed.Value;
            
            PositionValue.y -= 1.0f * DeltaTime;
            pos.Value.y = PositionValue.y;
            float4 RotationValue = rot.Value.value;

            Quaternion rotation = new Quaternion(RotationValue.x, RotationValue.y, RotationValue.z, RotationValue.w);
            Vector3 euler = rotation.eulerAngles;
            euler.y += DeltaTime * 100.00f;

            rotation.eulerAngles = euler;
            RotationValue = new float4(rotation.x, rotation.y, rotation.z, rotation.w);
            rot.Value.value = RotationValue;      
            speed.Value = SValue;

            rot.Value = math.mul(math.normalize(rot.Value), quaternion.AxisAngle(math.up(), speed.Value * DeltaTime));
            /*RotateAroundPoint(PositionValue, new Vector3(0,0,0), Vector3.up, DeltaTime * 200f)*/
            ;
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