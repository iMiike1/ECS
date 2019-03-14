using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;


public class Bootstrap : MonoBehaviour {

    public float Speed;
    public Mesh Mesh;
    public Material Material;


    private void Start()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        var playerEntity = entityManager.CreateEntity(
            ComponentType.Create<SpeedPure>(),
            ComponentType.Create<PlayerInputPure>(),
            ComponentType.Create<Position>(),
            ComponentType.Create<TransformMatrix>(),
            ComponentType.Create<MeshInstanceRenderer>()
            );


        entityManager.SetComponentData(playerEntity, new SpeedPure { Value = Speed });
        entityManager.SetSharedComponentData(playerEntity, new MeshInstanceRenderer
        {
            mesh = Mesh,
            material = Material
        });



    }

}
