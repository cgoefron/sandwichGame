using UnityEngine;
using System.Collections;

public class handEntryScript : MonoBehaviour {
	
	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	//private GameObject EntryScreenController;

	void Start() {
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
		//EntryScreenController = GameObject.Find ("EntryScreenController");
	}

	void Update() {

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;

		if (gameObject.name == "sandwichHand1") {
			if (playerEntryScript.player1entered){
				transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
			}
		}

		if (gameObject.name == "sandwichHand2") {
			if (playerEntryScript.player2entered){
				transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
			}
		}

		if (gameObject.name == "sandwichHand3") {
			if (playerEntryScript.player3entered){
				transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
			}
		}

		if (gameObject.name == "sandwichHand4") {
			if (playerEntryScript.player4entered){
				transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
			}
		}


	}
}
