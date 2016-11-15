using UnityEngine;
using System.Collections;

public class onPlates : MonoBehaviour {

	GameObject collider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		
		if (other.CompareTag ("Food") && other.isTrigger == true) {

			other.enabled = false;
		}

	}

	void OnTriggerExit(Collider other){
		
		if (other.CompareTag ("Food") && other.isTrigger == true) {

			other.enabled = true;
		}
	}
}
