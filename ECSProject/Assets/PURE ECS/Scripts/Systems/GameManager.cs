using System.Collections;
using System.Collections.Generic;
using Unity.Transforms;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;

public class GameManager : MonoBehaviour {

    EntityManager manager;
    public GameObject GameObjectEntity;
    public int amount;
    public int starAmount;
	// Use this for initialization
	void Start () {

        manager = World.Active.GetOrCreateManager<EntityManager>();
        AddCube(amount);
	}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCube(amount);
        }
    }

    void AddCube(int amount)
    {
        float posx;
        float posz;
        Position vectorpos;
        int NCDistance = 5;//nucleus-star distance
        NativeArray<Entity> entities = new NativeArray<Entity>(amount, Allocator.Temp);
        manager.Instantiate(GameObjectEntity, entities);
        for (int i = 0; i < amount; i++)
        {
            manager.SetComponentData(entities[i], new Position { Value = new float3(UnityEngine.Random.Range(1, 10), 0, UnityEngine.Random.Range(1, 10)) });
            vectorpos = manager.GetComponentData<Position>(entities[i]);
            posx = vectorpos.Value.x;
            posz = vectorpos.Value.z;
            AddAnotherCube(starAmount, i, entities[i], NCDistance,posx,posz);
            manager.SetComponentData(entities[i], new Speed { Value = 10f});
            
            

        }
        entities.Dispose();
    }

    void AddAnotherCube(int starAmount,int i,Entity entity, int NCDistance,float posx,float posz)
    {
        NativeArray<Entity> entities = new NativeArray<Entity>(starAmount, Allocator.Temp);
        //manager.Instantiate(GameObjectEntity, entities,GameObjectEntity2);
        manager.Instantiate(entity, entities);
        //for (int i = 0; i < amount; i++)


        //{
        manager.SetComponentData(entities[i], new Position {Value = new float3(posx + NCDistance + 5, 0, posz+NCDistance + 5)});
        
        manager.SetComponentData(entities[i], new Speed { Value = 10f });

        //}
        entities.Dispose();
    }

}
