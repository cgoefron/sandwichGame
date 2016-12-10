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
	private int winningPlayer;

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

		int winningScore = Mathf.Max (player1score, player2score, player3score, player4score);

		//turn off main camera
		mainCamera.enabled = false;

		//change camera to winning player
		//grab winning player #

		if (player1score == winningScore){
		 	winningPlayer = 1;
			p1Camera.enabled = true;
			Debug.Log (winningPlayer);
		  }

		if (player2score == winningScore){
			winningPlayer = 2;
			p2Camera.enabled = true;
		}

		if (player3score == winningScore){
			winningPlayer = 3;
			p3Camera.enabled = true;
		}

		if (player4score == winningScore){
			winningPlayer = 4;
			p4Camera.enabled = true;
		}



		//change text: Player # wins!
		timerText.text = ("Player" + winningPlayer + "wins!");
	
	}

}
