using UnityEngine;
using System.Collections;

public class tableEffects : MonoBehaviour {


	public float radius;
	public float power;
	public float air;

	private float defaultY, defaultX;
	Vector3 OriginPos;
	private Rigidbody rb;
	public Camera mainCamera;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	bool isSlamming;
	bool canSlam;
	//GameObject p1;

	bool player1entered;
	public float amount, speed;

	void Start (){
		defaultY = transform.position.y;
		//defaultX = transform.position.x;

		OriginPos = transform.position;
		canSlam = true;
		//p1 = player1.GetComponent<playerController> ();

	}

	void Update() {

//		Debug.Log ("Table is hit");
//		Detonate ();
//		mainCamera.GetComponent<CameraShake>().DoShake();
//
		SlamState ();

		//transform.position = new Vector2(OriginPos.x, OriginPos.z) + Random.insideUnitCircle * amount * (Time.time * speed);
		//rb.AddExplosionForce(10, Vector3.zero, 10, 0, ForceMode.Impulse);


	}

	void SlamState(){
		
		//if (player1.GetButtonDown("Action1") && player1entered == false){
		if (player1.GetComponent<playerController> ().isSlamming && canSlam) {

			//Debug.Log ("player 1 entered");
			//player1entered = true;
			//playerCount++;
//			Debug.Log ("slamming now");

			Detonate ();
			mainCamera.GetComponent<CameraShake> ().Shaking = true;
//			transform.position = new Vector2 (OriginPos.x, OriginPos.z) + Random.insideUnitCircle * amount * (Time.time * speed);
			//transform.position = Random.insideUnitCircle.normalized * amount;
			//rb.AddExplosionForce (10, Vector3.zero, 10, 0, ForceMode.Impulse);

			StartCoroutine(SlamEffect(1f, 15f));
		}

		else if(!player1.GetComponent<playerController> ().isSlamming) {
			
			transform.position = OriginPos;
			//mainCamera.GetComponent<CameraShake> ().Shaking = false;

		}
	
	}
		

	void OnCollisionEnter(Collision col){

//		if (col.gameObject.tag == "Player") {
//
//			Debug.Log ("Table is hit");
//			Detonate ();
//			mainCamera.GetComponent<CameraShake>().Shaking = true;
//			transform.position = new Vector2(OriginPos.x, OriginPos.z) + Random.insideUnitCircle * amount * (Time.time * speed);
//			rb.AddExplosionForce(10, Vector3.zero, 10, 0, ForceMode.Impulse);
//		}

	}

	void Detonate(){

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (Vector3.zero, 10);

		foreach (Collider col in colliders) {

			Rigidbody rb = col.GetComponent<Rigidbody> ();

			if (rb != null && col.gameObject.CompareTag ("Food")) {//every food's rb
				rb.AddExplosionForce (power, explosionPos, radius, air);
			}
		}
	}

	IEnumerator SlamEffect(float shakeTime, float slamTimeGap)
	{

//		for(float i = 0f; i < shakeTime; i += 0.1f)
//		{

			if (player1.GetComponent<playerController> ().isSlamming) {

				yield return new WaitForSeconds (shakeTime);
				Debug.Log ("stop slam");
				//stop camera shaking
				player1.GetComponent<playerController> ().isSlamming = false;
				mainCamera.GetComponent<CameraShake> ().Shaking = false;

				canSlam = false;
			}
		//}


		if (!isSlamming && !canSlam) {
				
			yield return new WaitForSeconds (slamTimeGap);
			canSlam = true;
			Debug.Log ("can slam Again");


		}
	}

}
