using UnityEngine;
using System.Collections;
using Rewired;

public class testControllerScript : MonoBehaviour {

	public int playerId = 0;
	public Player player;
	public Rigidbody rb;
	public float moveSpeed;
	public bool isGrabbing = false;
	public bool nearFood = false;
	//private GameObject theFood;
	//public Transform handCollider;
//	public float thrust;
//	//public Transform table;
//	public float yDefault;
//	private RigidbodyConstraints previousConstraints;
//	private float previousX, previousZ;
//	private bool canSlam;
	//private float speed;

//	public AudioClip pickupFood;
//	public AudioClip dropFoodTable;
//	public AudioClip slam;
//	//public AudioClip dropFoodFloor;
//	public AudioClip slamTable;
//	private AudioSource audio;
//
//	public GameObject defaultHand;
//	public GameObject grabHand;


	// Use this for initialization

	void Awake(){

		player = ReInput.players.GetPlayer(playerId);	
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
		//audio = GetComponent<AudioSource>();
		//rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
//		previousConstraints = rb.constraints;
//		previousX = transform.position.x;
//		previousZ = transform.position.z;
//		yDefault = transform.position.y;
//		isGrabbing = false;
//		canSlam = true;
		//speed = 5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector2 move = new Vector2 (player.GetAxis ("Horizontal"), player.GetAxis ("Vertical")) * moveSpeed;
		Vector3 movement = new Vector3 (move.x, rb.velocity.y, move.y);
		rb.velocity = movement;
	
	}
}
