using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerScript : MonoBehaviour {

	public float timeLeft;
	private bool isGameOver = false;
	public Text timerText;
	private bool paused = false;


	// Use this for initialization
	void Start () {

		//timeLeft = 60f;

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
