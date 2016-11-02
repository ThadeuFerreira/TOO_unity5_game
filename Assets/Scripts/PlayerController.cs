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

	public float acceleration;
    public Vector2 player_speed2D;
	private float movex;
	private float movey;

	private Color oriColor;

	private SpriteRenderer sprRen;
	private Rigidbody Rb;

	private Sprite waterSpr;

	// Use this for initialization
	void Start () {
		
		Rb= GetComponent<Rigidbody> ();



		count = 0;
		CoolDown = false;

		Energy = MaxEnergy;
		energyBar.currentAmount = MaxEnergy;
		energyBar.maxAmount = MaxEnergy;

		//winText.text = "";

	}
	
	// Update is called once per frame
	void Update () {



        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Rb.AddForce(new Vector3(moveH, moveV, 0)*acceleration);
       
        player_speed2D = Rb.velocity;
        // Glow
        if (Input.GetKey ("p") && Energy > 0 && CoolDown == false) {

			PLight.GetComponent<Light> ().enabled = true;
			Energy = Energy - spdEnergy;

		} else {

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



        BackgroudScroller.current.Go( player_speed2D);
	}

	void SetCountText () {
		score = count * 50;
		pontuacao.GetComponent<Text> ().text = "SCORE: " + score.ToString ();
	}
}
