using UnityEngine;
using System.Collections;

public class blinkImage : MonoBehaviour {

	public GameObject image;

	bool blink = false;
	int counter = 0;
	public float blinkStart;

	bool startFlashing = false;

	void Start(){
		StartCoroutine(Flash(10f));
	}

	void Update()
	{
		/*
		if (counter == blinkSpeed) {
			blink = true;
			counter = 0;
		} else {
			blink = false;
		}

		counter ++;

		if (blink) {
			image.SetActive (true);

			counter = 0;
		} else {
			image.SetActive (false);
		}
		*/
	}

	IEnumerator Flash(float flashCount)
	{
		for(float i = 0f; i < flashCount; i += 0.1f)
		{

			if (!startFlashing) {
				yield return new WaitForSeconds (blinkStart);
				startFlashing = true;
			}

			if (startFlashing) {
				image.SetActive (true);
				yield return new WaitForSeconds (1.5f);
				image.SetActive (false);
				yield return new WaitForSeconds (0.3f);
			}
		}
	}

}
