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

	public GameObject sparkle1;
	public GameObject sparkle2;
	public GameObject sparkle3;
	public GameObject sparkle4;
																	
	// Use this for initialization
	void Start () {
		foodValue = 50;
		plateScore = 0;
		//diff food value for each ingredient

		bonus = 0;

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
						sparkle1.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
					} else {
						sparkle1.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
					}
				}

				if (gameObject.name == "Plate2") {
					player2score = plateScore;
					player2text.text = "" + plateScore;
					if (plateScore > 1000) {
						sparkle2.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
					} else {
						sparkle2.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
					}				}

				if (gameObject.name == "Plate3") {
					player3score = plateScore;
					player3text.text = "" + plateScore;
					if (plateScore > 1000) {
						sparkle3.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
					} else {
						sparkle3.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
					}				}

				if (gameObject.name == "Plate4") {
					player4score = plateScore;
					player4text.text = "" + plateScore;
					if (plateScore >= 1000) {
						sparkle4.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
					} else {
						sparkle4.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
					}				}

			}


		}
	}

	void OnTriggerExit(Collider other){

		//if (other.CompareTag ("Food") && other.isTrigger == true) {
		if (other.gameObject.layer == LayerMask.NameToLayer("ScoredFood")) {

			other.gameObject.layer = LayerMask.NameToLayer ("Food");
			plateScore = plateScore - foodValue;
			Debug.Log ("score = " + plateScore);


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
