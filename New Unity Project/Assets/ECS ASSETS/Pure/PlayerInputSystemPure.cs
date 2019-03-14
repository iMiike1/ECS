using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;


public class PlayerInputSystemPure : JobComponentSystem
{
    private struct PlayerInputJob : IJobProcessComponentData<PlayerInputPure>
    {
        public float Horizontal;


        public void Execute(ref PlayerInputPure input)
        {
            input.Horizontal = Horizontal;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerInputJob
        {
            Horizontal = Input.GetAxis("Horizontal")
        };
        return job.Schedule(this, 64, inputDeps);

    }


}
