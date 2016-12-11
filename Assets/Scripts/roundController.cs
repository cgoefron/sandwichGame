using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Rewired;

public class roundController : MonoBehaviour {

	public float timeLeft;
	private bool isGameOver = false;
	public Text timerText;
	private bool paused = false;
	private int playerId = 0;
	private Player player;
	private AudioSource audio;
	private int winningPlayer;
	private string winningPlayerText = "";

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	private GameObject Plate1;
	private GameObject Plate2;
	private GameObject Plate3;
	private GameObject Plate4;

	private int player1score;
	private int player2score;
	private int player3score;
	private int player4score;

	public Camera mainCamera;
	public Camera p1Camera;
	public Camera p2Camera;
	public Camera p3Camera;
	public Camera p4Camera;

	private int[] playerScores;
	private int highScore;
	private int highScoreCount;
	private int playerCount = 0;
	private int winningScore = 0;
	private int tieCount = 0;
	private bool tieGame = false;


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
			playerCount += 1;
			winningPlayerText = "Player 1"; //Handles solo player
		}

		if (playerEntryScript.player2entered) {
			player2.SetActive(true);
			playerCount += 1;
			winningPlayerText = "Player 2"; //Handles solo player
		}

		if (playerEntryScript.player3entered) {
			player3.SetActive(true);
			playerCount += 1;
			winningPlayerText = "Player 3"; //Handles solo player
		}

		if (playerEntryScript.player4entered) {
			player4.SetActive(true);
			playerCount += 1;
			winningPlayerText = "Player 4"; //Handles solo player
		}

		Plate1 = GameObject.Find ("Plate1");
		Plate2 = GameObject.Find ("Plate2");
		Plate3 = GameObject.Find ("Plate3");
		Plate4 = GameObject.Find ("Plate4");

		player1score = Plate1.GetComponent<plateScript>().player1score;
		player2score = Plate1.GetComponent<plateScript>().player2score;
		player3score = Plate1.GetComponent<plateScript>().player3score;
		player4score = Plate1.GetComponent<plateScript>().player4score;

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

			// yield and then load player wins function
			PlayerWins();
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
		//print ("DONE!");

		player1.SetActive(false);
		player2.SetActive(false);
		player3.SetActive(false);
		player4.SetActive(false);


	}

	void PlayerWins(){
		//calculate winner
		//Handle tie score
		//Only calculate active players
		//Handle 0 score

		//int winningScore = Mathf.Max (player1score, player2score, player3score, player4score);

		//highScore
		//highScoreCount

		//turn off main camera, enable correct camera later
		mainCamera.enabled = false;

		//change camera to winning player
		//grab winning player #

		if (player1.activeInHierarchy) {
			Debug.Log ("Calc Player 1 Score");
			playerScores [1] = player1score;
		} else {
			playerScores [1] = 0;
		}

		if (player2.activeInHierarchy) {
			Debug.Log ("Calc Player 2 Score");
			playerScores[2] = player2score;
		} else {
			playerScores [2] = 0;
		}

		if (player3.activeInHierarchy) {
			Debug.Log ("Calc Player 3 Score");
			playerScores[3] = player3score;
		} else {
			playerScores [3] = 0;
		}

		if (player4.activeInHierarchy) {
			Debug.Log ("Calc Player 4 Score");
			playerScores[4] = player4score;
		}else {
			playerScores [4] = 0;
		}

		//Calculate highest score
	
		Debug.Log ("Player Scores... 1) " + playerScores [1] + " 2) " + playerScores [2] + " 3) " + playerScores [3] + " 4) " + playerScores [4]);

		//Add sort and check

		winningScore = 0;

		for (int i = 1; i <= playerScores.Length; i++)
		{
			int value = playerScores[i];
			Debug.Log ("Score loop player " + i);
			if (value > winningScore)
			{
				Debug.Log ("Player " + i + " score: " + value );
				winningScore = value;
				winningPlayer = i;
			}
		}

		if (player1score == winningScore){
		 	//winningPlayer = 1;
			winningPlayerText = "Player 1";
			tieCount +=1;
			//p1Camera.enabled = true;
			//Debug.Log (winningPlayer);
		  }

		if (player2score == winningScore){
			//winningPlayer = 2;
			if (tieCount > 0) {
				winningPlayerText += " and Player 2";
			} else {
				winningPlayerText = "Player 2";
			}
			tieCount +=1;
			//p2Camera.enabled = true;
		}

		if (player3score == winningScore){
			//winningPlayer = 3;
			if (tieCount > 0) {
				winningPlayerText += " and Player 3";
			} else {
				winningPlayerText = "Player 3";
			}
			tieCount +=1;
			//p3Camera.enabled = true;
		}

		if (player4score == winningScore){
			//winningPlayer = 4;
			if (tieCount > 0) {
				winningPlayerText = " and Player 4";
			} else {
				winningPlayerText = "Player 4";
			}
			tieCount +=1;
			//p4Camera.enabled = true;
		}

		if (tieCount > 1){
			tieGame = true;
		}

		//Score Display
		if (playerCount == 1) {
			//set camera of only player
			if (player1.activeSelf) {
				p1Camera.enabled = true;
			}
			if (player2.activeSelf) {
				p2Camera.enabled = true;
			}
			if (player3.activeSelf) {
				p3Camera.enabled = true;
			}
			if (player4.activeSelf) {
				p4Camera.enabled = true;
			}

			if (highScore == 0) {
				//solo player, 0 points
				timerText.text = (winningPlayerText + " starved to death. Alone.");
			} else {
				//solo player, score
				timerText.text = (winningPlayerText + " ate a wholesome " + winningScore + "calories. Alone.");
			}
		} else {
			if (tieGame) {
				if (tieCount == playerCount) {
					mainCamera.enabled = true; // main camera for tie
					if (highScore == 0) {
						timerText.text = ("It was a tie. All players managed to starve to death.");
					} else {
						timerText.text = ("All players tied with" + winningScore + "calorie sandwiches.");
					}
				} 
			} else {
				//set camera of only player
				if (winningPlayer == 1) {
					p1Camera.enabled = true;
				}
				if (winningPlayer == 2) {
					p2Camera.enabled = true;
				}
				if (winningPlayer == 3) {
					p3Camera.enabled = true;
				}
				if (winningPlayer == 4) {
					p4Camera.enabled = true;
				}

				timerText.text = (winningPlayerText + " ate a wholesome winning" + winningScore + " calorie sandwich.");
			}
		}
	
	}

}
