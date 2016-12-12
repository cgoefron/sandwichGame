using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Rewired;
using UnityEngine.SceneManagement;

public class roundController : MonoBehaviour {

	public float timeLeft;
	private bool isGameOver = false;
	private bool isScoreCalculated = false;
	public Text timerText;
	private bool paused = false;
	[HideInInspector]public int playerId = 0;
	[HideInInspector]public Player player;
	private AudioSource audio;
	private int winningPlayer;
	private string winningPlayerText = "";
	public GameObject restartText;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	public GameObject Plate1;
	public GameObject Plate2;
	public GameObject Plate3;
	public GameObject Plate4;

	private int player1score;
	private int player2score;
	private int player3score;
	private int player4score;

	public Camera mainCamera;

	public GameObject p1Camera;
	public GameObject p2Camera;
	public GameObject p3Camera;
	public GameObject p4Camera;

	private int[] playerScores;
	private int highScore;
	private int highScoreCount;
	private int playerCount = 0;
	private int tieCount = 0;
	private bool tieGame = false;

	public GameObject confetti1;
	public GameObject confetti2;
	public GameObject confetti3;
	public GameObject confetti4;

	public GameObject p1scoreUI;
	public GameObject p2scoreUI;
	public GameObject p3scoreUI;
	public GameObject p4scoreUI;




	void Awake(){
	
		player = ReInput.players.GetPlayer(playerId);	

	//Set all objects to false?
		player1.SetActive(false);
		player2.SetActive(false);
		player3.SetActive(false);
		player4.SetActive(false);

		playerScores = new int[4];
	}

	// Use this for initialization
	void Start () {
		mainCamera.enabled = true;
		p1scoreUI.SetActive (true);
		p2scoreUI.SetActive (true);
		p3scoreUI.SetActive (true);
		p4scoreUI.SetActive (true);

		audio = GetComponent<AudioSource>();


		if (playerEntryScript.player1entered) {
			Debug.Log ("player 1 is entered");
			player1.SetActive(true);
			playerCount += 1;
			//winningPlayerText = "Player 1"; //Handles solo player
		}

		if (playerEntryScript.player2entered) {
			Debug.Log ("player 2 is entered");

			player2.SetActive(true);
			playerCount += 1;
			//winningPlayerText = "Player 2"; //Handles solo player
		}

		if (playerEntryScript.player3entered) {
			Debug.Log ("player 3 is entered");

			player3.SetActive(true);
			playerCount += 1;
			//winningPlayerText = "Player 3"; //Handles solo player
		}

		if (playerEntryScript.player4entered) {
			Debug.Log ("player 4 is entered");

			player4.SetActive(true);
			playerCount += 1;
			//winningPlayerText = "Player 4"; //Handles solo player
		}
			
//		Plate1 = GameObject.Find ("Plate1");
//		Plate2 = GameObject.Find ("Plate2");
//		Plate3 = GameObject.Find ("Plate3");
//		Plate4 = GameObject.Find ("Plate4");


	}

	// Update is called once per frame
	void Update () {

//		mainCamera.enabled = false;
//		//p1Camera.enabled = true;
//		p1Camera.gameObject.SetActive(true);

		if (!isGameOver) {
			if (!paused) {
				timerText.text = "" + timeLeft.ToString ("f0");
			}

			Pause ();

			timeLeft -= Time.deltaTime;
			//print (timeLeft);

			RoundEndCheck ();
		} else {
			// yield and then load player wins function
			if (!isScoreCalculated) {
				PlayerWins ();
				//Display restart instructions
			}
			//Add check to detect back button to restart game
			if (Input.GetKey (KeyCode.R) || player.GetButton("Select")) {
				SceneManager.LoadScene("PlayerSelectScreen");			}
		}		
	}

	void Pause(){
		
		if(player.GetButtonDown("Start")){
			Debug.Log ("Player " + playerId + "hit start");
			if (!paused) {
				paused = true;
				Time.timeScale = 0;
				timerText.text = ("Paused");
				print ("Player has paused");
				//Stop music
				audio.Stop();
				//Display restart instructions
				restartText.gameObject.SetActive(true);


			} else {		
				paused = false;
				Time.timeScale = 1;
				//play music
				audio.Play();
				//Hide restart instructions
				restartText.gameObject.SetActive(false);
			}
		}
		if (paused) {
			if (Input.GetKey (KeyCode.R) || player.GetButton("Select")) {
				SceneManager.LoadScene("PlayerSelectScreen");			}
			//Add check to detect back button to restart game
		}
	}



	void RoundEndCheck(){
		if (timeLeft <= 1f) {
			Time.timeScale = 0;

			isGameOver = true;
			//play sound effect

			GetComponent<AudioSource>().Stop();
			//print ("DONE!");

			p1scoreUI.SetActive (false);
			p2scoreUI.SetActive (false);
			p3scoreUI.SetActive (false);
			p4scoreUI.SetActive (false);
		}
	}

