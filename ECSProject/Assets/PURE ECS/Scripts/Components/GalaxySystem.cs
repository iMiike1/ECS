using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;



public class GalaxySystem : JobComponentSystem {


    private struct GalaxySystemJob : IJobProcessComponentData<Position>
    {
        public float DeltaTime;

        public void Execute(ref Position pos)
        {
           
        }
    }


}
