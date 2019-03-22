using Unity.Transforms;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static EntityManager manager;
    public GameObject RedStar;
    public GameObject WhiteStar;
    public GameObject OrangeStar;

    public Material RedMat;
    public Material WhiteMat;
    public Material OrangeMat;

    public Text eText;
    public int Entities;
    public Mesh sphere;
    public int nucleusAmount;

    public int RedStarAmount;
    public int WhiteStarAmount;
    public int OrangeStarAmount;
    public int OrangeStarAmountLarge;

    public float3 OPos;

    // Use this for initialization
    void Start() {

        manager = World.Active.GetOrCreateManager<EntityManager>();
        AddCube(nucleusAmount, RedStarAmount);
        Counter();
    }


    private void OnApplicationQuit()
    {
        Unity.Entities.World.Active.Dispose();

    }

    public void Counter()
    {
        Entities = -1;
        NativeArray<Entity> CounterE = manager.GetAllEntities();

        for (int i = 0; i < CounterE.Length; i++)
        {
            Entities += 1;   
        }
        CounterE.Dispose();
    }

    private void Update()
    {
        
        eText.text = "Entities: " + Entities; 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //AddCube(nucleusAmount, RedStarAmount);
            addRedStars(OPos);
            addWhiteStars(OPos);
            addOrangeStars(OPos);
            addOrangeStarsLarge(OPos);
            Counter();
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            
            IncreaseSpeed(UnityEngine.Random.Range(1f,3f));

        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            
            IncreaseSpeed(UnityEngine.Random.Range(.01f,.1f));

        }


    }


    public void IncreaseSpeed(float value)
    {
        NativeArray<Entity> AllEntities =  manager.GetAllEntities();

        for (int i = 0; i < AllEntities.Length; i++)
        {
            manager.SetComponentData(AllEntities[i], new Speed { RValue = value});
        }
        AllEntities.Dispose();
    }


    void AddCube(int nucleusAmount, int starAmount)
    {

        Position vectorpos;
        
        NativeArray<Entity> nucleusEntities = new NativeArray<Entity>(nucleusAmount, Allocator.Temp);
        manager.Instantiate(RedStar, nucleusEntities);

        for (int i = 0; i < nucleusAmount; i++)
        {
            manager.SetComponentData(nucleusEntities[i], new Position { Value = new float3(UnityEngine.Random.Range(1, 100), 0, UnityEngine.Random.Range(1, 100)) });
            vectorpos = manager.GetComponentData<Position>(nucleusEntities[i]);
            float posx = vectorpos.Value.x;
            float posy = vectorpos.Value.y;
            float posz = vectorpos.Value.z;
            Vector3 originPos = new Vector3(posx, posy, posz);
            OPos = originPos;
            manager.SetComponentData(nucleusEntities[i], new Speed { Value = 10f });
            addRedStars( originPos);
            addWhiteStars( originPos);
            addOrangeStars(originPos);
            addOrangeStarsLarge(originPos);
        }
        nucleusEntities.Dispose();
    }
    
    void addRedStars(Vector3 originPos)
    {

        NativeArray<Entity> starEntities = new NativeArray<Entity>(RedStarAmount, Allocator.Temp);
        manager.Instantiate(RedStar, starEntities);
        
        //inserire ogni gameobject instanziato su una lista (NativeList<Entity>(quantita' stelle)),instaziare stelle e poi distruggere native array in modo di avere una lista contente ogni entita' stella disponibile per modifica
        for (int j = 0; j < RedStarAmount; j++)
        {
            /////////////////////////////////////WO/RKING RANDOM COLOR JUST UNCOMENNT LINES BELOW/////////////////////////////////////////////
           

            //Material starMat = new Material(Shader.Find("Diffuse"));
            //starMat.color = new UnityEngine.Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
            //manager.SetSharedComponentData(starEntities[j], new MeshInstanceRenderer { mesh = sphere, material = starMat });

            manager.SetComponentData(starEntities[j], new Position { Value = new float3(UnityEngine.Random.Range(originPos.x-3000,3000.0f), UnityEngine.Random.Range(originPos.y - 200, 200), UnityEngine.Random.Range(originPos.z-3000,3000)) });
            manager.SetComponentData(starEntities[j], new Speed { Value = UnityEngine.Random.Range(1f, 20f) });
            manager.SetComponentData(starEntities[j], new Speed { RValue = UnityEngine.Random.Range(-.2f, .5f) });
            
                        
        }
        starEntities.Dispose();
        
     }

    void addWhiteStars( Vector3 originPos)
    {

        NativeArray<Entity> WhiteStarEntities = new NativeArray<Entity>(WhiteStarAmount, Allocator.Temp);
        manager.Instantiate(WhiteStar, WhiteStarEntities);

        //inserire ogni gameobject instanziato su una lista (NativeList<Entity>(quantita' stelle)),instaziare stelle e poi distruggere native array in modo di avere una lista contente ogni entita' stella disponibile per modifica
        for (int j = 0; j < WhiteStarAmount; j++)
        {
            /////////////////////////////////////WO/RKING RANDOM COLOR JUST UNCOMENNT LINES BELOW/////////////////////////////////////////////


            //Material starMat = new Material(Shader.Find("Diffuse"));
            //starMat.color = new UnityEngine.Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
            //manager.SetSharedComponentData(starEntities[j], new MeshInstanceRenderer { mesh = sphere, material = starMat });

            manager.SetComponentData(WhiteStarEntities[j], new Position { Value = new float3(UnityEngine.Random.Range(originPos.x - 3000, 3000.0f), UnityEngine.Random.Range(originPos.y - 200, 200), UnityEngine.Random.Range(originPos.z - 3000, 3000)) });
            manager.SetComponentData(WhiteStarEntities[j], new Speed { Value = UnityEngine.Random.Range(1f, 20f) });
            manager.SetComponentData(WhiteStarEntities[j], new Speed { RValue = UnityEngine.Random.Range(.1f, 5f) });
           

        }
        WhiteStarEntities.Dispose();

    }

    void addOrangeStars(Vector3 originPos)
    {

        NativeArray<Entity> OrangeStarEntities = new NativeArray<Entity>(OrangeStarAmount, Allocator.Temp);
        manager.Instantiate(OrangeStar, OrangeStarEntities);

        //inserire ogni gameobject instanziato su una lista (NativeList<Entity>(quantita' stelle)),instaziare stelle e poi distruggere native array in modo di avere una lista contente ogni entita' stella disponibile per modifica
        for (int j = 0; j < OrangeStarAmount; j++)
        {
            /////////////////////////////////////WO/RKING RANDOM COLOR JUST UNCOMENNT LINES BELOW/////////////////////////////////////////////


            //Material starMat = new Material(Shader.Find("Diffuse"));
            //starMat.color = new UnityEngine.Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
            //manager.SetSharedComponentData(starEntities[j], new MeshInstanceRenderer { mesh = sphere, material = starMat });

            manager.SetComponentData(OrangeStarEntities[j], new Position { Value = new float3(UnityEngine.Random.Range(originPos.x - 1000, 1000.0f), UnityEngine.Random.Range(originPos.y - 300, 300), UnityEngine.Random.Range(originPos.z - 1000, 1000)) });
            manager.SetComponentData(OrangeStarEntities[j], new Speed { Value = UnityEngine.Random.Range(1f, 20f) });
            manager.SetComponentData(OrangeStarEntities[j], new Speed { RValue = UnityEngine.Random.Range(-.2f, .5f) });


        }
        OrangeStarEntities.Dispose();

    }
    void addOrangeStarsLarge(Vector3 originPos)
    {

        NativeArray<Entity> OrangeStarEntitieslarge = new NativeArray<Entity>(OrangeStarAmountLarge, Allocator.Temp);
        manager.Instantiate(OrangeStar, OrangeStarEntitieslarge);

        //inserire ogni gameobject instanziato su una lista (NativeList<Entity>(quantita' stelle)),instaziare stelle e poi distruggere native array in modo di avere una lista contente ogni entita' stella disponibile per modifica
        for (int j = 0; j < OrangeStarAmountLarge; j++)
        {
            /////////////////////////////////////WO/RKING RANDOM COLOR JUST UNCOMENNT LINES BELOW/////////////////////////////////////////////
            //Material starMat = new Material(Shader.Find("Diffuse"));
            //starMat.color = new UnityEngine.Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
            //manager.SetSharedComponentData(starEntities[j], new MeshInstanceRenderer { mesh = sphere, material = starMat });

            manager.SetComponentData(OrangeStarEntitieslarge[j], new Position { Value = new float3(UnityEngine.Random.Range(originPos.x - 4000.0f, 4000.0f), UnityEngine.Random.Range(originPos.y - 100.0f, 100.0f), UnityEngine.Random.Range(originPos.z - 4000.0f, 4000.0f)) });
            manager.SetComponentData(OrangeStarEntitieslarge[j], new Speed { Value = UnityEngine.Random.Range(1f, 20f) });
            manager.SetComponentData(OrangeStarEntitieslarge[j], new Speed { RValue = UnityEngine.Random.Range(-.2f, .5f) });


        }
        OrangeStarEntitieslarge.Dispose();

    }

}
