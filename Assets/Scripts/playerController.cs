using UnityEngine;
using System.Collections;
using Rewired;

public class playerController : MonoBehaviour {

	[HideInInspector]public int playerId = 0;
	public Player player;
	public Rigidbody rb;
	public float moveSpeed;
	public bool isGrabbing = false;
	public bool nearFood = false;
	private GameObject theFood;
	public Transform handCollider;
	public float thrust;
	public Transform table;
	public float yDefault;
	private RigidbodyConstraints previousConstraints;
	private float previousX, previousZ;
	private bool canSlam;
	[HideInInspector]public bool isSlamming = false;
	//private float speed;

	public AudioClip pickupFood;
	public AudioClip dropFoodTable;
	public AudioClip slam;
	//public AudioClip dropFoodFloor;
	public AudioClip slamTable;
	private AudioSource audio;

	public GameObject defaultHand;
	public GameObject grabHand;
	public Transform cameraTransform; 

	// Use this for initialization

	void Awake(){

		player = ReInput.players.GetPlayer(playerId);	

	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
		audio = GetComponent<AudioSource>();
		rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
		previousConstraints = rb.constraints;
		previousX = transform.position.x;
		previousZ = transform.position.z;
		yDefault = transform.position.y;
		isGrabbing = false;
		canSlam = false;
		//speed = 5f;
	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector2 move = new Vector2 (player.GetAxis ("Horizontal"), player.GetAxis ("Vertical")) * moveSpeed;
		//Vector3 movement = new Vector3 (player.GetAxis ("Horizontal"), rb.velocity.y, player.GetAxis ("Vertical")) * moveSpeed;

		//Vector3 movement = new Vector3 (move.x * cameraTransform.transform.right, rb.velocity.y, move.y * cameraTransform.transform.up);
		//Vector3 movement = new Vector3 (move.x, rb.velocity.y, move.y);
		Vector3 movement = new Vector3 (move.x, move.y, rb.velocity.y);

		movement = Camera.main.transform.TransformDirection(movement);

		rb.velocity = movement;

		Slam ();

		if (theFood) {
			theFood.transform.position = handCollider.transform.position;

		}

		if (player.GetButtonUp ("Action1") && theFood) {


			//print ("button pressed and dropped food");
			audio.PlayOneShot (dropFoodTable);

			//food is let go and collisions are turned on again
			theFood.GetComponent<Rigidbody> ().isKinematic = false;
			theFood.GetComponent<Rigidbody> ().detectCollisions = true;
			theFood = null;

			isGrabbing = false;

			canSlam = true; //After dropping food, player can slam again

			//turn off grabbingHand and turn on regular hand
			grabHand.SetActive(false);
			defaultHand.SetActive (true);

		}
	}
		

	void OnTriggerStay(Collider other){

		if (other.CompareTag("Food")) {
			nearFood = true;

			if (player.GetButton ("Action1") && !theFood) {

				//Debug.Log ("player id = " + player.id);


				theFood = other.gameObject;
				theFood.GetComponent<Rigidbody> ().isKinematic = true;
				theFood.GetComponent<Rigidbody> ().detectCollisions = false;
				audio.PlayOneShot (pickupFood);
				//food attaches to hand

				//disable colliders or hand while moving food?

				isGrabbing = true;

				//Player cannot slam while holding food
				canSlam = false;

				//Unless it's a ketchup or mustard packet
				if (other.gameObject.name == "ketchup" || other.gameObject.name == "mustard") {
					canSlam = true;
				}

				//turn off hand and turn on grabbingHand
				defaultHand.SetActive (false);
				grabHand.SetActive(true);


			}


		}

	}

	void OnTriggerExit(Collider other){

		if (other.tag == "Food") {
			nearFood = false;

		}
	}

	void Slam(){

		if (canSlam){

			if (player.GetButtonDown ("Action2") && !isSlamming) { //add check for Y position before slamming

				isSlamming = true;
				audio.PlayOneShot (slam);

//				Debug.Log ("slam now " + isSlamming);

//				TODO:
//				instantiate particle poof
//				camera shake
//
//				Debug.Log("player starting position =" + transform.position.y);
//				// unfreeze y position, add force toward table
//				rb.constraints &= ~RigidbodyConstraints.FreezeRotationY;
//
//				Debug.Log (rb.constraints);
//				previousX = transform.position.x;
//				previousZ = transform.position.z;
//				//rb.AddForce (0, (table.transform.position.y - transform.position.y) * thrust, 0);
//				rb.AddForce((transform.up * -1) * thrust); 

				//transform.position = new Vector3(previousX, table.transform.position.y, previousZ);
//				Debug.Log ("table.transform.position.y: " + table.transform.position.y);
//				Debug.Log ("handCollider.transform.position.y: " + handCollider.transform.position.y);

				//move hand to original y position (yDefault), re-freeze y transform - MOVING TO ONCOLLISIONENTER
				//transform.position = new Vector3(transform.position.x, yDefault, transform.position.z);
				//rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
//				isSlamming = false;

				//CheckSlam ();

			}


		}
		//Debug.Log ("Current Velocity: " + rb.velocity.magnitude);
		//Debug.Log ("player position =: " + transform.position.y);
		//CheckSlam (); //Decide if hand has hit table, increase velocity if not
	}

//
//	void CheckSlam(){
//		
//		if (isSlamming) {
//			transform.position = new Vector3(previousX, transform.position.y, previousZ);
//			rb.velocity = rb.velocity * 2;
//			//rb.AddForce (0, (table.transform.position.y - transform.position.y) * thrust, 0);
//			//rb.AddForce((transform.up * -1) * thrust); 
//		}
//
//		//if (handCollider.transform.position.y < table.transform.position.y ) {
//			//if (handCollider.transform.position.y < 0 ) {
//		if (handCollider.transform.position.y < table.transform.position.y ) {
//			isSlamming = false;
//			Debug.Log ("How can she slap REMIX? Y = " + transform.position.y);
//
//			audio.PlayOneShot (slam);
//
//			rb.velocity = Vector3.zero;
//			rb.angularVelocity = Vector3.zero;
//			transform.position = new Vector3(previousX, yDefault, previousZ);
//			rb.constraints = previousConstraints; // set to previous state
//		}
//
//	}

	/*
	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Table") {
			Debug.Log ("How can she slap? Y = " + yDefault);
		
			audio.PlayOneShot (slam);
			//transform.position = new Vector3(previousX, yDefault, previousZ);
			//transform.position.y = yDefault; //This doesn't work; need to make temp var, and move towards
			//rb.constraints = previousConstraints; // set to previous state
		}
		
	}
	*/


	void Update () {

			}



		}