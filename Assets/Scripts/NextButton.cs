using UnityEngine;
using System.Collections;

public class NextButton : MonoBehaviour
{

		public GameObject manager;
		public int levelToLoad;
		public GameObject deselectedNextButton;
		public GameObject selectedNextButton;

		// Use this for initialization
		void Start ()
		{
				manager = GameObject.Find ("_Manager");
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
		void OnMouseOver ()
		{
				selectedNextButton.gameObject.renderer.enabled = false;
				deselectedNextButton.gameObject.renderer.enabled = true;

				print ("over the pause button");
				if ((Input.GetMouseButtonDown (0))) {
						Application.LoadLevel (levelToLoad);
				}
		}

		void OnMouseExit ()
		{
				selectedNextButton.gameObject.renderer.enabled = true;
				deselectedNextButton.gameObject.renderer.enabled = false;
		}
}
