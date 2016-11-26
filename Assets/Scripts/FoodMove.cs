using UnityEngine;
using System.Collections;

public class FoodMove: MonoBehaviour {

	public bool follow=false;

	public Transform target;
	public float speed;
    public float driftSpeed;
    private Rigidbody rb;
	private float Td;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		rb = GetComponent<Rigidbody> ();
        driftSpeed += speed / 2;

		rb.velocity = new Vector2 (Random.Range(-1f,1f)*10, Random.Range(-1f,1f)*10) *driftSpeed; 


	}

	void FixedUpdate()
	{
		if (Vector3.Distance (transform.position, target.position) > 0f &&
			Vector3.Distance (transform.position, target.position) < 50f && Input.GetKey("p")
		)
        {
			follow = true;
			transform.Translate (new Vector3 (-Time.deltaTime, 0, 0)*speed*2);
			transform.LookAt (target.position);
			transform.Rotate (new Vector3 (0, 90, 0), Space.Self);

		}else
        {

			Td += Time.deltaTime;
			if (Td > Time.deltaTime * 10) {
				Td = 0;
				rb.velocity = rb.velocity + new Vector3(Random.Range(-1f,1f),Random.Range(-1f, 1f),0)* driftSpeed;
               
			}
			transform.rotation = Quaternion.Euler(0, 0, 0);
			follow = false;
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Player_Collider" && other.tag != "Food")
        {
            print("Outra colisão " + other.tag);
           // rb.velocity = -rb.velocity*0.9f;
        }

    }
}

