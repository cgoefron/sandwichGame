using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
		
			if (Input.GetKey (KeyCode.R)) {
				SceneManager.LoadScene (0);
			}
		}
	}
