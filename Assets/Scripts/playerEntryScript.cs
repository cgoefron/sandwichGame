using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerEntryScript : MonoBehaviour {

	public Color playerColor;                           // Color assigned to player
	[HideInInspector] public int playerCount;  		    // Number of players entering game
	private GameObject [] playerID;  				    // Unique players
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;


	// Use this for initialization
	void Start () {
		playerCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//if start button is pressed, ++ to playerCount, assign 
		if (Input.GetButton("Action1")){
			playerCount++;
			//if player enters game, make a hand move up. Disable once moved.
			//Need to make a persistant trigger into next scene for available players 

		}

		if (Input.GetButtonDown("Start")){ //Map start button
			SceneManager.LoadScene("scene1"); //Change to whatever game level is
		}
	}
}
