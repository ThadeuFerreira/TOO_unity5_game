using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	public float maxHealth = 1;
	public float curHealth;
	private GameObject healthBar;

	void Start () {
		curHealth = maxHealth;
		healthBar = transform.Find("Canvas/Indicator").gameObject;
	}

	void Update () {
		SetHealthBar();
		Die();
	}

	void SetHealthBar () {
		healthBar.transform.localScale = new Vector3(
			curHealth / maxHealth,
			healthBar.transform.localScale.y,
			healthBar.transform.localScale.z
		);
	}

	void Die () {
		if (curHealth <= 0) {
			gameObject.SetActive(false);
		}
	}
}