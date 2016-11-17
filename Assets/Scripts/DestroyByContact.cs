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
         if (other.tag == "Player_Colider")
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
            resp.Spawn_count--;
            
        }
        
    }
}