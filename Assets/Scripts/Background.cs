using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{

		private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
		public float movementSpeed = 0.1f;

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
