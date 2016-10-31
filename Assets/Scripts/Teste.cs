using UnityEngine;
using System.Collections;

public class Teste : MonoBehaviour {
	public Quaternion fixedRotation;
	public Vector3 fixedPosition;


	void Awake(){
		fixedRotation = transform.rotation;
	}

	void Update(){
		fixedPosition = transform.position;
	}

	void LateUpdate(){
		transform.rotation = fixedRotation;
		transform.position = fixedPosition;
	}
}
