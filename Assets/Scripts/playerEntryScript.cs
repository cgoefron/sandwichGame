using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Rewired;

public class playerEntryScript : MonoBehaviour {

	public Color playerColor;                           // Color assigned to player
	[HideInInspector] public int playerCount;  		    // Number of players entering game
	public Player player1;
	public Player player2;
	public Player player3;
	public Player player4;

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

		player1 = ReInput.players.GetPlayer(0);	
		player2 = ReInput.players.GetPlayer(1);	
		player3 = ReInput.players.GetPlayer(2);	
		player4 = ReInput.players.GetPlayer(3);	

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

		if (playerCount>0 && (player1.GetButtonDown("Start") || player2.GetButtonDown("Start") || player3.GetButtonDown("Start") || player4.GetButtonDown("Start"))){ //Map start button
			SceneManager.LoadScene("GameScene"); //Change to whatever game level is
		}
	}


	public void PlayerEntry(){
		if (player1.GetButtonDown("Action1") && player1entered == false){
			Debug.Log ("player 1 entered");
			player1entered = true;
			playerCount++;
		}

		if (player2.GetButtonDown("Action1") && player2entered == false) {
				player2entered = true;
				playerCount++;
		}

		if (player3.GetButtonDown("Action1") && player3entered == false) {
				player3entered = true;
				playerCount++;

		}

		if (player4.GetButtonDown("Action1") && player4entered == true) {
				player4entered = true;
				playerCount++;

		}

			Debug.Log ("Player count =" + playerCount);

		//if player enters game, make a hand move up. Disable once moved.
		//Need to make a persistant trigger into next scene for available players 
	}
}
