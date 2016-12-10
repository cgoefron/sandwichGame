using UnityEngine;
using System.Collections;

public class foodSpawn : MonoBehaviour {

// have food randomly spawn at timed intervals
	private int repObjCount;
	public float maxTime;
	public float minTime;
	public float breadMaxTime = 5;
	public float breadMinTime = 2;
	private float spawnTime, breadSpawnTime; //random time interval
	private float time; //current time
	private float breadTime; //current time
	public GameObject[] foodObjects;
	private float randomNumber;
	public int breakPercent;


	void Start () {

		SetRandomTime();
		time = minTime;
		breadTime = breadMinTime;

	}
	

	void Update () {
		//Debug.Log ("timer is " + spawnTime);
	}

	void FixedUpdate(){

		//Counts up
		time += Time.deltaTime; 
		breadTime += Time.deltaTime; 

		if(time >= spawnTime){

			//diff for ingredients
			RandomFoodDrop();
			SetRandomTime();
		}

		//for bread

		if(breadTime >= breadSpawnTime){

			//diff for ingredients
			BreadTopDrop();
			breadSpawnTime = Random.Range (breadMinTime, breadMaxTime);
		}

	}


	void SetRandomTime(){
		//Sets the random time between minTime and maxTime
		spawnTime = Random.Range(minTime, maxTime);

	}

	void RandomFoodDrop(){ 

		//Debug.Log (foodObjects.Length);
		//foodObjects = new GameObject[7];

		//random number generator, check if number is above#
		randomNumber = Random.Range (0f, 100f);

		//Debug.Log ("random number is " + randomNumber);

		if (randomNumber <= breakPercent) {

			Instantiate (foodObjects [UnityEngine.Random.Range (2, foodObjects.Length)], transform.position, transform.rotation);

		} else {
			//Debug.Log ("object skipped: " + randomNumber);
		}

		time = 0;

	}

	void BreadTopDrop(){

		randomNumber = Random.Range (0f, 300f);

		//Element 0, 1 = bread top

		if (randomNumber <= breakPercent) {

			Instantiate (foodObjects [UnityEngine.Random.Range (0,1)], transform.position, transform.rotation);

			//longer time to spawn bread tops
			breadMaxTime++;
			breadMinTime++;

			//Debug.Log (breadMinTime);


		}

		breadTime = 0;


	}
}








