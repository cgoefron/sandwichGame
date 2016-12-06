using UnityEngine;
using System.Collections;

public class HandMove : MonoBehaviour {

	private Rigidbody rb;
	public float speed = 5f;
	private float xSpeed;
	private float ySpeed;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called at a constant rate, used for physics
	void FixedUpdate () {
		//movement
		xSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		ySpeed = Input.GetAxisRaw ("Vertical") * speed;
		rb.velocity = new Vector3 (xSpeed, 0, ySpeed);
	} 
}
