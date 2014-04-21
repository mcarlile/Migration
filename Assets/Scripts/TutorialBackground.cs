using UnityEngine;
using System.Collections;

public class TutorialBackground : MonoBehaviour
{
	
		private Vector3 movement = new Vector3 (0.0f, 0.0f, 0.0f);
		public float movementSpeed = 10f;
		public GameObject leftBounds;
		public GameObject rightBounds;
		public bool canMove = false;
	
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (canMove == true) {
						if ((Input.GetKey (KeyCode.LeftArrow)) || (Input.GetKey (KeyCode.A))) {
								print ("left arrow");
								if (gameObject.transform.position.x < rightBounds.gameObject.transform.position.x) {
										movement = Vector3.right * movementSpeed * Time.deltaTime;
										gameObject.transform.Translate (movement);
								}
			
						}
		
						if ((Input.GetKey (KeyCode.RightArrow)) || (Input.GetKey (KeyCode.D))) {
								if (gameObject.transform.position.x >= leftBounds.gameObject.transform.position.x) {
										movement = Vector3.left * movementSpeed * Time.deltaTime;
										gameObject.transform.Translate (movement);
								}
						}
		
				}
		}
}
