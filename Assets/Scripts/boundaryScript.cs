using UnityEngine;
using System.Collections;

public class boundaryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		//print ("object entered");

		if (other.CompareTag("Food")) {
			//print ("food entered");

			Destroy(other.gameObject);
		}
		
	}
}
