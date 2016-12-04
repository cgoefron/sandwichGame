using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerScript : MonoBehaviour {

	public float timeLeft = 60f;
	private bool isGameOver = false;
	public Text timerText;



	// Use this for initialization
	void Start () {

		timeLeft = 10f;

	}

	// Update is called once per frame
	void Update () {

		timerText.text = "" + timeLeft.ToString("f0");

		timeLeft -= Time.deltaTime;
		//print (timeLeft);
		if (timeLeft <= 1f) {
			RoundEnd ();
			timerText.text = ("Round Over!");
			print ("DONE!");

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
