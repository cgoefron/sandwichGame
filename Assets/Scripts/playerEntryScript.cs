using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Rewired;

public class playerEntryScript : MonoBehaviour {

	public Color playerColor;                           // Color assigned to player
	[HideInInspector] public int playerCount;  		    // Number of players entering game
	public int playerId;
	public Player player;

	//hands on screen
	public GameObject hand1;
	public GameObject hand2;
	public GameObject hand3;
	public GameObject hand4;


	//make public bools for each player - if player1 Action, then player1 bool true
	public static bool player1entered;
	public static bool player2entered;
	public static bool player3entered;
	public static bool player4entered;

	void Awake(){

		player = ReInput.players.GetPlayer(playerId);	

	}

	// Use this for initialization
	void Start () {
		player1entered = false;
		player2entered = false;
		player3entered = false;
		player4entered = false;
		playerCount = 0;
	}
	// Update is called once per frame
	void Update () {
		//if start button is pressed, ++ to playerCount, assign 


		PlayerEntry ();

		if (playerCount>0 && player.GetButtonDown("Start")){ //Map start button
			SceneManager.LoadScene("GameScene"); //Change to whatever game level is
		}
	}


	public void PlayerEntry(){
		if (player.GetButton("Action1")){

		if (playerId == 0) {
				//Debug.Log ("player 1 pressed A");
				player1entered = true;
				playerCount++;
		}

		if (playerId == 1) {
				player2entered = true;
				playerCount++;

		}

		if (playerId == 2) {
				player3entered = true;
				playerCount++;

		}

		if (playerId == 3) {
				player4entered = true;
				playerCount++;

		}

			Debug.Log ("Player count =" + playerCount);

		//if player enters game, make a hand move up. Disable once moved.
		//Need to make a persistant trigger into next scene for available players 
	}
}
}
