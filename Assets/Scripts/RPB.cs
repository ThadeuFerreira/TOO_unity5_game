using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RPB : MonoBehaviour {

	public Transform LoadingBar;
	public Transform TextIndicator;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (currentAmount > 0) {
			currentAmount -= speed * Time.deltaTime;
			TextIndicator.GetComponent<Text> ().text = ((int)currentAmount).ToString () + "%";
		} else {
			TextIndicator.GetComponent<Text> ().text = "DEAD!";
		}
		LoadingBar.GetComponent<Image> ().fillAmount = currentAmount / 100;

	}
}
