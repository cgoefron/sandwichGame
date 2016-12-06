using UnityEngine;
using System.Collections;

public class MoveSholder : MonoBehaviour {

	public Transform hand;
	private float newX;
	private float newZ;

	public float speed = 5;

	void Start () {
		speed = speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {

		newX = transform.position.x;
		newZ = transform.position.z;


		if ((hand.position.x - newX) < 5 || (newZ - hand.position.z) < 5 ) {
			newX -= speed;
			newZ += speed;
		}

		else if ((hand.position.x - newX) > 10 || (newZ - hand.position.z) > 10 ) {
			newX += speed;
			newZ -= speed;
		}

		transform.position = new Vector3 (newX,transform.position.y,newZ);
	}
}
