using UnityEngine;
using System.Collections;

public class ShoulderMove : MonoBehaviour {

	// Use this for initialization
	public Transform hand;
	public Transform wrist;
	private float armLength;


	void Start () {
		//armLength = transform.position.x - wrist.position.x; //Arm2 and Arm3
		armLength = transform.position.z - wrist.position.z; //Arm and Arm1
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3 (hand.position.x+armLength, transform.position.y, transform.position.z); //Arm2 and Arm3
		transform.position = new Vector3 (transform.position.x, transform.position.y, hand.position.z+armLength); //Arm and Arm1
	}
}
