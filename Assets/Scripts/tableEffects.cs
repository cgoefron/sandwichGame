﻿using UnityEngine;
using System.Collections;

public class tableEffects : MonoBehaviour {


	public float radius;
	public float power;
	public float air;

	private float defaultY;
	private Rigidbody rb;
	public Camera mainCamera;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;



	void Start (){
		//defaultY = transform.position.y;



	}

	void Update() {

//		Debug.Log ("Table is hit");
//		Detonate ();
//		mainCamera.GetComponent<CameraShake>().DoShake();

	}
		

	void OnCollisionEnter(Collision col){


//		if (col.gameObject.tag == "Player") {
//
//			Debug.Log ("Table is hit");
//			Detonate ();
//			mainCamera.GetComponent<CameraShake>().DoShake();
//			//transform.position = Random.insideUnitCircle * amount * (Time.time * speed);
//			//rb.AddExplosionForce(10, Vector3.zero, 10, 0, ForceMode.Impulse);
//		}

	}

	void Detonate(){

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (Vector3.zero, 10);

		foreach (Collider col in colliders) {

			Rigidbody rb = col.GetComponent<Rigidbody> ();

			if (rb != null)
				rb.AddExplosionForce(power, explosionPos, radius, air);
		}
	}

}
