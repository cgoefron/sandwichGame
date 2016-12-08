using UnityEngine;
using System.Collections;
using Rewired;

public class playerController : MonoBehaviour {

	public int playerId = 0;
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
	//private float speed;

	public AudioClip pickupFood;
	public AudioClip dropFoodTable;
	public AudioClip slam;
	//public AudioClip dropFoodFloor;
	public AudioClip slamTable;
	private AudioSource audio;

	public GameObject defaultHand;
	public GameObject grabHand;


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
		canSlam = true;
		//speed = 5f;
	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector2 move = new Vector2 (player.GetAxis ("Horizontal"), player.GetAxis ("Vertical")) * moveSpeed;
		Vector3 movement = new Vector3 (move.x, rb.velocity.y, move.y);
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

			if (Input.GetKeyDown (KeyCode.Space)) { //add check for Y position before slamming
				//rb.AddForce(transform.forward * thrust); 


				// unfreeze y position, add force toward table
				rb.constraints = RigidbodyConstraints.FreezeRotationY;
				previousX = transform.position.x;
				previousZ = transform.position.z;
				rb.AddForce (0, (table.transform.position.y - transform.position.y) * thrust, 0);
				// move hand to original y position (yDefault), re-freeze y transform - MOVING TO ONCOLLISIONENTER


			}


		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Table") {
			//Debug.Log ("How can she slap? Y = " + yDefault);
		
			audio.PlayOneShot (slam);
			transform.position = new Vector3(previousX, yDefault, previousZ);
			//transform.position.y = yDefault; //This doesn't work; need to make temp var, and move towards
			rb.constraints = previousConstraints; // set to previous state

		}
		
	}



	void Update () {
//		xSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime; //constrain height
////
//		ySpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
////
//		transform.Translate(Vector3.left * -xSpeed);
//		transform.Translate (Vector3.forward * ySpeed);

			/*transform.Rotate(0, (Input.GetAxis("Mouse X") * RotationSpeed),0, Space.World);
			transform.Rotate( (Input.GetAxis("Mouse Y") * RotationSpeed),0,0, Space.World);

			if(((transform.rotation.eulerAngles.x<180)&&(transform.rotation.eulerAngles.x>90))||
				((transform.rotation.eulerAngles.z<180)&&(transform.rotation.eulerAngles.z>90))){
				// preserve Y rotation
				float currentLook = transform.rotation.eulerAngles.y;
				// put character to default rotation
				transform.rotation = Quaternion.identity;
				// re-introduce Y rotation
				transform.Rotate(0,0,0); */
			}



		}