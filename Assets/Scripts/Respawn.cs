using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	public GameObject Player;
	public GameObject Huntable;
	public Transform[] spawnPoints;
	public float spawnTime = 3f;
	private SpriteRenderer spriteRenderer;
	public int maxSpawn = 3;
	public int count=0;

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		InvokeRepeating ("Spawn",spawnTime,spawnTime);
	}
	//Update is called every frame
	void Update () 
	{
		
	}

	void Spawn(){
		int spawnPointIndex = Random.Range(0,spawnPoints.Length);
		int posicaoAleatoriaX = Random.Range(-1500,1500);
		int posicaoAleatoriaY = Random.Range(-1500,1500);
		this.transform.position = new Vector3(posicaoAleatoriaX, posicaoAleatoriaY, 0);
		if(maxSpawn>=count){
			//spawnPoints [spawnPointIndex].position.x = posicaoAleatoriaX;
			//spawnPoints [spawnPointIndex].position.y = posicaoAleatoriaY;
			Instantiate (Huntable,new Vector3(spawnPoints [spawnPointIndex].position.x + posicaoAleatoriaX,spawnPoints [spawnPointIndex].position.y + posicaoAleatoriaY,0),spawnPoints[spawnPointIndex].rotation);
			count++;
		}
	}

}
