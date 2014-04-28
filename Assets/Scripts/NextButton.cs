using UnityEngine;
using System.Collections;

public class NextButton : MonoBehaviour
{

		public GameObject manager;
		public int levelToLoad;
		public GameObject deselectedNextButton;
		public GameObject selectedNextButton;
		public AudioClip hover;
		public GameObject fadeBlack;
		bool hasBeenFaded = false;


		// Use this for initialization
		void Start ()
		{
				manager = GameObject.Find ("_Manager");
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (hasBeenFaded == true) {
						fadeBlack.GetComponent<SceneFadeOutIn> ().EndScene (levelToLoad);
				}

		
		}
	
		void OnMouseOver ()
		{
				selectedNextButton.gameObject.renderer.enabled = false;
				deselectedNextButton.gameObject.renderer.enabled = true;

				print ("over the pause button");
				if ((Input.GetMouseButtonDown (0))) {
						hasBeenFaded = true;
				}
		}

		void OnMouseExit ()
		{
				selectedNextButton.gameObject.renderer.enabled = true;
				deselectedNextButton.gameObject.renderer.enabled = false;
		}

		void OnMouseEnter ()
		{
				audio.PlayOneShot (hover, 1f);
		}
}
