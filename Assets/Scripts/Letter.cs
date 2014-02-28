using UnityEngine;
using System.Collections;

public class Letter : MonoBehaviour
{
		public Color highlightedColor;
		public Color deselectedColor;
		public Color healthHigh;
		public Color healthMedium;
		public Color healthLow;
		public GameObject tutorialManager;
		public int letterNumber;
		public int letterPosition;
		public AudioClip startled;
		public AudioClip dead;
	
	
		// Use this for initialization
		void Start ()
		{
				tutorialManager = GameObject.Find ("_LetterManager");
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
		void OnMouseOver ()
		{
				gameObject.renderer.material.SetColor ("_Color", highlightedColor);
				if ((Input.GetMouseButtonDown (0))) {
						//manager.GetComponent<Manager> ().MoveBirdToFront (birdNumber, birdPosition);
						tutorialManager.GetComponent<TutorialManager> ().MoveLetterToFront (this, letterPosition);
						audio.PlayOneShot (startled, 1);
				}
		}
	
		void OnMouseExit ()
		{
				gameObject.renderer.material.SetColor ("_Color", deselectedColor);
		}
	
		public void SetPosition (int newPosition)
		{
				letterPosition = newPosition;
		}

		void OnTriggerEnter (Collider otherCollider)
		{
				if (otherCollider.tag.Equals ("Hazard")) {
						Destroy (gameObject);
			
				}
		}
}
