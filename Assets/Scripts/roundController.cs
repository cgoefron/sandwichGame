using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class roundController : MonoBehaviour {

	public float timeLeft;
	private bool isGameOver = false;
	public Text timerText;
	private bool paused = false;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	void Awake(){
		
	//Set all objects to false?
		player1.SetActive(false);
		player2.SetActive(false);
		player3.SetActive(false);
		player4.SetActive(false);
	}

	// Use this for initialization
	void Start () {

		if (playerEntryScript.player1entered) {
			player1.SetActive(true);
		}

		if (playerEntryScript.player2entered) {
			player2.SetActive(true);
		}

		if (playerEntryScript.player3entered) {
			player3.SetActive(true);
		}

		if (playerEntryScript.player4entered) {
			player4.SetActive(true);
		}

		//timeLeft = 60f;
		//Turn on player objects
	}

	// Update is called once per frame
	void Update () {

		if (!paused) {
			timerText.text = "" + timeLeft.ToString ("f0");
		}

		Pause ();

		timeLeft -= Time.deltaTime;
		//print (timeLeft);
		if (timeLeft <= 1f) {
			RoundEnd ();
			timerText.text = ("Round Over!");
			//"Player _ Wins!"
			print ("DONE!");

		}

	}

	void Pause(){
		if(Input.GetKeyDown(KeyCode.P)){
			if (!paused) {
				paused = true;
				Time.timeScale = 0;
				timerText.text = ("Paused");
				print ("Player has paused");
			} else {		
				paused = false;
				Time.timeScale = 1;
				}


		}
	}



	void RoundEnd(){

		Time.timeScale = 0;

		isGameOver = true;
		//play sound effect
		GetComponent<AudioSource>().Stop();

		//Add individual player-winner message
//		if (houseHealth > realtorWinAmount){
//			scoreText.text = "Round Over! Realtors Win!";
//		}
//
//		if (houseHealth <= realtorWinAmount){
//			scoreText.text = "Round Over! Vampire Wins!";
//		}
	}

}
