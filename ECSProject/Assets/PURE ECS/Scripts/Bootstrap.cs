using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;


public class Bootstrap : MonoBehaviour {

    public float Speed;
    private void Start()
    {
        

        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        var galaxyEntity = entityManager.CreateEntity
            (
            ComponentType.Create<Speed>(),
            ComponentType.Create<Position>(),
            ComponentType.Create<LocalToWorld>(),
            ComponentType.Create<MeshInstanceRenderer>(),
            ComponentType.Create<Rotation>(),
            //ComponentType.Create<RotateAround>(),
            ComponentType.Create<Counter>()
            );

        entityManager.SetComponentData(galaxyEntity, new Speed { Value = Speed });

    }




}
