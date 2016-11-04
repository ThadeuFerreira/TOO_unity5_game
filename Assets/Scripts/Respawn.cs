using UnityEngine;
using System.Collections;
using UnityEditor;

public class Respawn : MonoBehaviour {
	public GameObject Player;
    public string AssetName;
	public Transform[] spawnPoints;
	public float spawnTime = 3f;
	public int maxSpawn = 3;
	public int count=0;

    private SpriteRenderer spriteRenderer;
    private GameObject SpawnType;
    void Awake()
    {
        string assetPath = "Assets/Prefabs/" + AssetName + ".prefab";
        SpawnType = GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject))) as GameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	void Start()
    {

	}
	//Update is called every frame
	void Update () 
	{
		
	}

	void Spawn(){
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Vector3 posicaoAleatoria = Random.insideUnitSphere*100;
        posicaoAleatoria.z = 0;
        this.transform.position = posicaoAleatoria;
        if (maxSpawn >= count)
        {
            if (SpawnType != null)
            {
                Instantiate(SpawnType,
                new Vector3(spawnPoints[spawnPointIndex].position.x + posicaoAleatoria.x,
                spawnPoints[spawnPointIndex].position.y + posicaoAleatoria.y, 0),
                spawnPoints[spawnPointIndex].rotation);
                count++;
            }

        }
    }

}
