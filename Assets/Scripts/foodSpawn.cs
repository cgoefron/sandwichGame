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

	void RandomFoodDrop(){ 

		Debug.Log (foodObjects.Length);
		//foodObjects = new GameObject[7];

		//random number generator, check if number is above#
		randomNumber = Random.Range(0f, 100f);

		Debug.Log ("random number is " + randomNumber);

		if (randomNumber <= breakPercent) {

		Instantiate (foodObjects[UnityEngine.Random.Range(0,foodObjects.Length)], transform.position, transform.rotation);



		} else {
			//Debug.Log ("object skipped: " + randomNumber);
		}

		time = 0;

			}
		}








