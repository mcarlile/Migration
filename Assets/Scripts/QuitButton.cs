using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour
{

		public GameObject manager;
		public GameObject deselectedQuitButton;
		public GameObject selectedQuitButton;
		public AudioClip hover;


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
				selectedQuitButton.gameObject.renderer.enabled = false;
				deselectedQuitButton.gameObject.renderer.enabled = true;
				if ((Input.GetMouseButtonDown (0))) {
						Application.Quit ();
						print ("should have quit");
				}
		}

		void OnMouseExit ()
		{
				selectedQuitButton.gameObject.renderer.enabled = true;
				deselectedQuitButton.gameObject.renderer.enabled = false;
		}

		void OnMouseEnter ()
		{
				audio.PlayOneShot (hover, 1f);
		}
}
