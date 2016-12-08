using UnityEngine;
using System.Collections;

public class armAnchor : MonoBehaviour {

	public Transform anchorPoint;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (anchorPoint.position.x, anchorPoint.position.y, anchorPoint.position.z);

	}
}
