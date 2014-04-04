using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
		private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
		public float movementSpeed;
		public GameObject background;
		// Use this for initialization
		void Start ()
		{
				//movementSpeed = background.GetComponent<Background> ().movementSpeed;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
				movement = Vector3.up * movementSpeed * Time.deltaTime;
				gameObject.transform.Translate (movement);
		}
}
