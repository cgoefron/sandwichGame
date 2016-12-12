using UnityEngine;
using System.Collections;
using Rewired;

public class pauseScript : MonoBehaviour {

	public int playerId = 0;
	public Player player;
	private bool paused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Pause ();
	}

	void Pause(){

		if(player.GetButtonDown("Start")){
			Debug.Log ("Player " + playerId + "hit start");
			if (!paused) {
				paused = true;
				Time.timeScale = 0;
				//timerText.text = ("Paused");
				print ("Player has paused");
				//Stop music
				//GetComponent<AudioSource>().Stop();
				//Display restart instructions
				//restartText.gameObject.SetActive(true);


			} else {		
				paused = false;
				Time.timeScale = 1;
				//play music
				GetComponent<AudioSource>().Play();
				//Hide restart instructions
				//restartText.gameObject.SetActive(false);
			}
		}
		if (paused) {
			if (Input.GetKey (KeyCode.R) || player.GetButton("Select")) {
				//SceneManager.LoadScene("PlayerSelectScreen");			}
			//Add check to detect back button to restart game
		}
	}
}
}