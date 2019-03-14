using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class PlayerMovementSystemPure : JobComponentSystem {

    private struct PlayerMovementJob : IJobProcessComponentData<SpeedPure, PlayerInputPure, Position>
    {
        public float DeltaTime;

        public void Execute(ref SpeedPure speed, ref PlayerInputPure input, ref Position position)
        {
            position.Value.x += speed.Value * input.Horizontal * DeltaTime ;
        }
    }


    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerMovementJob
        {
            DeltaTime = Time.deltaTime
        };
        return job.Schedule(this, 64, inputDeps);
    }
}
