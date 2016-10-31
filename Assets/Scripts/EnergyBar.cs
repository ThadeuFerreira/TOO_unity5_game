using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnergyBar : MonoBehaviour {

	public Transform LoadingBar;
	public Transform TextIndicator;

	public float currentAmount;
	public float maxAmount;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (currentAmount > 0) {
			TextIndicator.GetComponent<Text> ().text = currentAmount.ToString ();
		}

		LoadingBar.GetComponent<Image> ().fillAmount = currentAmount / maxAmount;

	}

}
