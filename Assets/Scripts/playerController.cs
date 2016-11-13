using UnityEngine;
using System.Collections;
using Rewired;

public class playerController : MonoBehaviour {

	public int playerId = 0;
	public Player player;
	public Rigidbody rb;
	public float moveSpeed;
	private bool hasFood = false;
	public bool nearFood = false;

	private float speed;
	//private float RotationSpeed = 1.5f;
	private float xSpeed;
	private float ySpeed;

	//public AudioClip pickupFood;
	//public AudioClip dropFoodTable;
	//public AudioClip dropFoodFloor;
	//public AudioClip slamTable;
	//private AudioSource audio;


	// Use this for initialization

	void Awake(){

		player = ReInput.players.GetPlayer(playerId);	
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
		speed = 5f;
		//audio = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector2 move = new Vector2 (player.GetAxis ("Horizontal"), player.GetAxis ("Vertical")) * moveSpeed;
		Vector3 movement = new Vector3 (move.x, rb.velocity.y, move.y);
		rb.velocity = movement;


//		if (move.x != 0 || move.y != 0) {
//			//audio.Play(walkIndoors);
//
//			//play walk sound; change based on outdoor/indoor?
//
//		}
			
	}
		

	void OnTriggerEnter(Collider other){

		if (other.tag == "Food") {
			nearFood = true;

			if (other.GetComponent<playerController> ().player.GetButton ("Action1") && hasFood == false) {
				//print ("stunned!");
				//audio.PlayOneShot (pickupFood);
				hasFood = true;
				//food attaches to hand
				other.transform.parent = transform;


			}

			if (other.GetComponent<playerController> ().player.GetButtonUp ("Action1") && hasFood == true) {
				//print ("stunned!");
				//audio.PlayOneShot (pickupFood);
				hasFood = false;
				//food is let go
				other.transform.parent = null;

			}
		}
		
//		if ((other.CompareTag("tool")) && player.GetButtonDown("Action2")) {
//			print ("pickup");
//			//play pickup sound
//			audio.PlayOneShot(pickupTool);
//			other.transform.parent = transform;
//			haveTool = true;
//		}
//		if ((haveTool = true) && player.GetButtonDown("Action3")) {
//			print ("tool drop");
//			audio.PlayOneShot(dropTool);
//			other.transform.parent = null;
//		}
	}

	void OnTriggerExit(Collider other){

		if (other.tag == "Food") {
			nearFood = false;

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