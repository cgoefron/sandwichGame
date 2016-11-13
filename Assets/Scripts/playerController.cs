using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

		private float speed;
		private float RotationSpeed = 1.5f;
		private float xSpeed;
		private float ySpeed;


		void Start () {

			speed = 5f;

		}

		void Update () {
			xSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;
			ySpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

			transform.Translate(Vector3.left * -xSpeed);
			transform.Translate (Vector3.forward * ySpeed);

			/*transform.Rotate(0, (Input.GetAxis("Mouse X") * RotationSpeed),0, Space.World);
			transform.Rotate( (Input.GetAxis("Mouse Y") * RotationSpeed),0,0, Space.World);

			if(((transform.rotation.eulerAngles.x<180)&&(transform.rotation.eulerAngles.x>90))||
				((transform.rotation.eulerAngles.z<180)&&(transform.rotation.eulerAngles.z>90))){
				// preserve Y rotation
				float currentLook = transform.rotation.eulerAngles.y;
				// put character to default rotation
				transform.rotation = Quaternion.identity;
				// re-introduce Y rotation
				transform.Rotate(0,0,0); */
			}


		}