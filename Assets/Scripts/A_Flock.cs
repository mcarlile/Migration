using UnityEngine;
using System.Collections;

public class A_Flock : MonoBehaviour
{

		private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
		public float movementSpeed = 1f;

		public GameObject bird1;
		public GameObject bird2;
		public GameObject bird3;
		public GameObject bird4;
		public GameObject bird5;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				movement = Vector3.down * movementSpeed * Time.deltaTime;
				gameObject.transform.Translate (movement);

				if (Input.GetKey (KeyCode.LeftArrow)) {
						movement = Vector3.right * movementSpeed * Time.deltaTime;
						gameObject.transform.Translate (movement);
				}

				if (Input.GetKey (KeyCode.RightArrow)) {
						movement = Vector3.left * movementSpeed * Time.deltaTime;
						gameObject.transform.Translate (movement);
				}

		}


}





