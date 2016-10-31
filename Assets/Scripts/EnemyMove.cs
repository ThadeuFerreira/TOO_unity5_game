using UnityEngine;
using System.Collections;

public class EnemyMove: MonoBehaviour {

	public bool follow=false;

	public Transform target;
	public float speed;
	private Rigidbody2D rb;
	private float Td;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (1,1)*speed;
		//rb = GetComponent<Rigidbody2D> ();
		//rb.velocity = transform.forward * speed;
	}

	void Update()
	{

		//		t += Time.deltaTime;
		//		Vector2 n1 = new Vector2 (0, 0);
		//		if(t>Time.deltaTime*30)
		//		{
		//n1 = Random.insideUnitCircle * speed;

		//t = 0;
		//}
		//transform.Translate (new Vector3(n1.x,n1.y,0)*speed*Time.deltaTime,Space.World);
		//rb.velocity = n1;

		transform.LookAt (target.position);
		transform.Rotate (new Vector3 (0, 90, 0), Space.Self);
		if (Vector3.Distance (transform.position, target.position) > 0f &&
			Vector3.Distance (transform.position, target.position) < 50f && Input.GetKey("p")
		) {
			follow = true;
			transform.Translate (new Vector3 (-Time.deltaTime, 0, 0)*speed*5);
		}else {
			//			Vector2 n1 = Random.insideUnitCircle * 5 + new Vector2 (1, 1) * speed;
			//			transform.Translate (n1.x * speed * Time.deltaTime, n1.y * speed * Time.deltaTime, 0);
			float vX = Random.value * 2 - 1;
			float vY = Random.value * 2 - 1;
			Td += Time.deltaTime;
			if (Td > Time.deltaTime * 10) {
				Td = 0;
				rb.velocity = rb.velocity + new Vector2 (vX,vY)*speed;
			}
			follow = false;
		}
	}
	// Update is called once per frame
	//	void FixedUpdate () {
	//		transform.LookAt(target.position);
	//		transform.Rotate (new Vector3 (0, -90, 0),Space.Self);
	//		if (Vector3.Distance (transform.position, target.position) > 1f && 
	//			Vector3.Distance (transform.position, target.position) < 3f)
	//		{
	//
	//			transform.Translate (new Vector3 (speed*Time.deltaTime, 0, 0));
	//		}
	//	}
}

