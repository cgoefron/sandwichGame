using UnityEngine;
using System.Collections;

public class foodSpawn : MonoBehaviour {

// have food randomly spawn at timed intervals
	private int repObjCount;
	public float maxTime = 5;
	public float minTime = 2;
	private float spawnTime; //random time interval
	private float time; //current time
	public GameObject[] foodObjects;
	private float randomNumber;
	public int breakPercent;


	void Start () {

		SetRandomTime();
		time = minTime;


	}
	

	void Update () {
		//Debug.Log ("timer is " + spawnTime);
	}

	void FixedUpdate(){

		//Counts up
		time += Time.deltaTime; 

		if(time >= spawnTime){
			RandomFoodDrop();
			SetRandomTime();
		}

	}


	void SetRandomTime(){ //Sets the random time between minTime and maxTime
		spawnTime = Random.Range(minTime, maxTime);
	}

	void RandomFoodDrop(){ //break random #(variable) at random interval (variable)

		//load all breakable objects into array
		foodObjects = GameObject.FindGameObjectsWithTag ("Food");

		//Debug.Log (foodObjects.Length);


		foreach(GameObject foodObj in foodObjects)
		{

			//if(foodObj.GetComponent<objectHealthScript>().objectBroken == false){
				
				//random number generator, check if number is above#
				randomNumber = Random.Range(0f, 100f);


				if (randomNumber <= breakPercent) {
					//repairObj.GetComponent<objectHealthScript> ().BreakObject ();


					//exit loop ("break") if it is broken
					break;

				} else {
					//Debug.Log ("object skipped: " + randomNumber);
				}


			}
		}

		time = 0;

	}




