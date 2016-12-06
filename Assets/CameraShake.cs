﻿using UnityEngine;
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
	}


	// Update is called once per frame
	void Update () 
	{
		if(ShakeIntensity > 0)
		{
			transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
			transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f);

			ShakeIntensity -= ShakeDecay;
		}
		else if (Shaking)
		{
			Shaking = false;  
		}
	}

	public void DoShake()
	{
		OriginalPos = transform.position; //need to fix this so it always returns to correct position
		OriginalRot = transform.rotation;

		ShakeIntensity = 0.05f;
		ShakeDecay = 0.04f;
		Shaking = true;
	}   
}