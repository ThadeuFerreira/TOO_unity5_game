using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject gameObj;

    private FoodRespawn resp;
    void Start()
    {
        resp =   FindObjectOfType<FoodRespawn>();

    }
    void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player_Colider" || other.tag == "Player")
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
            resp.Spawn_count--;
            
        }
        else if(other.tag == "Cube")
        {
            print("Outra colisão " + other.tag);
        }
        
    }
}