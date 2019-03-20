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
    public int nucleusAmount;
    public int starAmount;
    
    // Use this for initialization
    void Start () {

        manager = World.Active.GetOrCreateManager<EntityManager>();
        AddCube(nucleusAmount, starAmount);
	}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCube(nucleusAmount, starAmount);
        }
    }

    void AddCube(int nucleusAmount, int starAmount)
    {
        
        Position vectorpos;
        int NCDistance = 5;//nucleus-star distance
        NativeArray<Entity> nucleusEntities = new NativeArray<Entity>(nucleusAmount, Allocator.Temp);
        manager.Instantiate(GameObjectEntity, nucleusEntities);
        for (int i = 0; i < nucleusAmount; i++)
        {
            manager.SetComponentData(nucleusEntities[i], new Position { Value = new float3(UnityEngine.Random.Range(1, 100), 0, UnityEngine.Random.Range(1, 100)) });
            vectorpos = manager.GetComponentData<Position>(nucleusEntities[i]);
            float posx = vectorpos.Value.x;
            float posz = vectorpos.Value.z;
            manager.SetComponentData(nucleusEntities[i], new Speed { Value = 10f});    
           AddAnotherCube(NCDistance, GameObjectEntity, posx + NCDistance, posz + NCDistance,nucleusAmount);  
        }
        nucleusEntities.Dispose();
    }

    void AddAnotherCube(int NCDistance, GameObject GO, float posx, float posz,int nucleusAmount)
    {
        NativeArray<Entity> starEntities = new NativeArray<Entity>(starAmount, Allocator.Temp);
        manager.Instantiate(GameObjectEntity, starEntities);

        //inserire ogni gameobject instanziato su una lista (NativeList<Entity>(quantita' stelle)),instaziare stelle e poi distruggere native array in modo di avere una lista contente ogni entita' stella disponibile per modifica


        for (int j = 0; j < starAmount; j++)
        {
            manager.SetComponentData(starEntities[j], new Position { Value = new float3(posx + NCDistance, 0, posz + NCDistance) });
            //manager.SetComponentData(starEntities[j], new Rotation { Value = new Quaternion(0, 0, 90,0) });
            manager.SetComponentData(starEntities[j], new Speed { Value = UnityEngine.Random.Range(1f, 20f) });
            NCDistance += 5;
        }
        starEntities.Dispose();
    }

}
