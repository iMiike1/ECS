using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Entities;

public class GameManager : MonoBehaviour {

    Unity.Entities.EntityManager manager;
    public GameObject GameObjectEntity;
    public int amount;
	// Use this for initialization
	void Start () {

        manager = Unity.Entities.World.Active.GetOrCreateManager<Unity.Entities.EntityManager>();
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
        Unity.Collections.NativeArray<Unity.Entities.Entity> entities = new Unity.Collections.NativeArray<Unity.Entities.Entity>(amount, Unity.Collections.Allocator.Temp);
        manager.Instantiate(GameObjectEntity, entities);
        for (int i = 0; i < amount; i++)
        {
            manager.SetComponentData(entities[i], new Unity.Transforms.Position { Value = new Unity.Mathematics.float3(Random.Range(1, 400),0, Random.Range(1, 400)  ) });

            manager.SetComponentData(entities[i], new Speed { Value = 10f  });

        }
        entities.Dispose();
    }

}
