using UnityEngine;
using System.Collections;
using UnityEditor;

public class FoodRespawn : MonoBehaviour
{
    public GameObject Player;
    public string AssetName;
    public float spawnRadius = 100; //Distance from de center, usualy the player
    public float spawnTime = 3f;
    public int maxSpawn = 3;
    public int Spawn_count = 0;



    private SpriteRenderer spriteRenderer;
    private GameObject SpawnType;
    void Awake()
    {
        LoadAssets();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
    void Start()
    {
        if (SpawnType == null)
        {
            print("Spawn Type NULL");
        }
        //Update is called every frame
    }
    void Update()
    {

    }
    void LoadAssets()
    {
        string assetPath = "Assets/Prefabs/" + AssetName + ".prefab";
        SpawnType = GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject))) as GameObject;
        
    }
    void Spawn()
    {

        if (maxSpawn >= Spawn_count)
        {

            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius + Player.transform.position;
            randomPosition.z = 0;
            this.transform.position = randomPosition;

            if (SpawnType != null)
            {
                Instantiate(SpawnType, randomPosition,
                            SpawnType.transform.rotation);
                Spawn_count++;
            }
            else 
            {
                // NOTE(thadeu) this error is a mistery and unaceptble. Should fix it when I learn more.
                print("Spawn Type NULL");

                LoadAssets();

            }

        }
    }

}
