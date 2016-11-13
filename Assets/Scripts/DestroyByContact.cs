using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject gameObj;

    private Respawn resp;
    void Start()
    {
        resp =   FindObjectOfType<Respawn>();

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