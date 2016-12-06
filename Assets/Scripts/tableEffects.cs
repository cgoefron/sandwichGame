using UnityEngine;
using System.Collections;

public class tableEffects : MonoBehaviour {

	//Sound effects when food hits the table

	//Sound effects when hands hit table?

	//shake or particle effects

	public float speed; //how fast it shakes
	public float amount; //how much it shakes
	private float defaultY;


	void Start (){
		defaultY = transform.position.y;
	}

	void Update() {
		//defaultY = Mathf.Sin(Time.time * speed);
	}
		

	void OnCollisionEnter(Collision col){

		Debug.Log ("work");
		
		if (col.gameObject.tag == "Player") {

			Debug.Log ("Table is hit");

			transform.position = Random.insideUnitCircle * amount * (Time.time * speed);

		}

	}

}
