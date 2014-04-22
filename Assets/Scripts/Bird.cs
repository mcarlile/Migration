﻿using UnityEngine;
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
		public double health = 7;
		public GameObject health1;
		public GameObject health2;
		public GameObject health3;
		public GameObject health4;
		public GameObject health5;
		public GameObject health6;
		public GameObject health7;
		public AudioClip startled;
		public AudioClip dead;
		public GameObject narrativeManager;
		public bool tutorialMode;
		public bool healthMessageTriggered;
		public bool successfullyCompletedSwap = false;
		public bool allowClick;


	
		// Use this for initialization
		void Start ()
		{
				manager = GameObject.Find ("_Manager");
				gameObject.renderer.material.SetColor ("_Color", deselectedColor);
				health1.renderer.material.SetColor ("_Color", healthHigh);
				health2.renderer.material.SetColor ("_Color", healthHigh);
				health3.renderer.material.SetColor ("_Color", healthHigh);
				health4.renderer.material.SetColor ("_Color", healthHigh);
				health5.renderer.material.SetColor ("_Color", healthHigh);
				health6.renderer.material.SetColor ("_Color", healthHigh);
				health7.renderer.material.SetColor ("_Color", healthHigh);
		
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (health < 7) {
						health7.SetActive (false);
				} else {
						health7.SetActive (true);
				}
		
				if (health < 6) {
						health6.SetActive (false);
				} else {
						health6.SetActive (true);
				}
		
				if (health < 5) {
						health5.SetActive (false);
				} else {
						health5.SetActive (true);
				}
		
				if (health < 4) {
						health4.SetActive (false);
				} else {
						health4.SetActive (true);
				}
		
				if (health < 3) {
						health3.SetActive (false);
				} else {
						health3.SetActive (true);
				}
		
				if (health < 2) {
						health2.SetActive (false);
				} else {
						health2.SetActive (true);
				}
		
				if (health <= 1) {
						health1.SetActive (false);
				} else {
						health1.SetActive (true);
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
	
		//Begin Health Management System
	
		public void ChangeHealth ()
		{
				//Birds in the back of the flock increase their health over time while birds
				//in the front of the flock decrease their health. The more close to either
				//the front or the back, the more extreme the change

				if (manager.GetComponent<Manager> ().birds.Count >= 8) {
						if (((birdPosition == 0) || (birdPosition == 8)) && (health <= 5)) {
								health = health + 2;
						}
		
						if (((birdPosition == 1) || (birdPosition == 7)) && (health <= 5)) {
								health = health + 1;
						}
		
						if (((birdPosition == 2) || (birdPosition == 6)) && (health <= 5)) {
								health = health + 0.7;
						}
			
						if (((birdPosition == 3) || (birdPosition == 5)) && (health <= 5)) {
						}
						if (birdPosition == 4) {
								health = health - 0.5;
						}
						ChangeHealthMeterColor ();
				}
				if ((manager.GetComponent<Manager> ().birds.Count == 6) || (manager.GetComponent<Manager> ().birds.Count == 7)) {
						if (((birdPosition == 1) || (birdPosition == 7)) && (health <= 5)) {
								health = health + 2;
						}
			
						if (((birdPosition == 2) || (birdPosition == 6)) && (health <= 5)) {
								health = health + 1;
						}
			
						if (((birdPosition == 3) || (birdPosition == 5)) && (health <= 5)) {
						}
						if (birdPosition == 4) {
								health = health - 0.5;
						}
						ChangeHealthMeterColor ();
				}

				if ((manager.GetComponent<Manager> ().birds.Count == 4) || (manager.GetComponent<Manager> ().birds.Count == 5)) {
						if (((birdPosition == 2) || (birdPosition == 6)) && (health <= 5)) {
								health = health + 2;
						}
			
						if (((birdPosition == 3) || (birdPosition == 5)) && (health <= 5)) {
								health = health + 0.7;
						}
						if (birdPosition == 4) {
								health = health - 0.5;
						}
						ChangeHealthMeterColor ();
				}
				if (manager.GetComponent<Manager> ().birds.Count < 4) {
						if (((birdPosition == 3) || (birdPosition == 5)) && (health <= 5)) {
								health = health + 0.7;
						}
						if (birdPosition == 4) {
								health = health - 0.5;
						}
						ChangeHealthMeterColor ();
				}
		
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
	
	
		public void ChangeHealthMeterColor ()
		{
				if (health >= 5) {
						gameObject.renderer.material.SetColor ("_Color", deselectedColor);
						health1.renderer.material.SetColor ("_Color", healthHigh);
						health2.renderer.material.SetColor ("_Color", healthHigh);
						health3.renderer.material.SetColor ("_Color", healthHigh);
						health4.renderer.material.SetColor ("_Color", healthHigh);
						health5.renderer.material.SetColor ("_Color", healthHigh);
						health6.renderer.material.SetColor ("_Color", healthHigh);
						health7.renderer.material.SetColor ("_Color", healthHigh);
				}
				if ((health >= 2) && (health < 5)) {
						gameObject.renderer.material.SetColor ("_Color", deselectedColor);
						health1.renderer.material.SetColor ("_Color", healthMedium);
						health2.renderer.material.SetColor ("_Color", healthMedium);
						health3.renderer.material.SetColor ("_Color", healthMedium);
						health4.renderer.material.SetColor ("_Color", healthMedium);
						health5.renderer.material.SetColor ("_Color", healthMedium);
						health6.renderer.material.SetColor ("_Color", healthMedium);
						health7.renderer.material.SetColor ("_Color", healthMedium);
				}
				if (health <= 4) {
						if ((tutorialMode == true) && (healthMessageTriggered == false)) {
								narrativeManager.GetComponent<NarrativeManager> ().ShowLowHealthMessage ();
								manager.GetComponent<Manager> ().AllowBirdsToBeClicked ();
								healthMessageTriggered = true;
						}
						gameObject.renderer.material.SetColor ("_Color", healthLow);
						health1.renderer.material.SetColor ("_Color", healthLow);
						health2.renderer.material.SetColor ("_Color", healthLow);
						health3.renderer.material.SetColor ("_Color", healthLow);
						health4.renderer.material.SetColor ("_Color", healthLow);
						health5.renderer.material.SetColor ("_Color", healthLow);
						health6.renderer.material.SetColor ("_Color", healthLow);
						health7.renderer.material.SetColor ("_Color", healthLow);
				}
		}

		public void AllowClick ()
		{
				allowClick = true;
		}

}
