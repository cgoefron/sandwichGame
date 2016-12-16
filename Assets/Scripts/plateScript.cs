using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class plateScript : MonoBehaviour {

	public int plateScore;
	public int foodValue;
	public int bonus;
	//public LayerMask foodMask = -1;

	public int player1score;
	public int player2score;
	public int player3score;
	public int player4score;

	public Text player1text;
	public Text player2text;
	public Text player3text;
	public Text player4text;

	public GameObject sparklePrefab1;
	public GameObject sparklePrefab2;
	public GameObject sparklePrefab3;
	public GameObject sparklePrefab4;

//	ParticleSystem sparkle1 = sparklePrefab1.GetComponent<ParticleSystem>();
//	ParticleSystem sparkle2 = sparklePrefab2.GetComponent<ParticleSystem>();
//	ParticleSystem sparkle3 = sparklePrefab3.GetComponent<ParticleSystem>();
//	ParticleSystem sparkle4 = sparklePrefab4.GetComponent<ParticleSystem>();


																		
	// Use this for initialization
	void Start () {
		foodValue = 50;
		plateScore = 0;
		//diff food value for each ingredient

		bonus = 0;

		sparklePrefab1.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		sparklePrefab2.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		sparklePrefab3.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		sparklePrefab4.gameObject.GetComponent<ParticleSystem>().enableEmission = false;

	}
	
	// Update is called once per frame
	void Update () {



			RaycastHit[] hits;
		hits = Physics.RaycastAll(transform.position, transform.up, 100.0F, LayerMask.GetMask("Food"), QueryTriggerInteraction.Ignore);


			for (int i = 0; i < hits.Length; i++) {
				RaycastHit hit = hits[i];
				//Renderer rend = hit.transform.GetComponent<Renderer>();

			//Debug.Log ("Hit: " + hit.collider.gameObject.name);

			//if (hit.collider.tag == "Food") { //How do I guarantee this is only added up once?
			if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Food")){	

				//check its bonus
				if (hit.collider.gameObject.GetComponent<foodBonus>()!= null) {
					Debug.Log ("has bonus");
					bonus = hit.collider.gameObject.GetComponent<foodBonus> ().bonus;
				}

				plateScore = foodValue + plateScore + bonus;
				Debug.Log ("score = " + plateScore);
				//hit.transform.GetComponent<BoxCollider> ().enabled = false;
				hit.collider.gameObject.layer = LayerMask.NameToLayer ("ScoredFood");

				//reset bonus
				bonus = 0;

				if (gameObject.name == "Plate1") {
					player1score = plateScore;
					player1text.text = "" + plateScore;
					if (plateScore > 1000) {
						sparklePrefab1.gameObject.GetComponent<ParticleSystem>().enableEmission = true;

					} else {
						sparklePrefab1.gameObject.GetComponent<ParticleSystem>().enableEmission = false;

					}
				}

				if (gameObject.name == "Plate2") {
					player2score = plateScore;
					player2text.text = "" + plateScore;
					if (plateScore > 1000) {
						sparklePrefab2.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
	
					} else {
						sparklePrefab2.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
					}				}

				if (gameObject.name == "Plate3") {
					player3score = plateScore;
					player3text.text = "" + plateScore;
					if (plateScore > 1000) {
						sparklePrefab3.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
					} else {
						sparklePrefab3.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
					}				}

				if (gameObject.name == "Plate4") {
					player4score = plateScore;
					player4text.text = "" + plateScore;
					if (plateScore >= 1000) {
						sparklePrefab4.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
					} else {
						sparklePrefab4.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
					}				}

			}


		}
	}

	void OnTriggerExit(Collider other){

		//if (other.CompareTag ("Food") && other.isTrigger == true) {
		if (other.gameObject.layer == LayerMask.NameToLayer("ScoredFood")) {

			//check its bonus
			if (other.gameObject.GetComponent<foodBonus>()!= null) {
				Debug.Log ("has bonus");
				bonus = other.gameObject.GetComponent<foodBonus> ().bonus;
			}

			other.gameObject.layer = LayerMask.NameToLayer ("Food");
			plateScore = plateScore - foodValue - bonus;
			Debug.Log ("score = " + plateScore);

			bonus = 0;


			if (gameObject.name == "Plate1") {
				player1score = plateScore;
				player1text.text = "" + plateScore;
			}

			if (gameObject.name == "Plate2") {
				player2score = plateScore;
				player2text.text = "" + plateScore;
			}

			if (gameObject.name == "Plate3") {
				player3score = plateScore;
				player3text.text = "" + plateScore;
			}

			if (gameObject.name == "Plate4") {
				player4score = plateScore;
				player4text.text = "" + plateScore;
			}

		}
	}
}
