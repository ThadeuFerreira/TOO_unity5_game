using UnityEngine;
using System.Collections;

public class FoodMove: MonoBehaviour {

	public bool follow=false;

	public Transform target;
	public float speed;
	private Rigidbody2D rb;
	private float Td;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		rb = GetComponent<Rigidbody2D> ();
		//rb.velocity = Random.insideUnitCircle*speed*100;
		rb.velocity = new Vector2 (Random.Range(-1f,1f)*10, Random.Range(-1f,1f)*10); 

		//rb = GetComponent<Rigidbody2D> ();
		//rb.velocity = transform.forward * speed;
	}

	void FixedUpdate()
	{
		if (Vector3.Distance (transform.position, target.position) > 0f &&
			Vector3.Distance (transform.position, target.position) < 50f && Input.GetKey("p")
		) {
			follow = true;
			transform.Translate (new Vector3 (-Time.deltaTime, 0, 0)*speed*2);
			transform.LookAt (target.position);
			transform.Rotate (new Vector3 (0, 90, 0), Space.Self);

		}else {
			//			Vector2 n1 = Random.insideUnitCircle * 5 + new Vector2 (1, 1) * speed;
			//			transform.Translate (n1.x * speed * Time.deltaTime, n1.y * speed * Time.deltaTime, 0);
			float vX = Random.value * 2 - 1;
			float vY = Random.value * 2 - 1;
			Td += Time.deltaTime;
			if (Td > Time.deltaTime * 10) {
				Td = 0;
				rb.velocity = rb.velocity + Random.insideUnitCircle*speed;
			}
			transform.rotation = Quaternion.Euler(0, 0, 0);
			follow = false;
		}
	}
}

