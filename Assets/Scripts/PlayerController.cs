using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//public Text winText;
	public int HP;
	public int Energy;
	public int MaxEnergy;
	public int spdEnergy;
	public bool CoolDown;

	public GameObject pontuacao;
	public GameObject PLight;

	public EnergyBar energyBar;

	private int count;
	private int score;

	public float speed;
	private float movex;
	private float movey;

	private Color oriColor;

	private SpriteRenderer sprRen;
	private Rigidbody2D rg2d;

	private Sprite waterSpr;

	// Use this for initialization
	void Start () {
		sprRen = GetComponent<SpriteRenderer> ();
		rg2d = GetComponent<Rigidbody2D> ();

		oriColor = sprRen.color;

		count = 0;
		CoolDown = false;

		Energy = MaxEnergy;
		energyBar.currentAmount = MaxEnergy;
		energyBar.maxAmount = MaxEnergy;

		//winText.text = "";

	}
	
	// Update is called once per frame
	void Update () {

		// Movement Control
		if (Input.GetKey (KeyCode.W))
			rg2d.velocity = (transform.up * speed);
		else if (Input.GetKey (KeyCode.S))
			rg2d.velocity = (-transform.up * speed);
        if (Input.GetKey(KeyCode.A))
            rg2d.velocity = (-transform.right * speed);
        else if (Input.GetKey(KeyCode.D))
            rg2d.velocity = (transform.right * speed);

        // Glow
        if (Input.GetKey ("p") && Energy > 0 && CoolDown == false) {
			sprRen.color = Color.white;
			sprRen.sortingOrder = 100;
			PLight.GetComponent<Light> ().enabled = true;
			Energy = Energy - spdEnergy;

		} else {
			sprRen.color = oriColor;
			sprRen.sortingOrder = 0;
			PLight.GetComponent<Light> ().enabled = false;
				
			if (Energy < MaxEnergy)
				Energy = Energy + spdEnergy / 2;
		}

		if (Energy == 0){
			CoolDown = true;
			Energy++;
		}
		if (CoolDown == true) {
			if (Energy > MaxEnergy * 0.2) {
				CoolDown = false;
				Energy = Energy + spdEnergy / 3;
			}
		}

		rg2d.angularVelocity = 0;

		energyBar.currentAmount = Energy;

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Food")) {
			Destroy (other.gameObject);

			count = count + 1;

			SetCountText ();
		}
	}

	void FixedUpdate () {
		
	}

	void SetCountText () {
		score = count * 50;
		pontuacao.GetComponent<Text> ().text = "SCORE: " + score.ToString ();
	}
}
