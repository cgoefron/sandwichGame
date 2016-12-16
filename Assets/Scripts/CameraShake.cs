using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {


	public bool Shaking; 
	public float ShakeDecay;
	public float ShakeIntensity;    
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;

	void Start()
	{
		Shaking = false;
		OriginalPos = transform.position;
		OriginalRot = transform.rotation;
	}


	// Update is called once per frame
	void Update () 
	{
		if (Shaking) {
			DoShake ();
			if (ShakeIntensity > 0) {
				transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
				transform.rotation = new Quaternion (OriginalRot.x + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f,
					OriginalRot.y + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f,
					OriginalRot.z + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f,
					OriginalRot.w + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f);

				ShakeIntensity -= ShakeDecay;
			}
		}

		if (!Shaking) {
			transform.position = OriginalPos;
			transform.rotation = OriginalRot;
		}
	}

	public void DoShake()
	{
//		OriginalPos = transform.position; //need to fix this so it always returns to correct position
//		OriginalRot = transform.rotation;

		ShakeIntensity = 0.05f;
		ShakeDecay = 0.04f;
		Shaking = true;
	}   
}