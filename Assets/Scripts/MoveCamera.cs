using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{

		private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
		public float movementSpeed = 0.1f;
		public bool reverseMovement;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (reverseMovement == false) {
						movement = Vector3.down * movementSpeed * Time.deltaTime;
						gameObject.transform.Translate (movement);
				} else {
						movement = Vector3.up * movementSpeed * Time.deltaTime;
						gameObject.transform.Translate (movement);
				}
		} 
}
