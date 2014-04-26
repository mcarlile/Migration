using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
		public Color highlightedColor;
		public Color deselectedColor;
		public Color healthHigh;
		public Color healthMedium;
		public Color healthLow;
		public GameObject manager; 
		public int birdNumber;
		public int birdPosition;
		public float health = 100;
		public AudioClip startled;
		public AudioClip dead;
		public GameObject narrativeManager;
		public bool tutorialMode;
		public bool healthMessageTriggered;
		public bool successfullyCompletedSwap = false;
		public bool allowClick;
		public GameObject healthIndicator;
		float healthIndicatorAlpha;
		public int position0HealthChangeMultiplier = 20;
		public int position1HealthChangeMultiplier = 15;
		public int position2HealthChangeMultiplier = 10;
		public int position3HealthChangeMultiplier = 5 ;
		public int position4HealthChangeMultiplier = 20;
	
		// Use this for initialization
		void Start ()
		{
				manager = GameObject.Find ("_Manager");
				gameObject.renderer.material.SetColor ("_Color", deselectedColor);
		}
	
		// Update is called once per frame
		void Update ()
		{

//				healthIndicatorAlpha.renderer.material.color -= new Color (0, 0, 0, .10f);

				if (birdPosition == 4) {
						health = (health - ((Time.deltaTime) * position4HealthChangeMultiplier));
				}

				if (((birdPosition == 3) || (birdPosition == 5))) {
						if (health < 100) {
								health = (health + ((Time.deltaTime) * position3HealthChangeMultiplier));
						}
				}

				if (((birdPosition == 2) || (birdPosition == 6))) {
						if (health < 100) {

								health = (health + ((Time.deltaTime) * position2HealthChangeMultiplier));
						}
				}

				if (((birdPosition == 1) || (birdPosition == 7))) {
						if (health < 100) {

								health = (health + ((Time.deltaTime) * position1HealthChangeMultiplier));
						}
				}

				if (((birdPosition == 0) || (birdPosition == 8))) {
						if (health < 100) {

								health = (health + ((Time.deltaTime) * position1HealthChangeMultiplier));
						}
				}
		
				if (health <= 0) {
						SendDeathData ();
						Destroy (gameObject);
						if (tutorialMode == true) {
								narrativeManager.GetComponent<NarrativeManager> ().ShowDeathMessage ();
								manager.GetComponent<Manager> ().BirdDiedFromExhaustion ();
						}
				}
		
		}
	
		void OnMouseOver ()
		{
				gameObject.renderer.material.SetColor ("_Color", highlightedColor);
				if ((Input.GetMouseButtonDown (0)) && (allowClick == true)) {
						//manager.GetComponent<Manager> ().MoveBirdToFront (birdNumber, birdPosition);
						manager.GetComponent<Manager> ().MoveBirdToFront (this, birdPosition);
						audio.PlayOneShot (startled, 1);
						if (tutorialMode == true) {
								narrativeManager.GetComponent<NarrativeManager> ().ShowSwapSuccessMessage ();
								manager.GetComponent <Manager> ().SuccessfullyCompletedSwap ();
						}
				}
		}
	
		void OnMouseExit ()
		{
				gameObject.renderer.material.SetColor ("_Color", deselectedColor);
		}
	
		public void SetPosition (int newPosition)
		{
				birdPosition = newPosition;
		}
	
		void SendDeathData ()
		{
				manager.GetComponent<Manager> ().DestroyBird (gameObject, birdPosition);
		}

		void OnTriggerEnter (Collider otherCollider)
		{
				if (otherCollider.tag.Equals ("Hazard")) {
						SendDeathData ();
						Destroy (gameObject);
						if (tutorialMode == true) {
								narrativeManager.GetComponent<NarrativeManager> ().ShowCollissionMessage ();
								manager.GetComponent<Manager> ().BirdDiedOnCollision ();
						}
				}

				if (otherCollider.tag.Equals ("Finish")) {
						SendDeathData ();
						Destroy (gameObject);
						manager.GetComponent<Manager> ().Hit2025FinishLine ();
						if (tutorialMode == true) {
								narrativeManager.GetComponent<NarrativeManager> ().ShowCollissionMessage ();
								manager.GetComponent<Manager> ().BirdDiedOnCollision ();
						}
				}
		}

		public void AllowClick ()
		{
				allowClick = true;
		}

		public void DisableClick ()
		{
				allowClick = false;
		}

}
