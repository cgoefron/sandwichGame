using UnityEngine;
using System.Collections;

public class boundaryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerEnter(Collider other){

		print ("object entered");

		if (other.tag == "Food") {
			print ("food entered");

			Destroy(other.gameObject);
		}
		
	}
}
