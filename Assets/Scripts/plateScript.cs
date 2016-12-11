using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class plateScript : MonoBehaviour {

	public int plateScore;
	public int foodValue;
	//public LayerMask foodMask = -1;

	public int player1score;
	public int player2score;
	public int player3score;
	public int player4score;

	public Text player1text;
	public Text player2text;
	public Text player3text;
	public Text player4text;
																	
	// Use this for initialization
	void Start () {
		foodValue = 50;
		plateScore = 0;

		//diff food value for each ingredient
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
				
				plateScore = foodValue + plateScore;
				Debug.Log ("score = " + plateScore);
				//hit.transform.GetComponent<BoxCollider> ().enabled = false;
				hit.collider.gameObject.layer = LayerMask.NameToLayer ("ScoredFood");


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