	void PlayerWins(){
		//calculate winner

		timerText.text = ("Round Over!\n");

		player1score = Plate1.GetComponent<plateScript>().player1score;
		player2score = Plate2.GetComponent<plateScript>().player2score;
		player3score = Plate3.GetComponent<plateScript>().player3score;
		player4score = Plate4.GetComponent<plateScript>().player4score;

		//change camera to winning player
		playerScores [0] = player1score;
		playerScores [1] = player2score;
		playerScores [2] = player3score;
		playerScores [3] = player4score;

		/*
		if (playerEntryScript.player1entered) {
			Debug.Log ("Calc Player 1 Score");
			playerScores [0] = player1score;
		} else {
			playerScores [0] = 0;
		}

		if (playerEntryScript.player2entered) {
			Debug.Log ("Calc Player 2 Score");
			playerScores[1] = player2score;
		} else {
			playerScores [1] = 0;
		}

		if (playerEntryScript.player3entered) {
			Debug.Log ("Calc Player 3 Score");
			playerScores[2] = player3score;
		} else {
			playerScores [2] = 0;
		}

		if (playerEntryScript.player4entered) {
			Debug.Log ("Calc Player 4 Score");
			playerScores[3] = player4score;
		}else {
			playerScores [3] = 0;
		}
		*/

		//Calculate highest score and grab winning player #
	
		Debug.Log ("Player Scores... 1) " + playerScores [0] + " 2) " + playerScores [1] + " 3) " + playerScores [2] + " 4) " + playerScores [3]);

		//Add sort and check

		highScore = 0;

		for (int i = 0; i < playerScores.Length; i++)
		{
			int value = playerScores[i];

			Debug.Log ("Score loop player " + (i + 1));
			if (value > highScore)
			{
				Debug.Log ("Player " + (i + 1) + " score: " + value );
				highScore = value;
				winningPlayer = (i + 1);
			}
		}

		if (player1score == highScore && playerEntryScript.player1entered){
		 	//winningPlayer = 1;
			winningPlayerText = "Player 1";
			tieCount +=1;
			//Debug.Log (winningPlayer);
		  }

		if (player2score == highScore && playerEntryScript.player2entered){
			//winningPlayer = 2;
			if (tieCount > 0) {
				winningPlayerText += " and Player 2";
			} else {
				winningPlayerText = "Player 2";
			}
			tieCount +=1;
		}

		if (player3score == highScore && playerEntryScript.player3entered){
			//winningPlayer = 3;
			if (tieCount > 0) {
				winningPlayerText += " and Player 3";
			} else {
				winningPlayerText = "Player 3";
			}
			tieCount +=1;
		}

		if (player4score == highScore && playerEntryScript.player4entered){
			//winningPlayer = 4;
			if (tieCount > 0) {
				winningPlayerText = " and Player 4";
			} else {
				winningPlayerText = "Player 4";
			}
			tieCount +=1;
		}

		if (tieCount > 1){
			tieGame = true;
		}

		//turn off main camera, enable correct camera later
		mainCamera.enabled = false;

		//Score Display
		if (playerCount == 1) {
			//Solo player
			//set camera of only player
			int soloPlayerScore = 0;
			if (playerEntryScript.player1entered) {
				p1Camera.gameObject.SetActive(true);
				confetti1.gameObject.SetActive(true);
				soloPlayerScore = player1score;
			}
			if (playerEntryScript.player2entered) {
				p2Camera.gameObject.SetActive(true);
				confetti2.gameObject.SetActive(true);
				soloPlayerScore = player2score;
			}
			if (playerEntryScript.player3entered) {
				p3Camera.gameObject.SetActive(true);
				confetti3.gameObject.SetActive(true);
				soloPlayerScore = player3score;
			}
			if (playerEntryScript.player4entered) {
				p4Camera.gameObject.SetActive(true);				
				confetti4.gameObject.SetActive(true);
				soloPlayerScore = player4score;
			}

			if (soloPlayerScore == 0) {
				timerText.text += (winningPlayerText + " starved to death. Alone.");
			}
			else if (soloPlayerScore < highScore) {
				//Not working because non-player plate scores are not currently pulled in to scoring system
				timerText.text += (winningPlayerText + ", despite playing alone, did not have the best sandwich.");
			}else{
				timerText.text += (winningPlayerText + " ate a wholesome " + highScore + " calories. Alone.");
			}
		} else {
			if (tieGame) {
				if (tieCount == playerCount) {
					mainCamera.enabled = true; // main camera for tie
					if (highScore == 0) {
						timerText.text += ("It was a tie. All players managed to starve to death.");
					} else {
						timerText.text += ("All players tied with " + highScore + " calorie sandwiches.");
					}
				} 
			} else {
				//set camera of only player
				if (winningPlayer == 1) {
					p1Camera.gameObject.SetActive(true);
					confetti1.gameObject.SetActive(true);
				}
				if (winningPlayer == 2) {
					p2Camera.gameObject.SetActive(true);
					confetti2.gameObject.SetActive(true);
				}
				if (winningPlayer == 3) {
					p3Camera.gameObject.SetActive(true);
					confetti3.gameObject.SetActive(true);
				}
				if (winningPlayer == 4) {
					p4Camera.gameObject.SetActive(true);
					confetti4.gameObject.SetActive(true);
				}

				timerText.text += (winningPlayerText + " ate a wholesome winning " + highScore + " calorie sandwich.");
			}
		}
		player1.SetActive(false);
		player2.SetActive(false);
		player3.SetActive(false);
		player4.SetActive(false);
		isScoreCalculated = true;
	}
}
