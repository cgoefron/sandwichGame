using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Rewired;

public class roundController : MonoBehaviour {

	public float timeLeft;
	private bool isGameOver = false;
	public Text timerText;
	private bool paused = false;
	public int playerId = 0;
	private Player player;
	private AudioSource audio;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	void Awake(){
	
		player = ReInput.players.GetPlayer(playerId);	

	//Set all objects to false?
		player1.SetActive(false);
		player2.SetActive(false);
		player3.SetActive(false);
		player4.SetActive(false);
	}

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource>();


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
		}

	}

	void Pause(){
		if(player.GetButtonDown("Start")){
			if (!paused) {
				paused = true;
				Time.timeScale = 0;
				timerText.text = ("Paused");
				print ("Player has paused");
				//Stop music
				audio.Stop();
			} else {		
				paused = false;
				Time.timeScale = 1;
				//play music
				audio.Play();
				}


		}
	}



	void RoundEnd(){

		Time.timeScale = 0;

		isGameOver = true;
		//play sound effect
		GetComponent<AudioSource>().Stop();
		print ("DONE!");


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
