using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerEntryScript : MonoBehaviour {

	public Color playerColor;                           // Color assigned to player
	[HideInInspector] public int playerCount;  		    // Number of players entering game
	private GameObject [] playerID;  				// Unique players

	// Use this for initialization
	void Start () {
		playerCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//if start button is pressed, ++ to playerCount, assign 
		if (Input.GetButton("A")){
			playerCount++;
		}

		if (Input.GetButtonDown("Start")){
			SceneManager.LoadScene("scene1"); //Change to whatever game level is
		}
	}
}
