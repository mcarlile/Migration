﻿using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour
{

		public GameObject pause;
		public GameObject play;
		public GameObject pauseDeslected;
		public GameObject playDeslected;
		public bool allowClick = true;
		public bool gamePaused = false;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
//				if (Input.GetKeyUp (KeyCode.P)) {
				if (gamePaused) {
						play.gameObject.renderer.enabled = true;
						pause.gameObject.renderer.enabled = false;


//						gamePaused = false;
						Time.timeScale = 0.0f;
				} else {
						pause.gameObject.renderer.enabled = true;
						play.gameObject.renderer.enabled = false;


//						gamePaused = true;
						Time.timeScale = 1.0f;
				}			
//				}
				if (Input.GetKeyDown ("r")) {
						Application.LoadLevel (Application.loadedLevel);
				}
				if (Input.GetKeyDown ("q")) {
						Application.LoadLevel ("12_credits");
						//			Application.Quit(); 
				}
		}

		void OnMouseOver ()
		{
				if ((Input.GetMouseButtonDown (0)) && (allowClick == true)) {
						gamePaused = !gamePaused;
				}
				if (gamePaused == true) {
						play.gameObject.renderer.enabled = false;
						playDeslected.gameObject.renderer.enabled = true;
						pause.gameObject.renderer.enabled = false;
						pauseDeslected.gameObject.renderer.enabled = false;
				} else {
						print ("should be changing color to gray");
						play.gameObject.renderer.enabled = false;
						playDeslected.gameObject.renderer.enabled = false;
						pause.gameObject.renderer.enabled = false;
						pauseDeslected.gameObject.renderer.enabled = true;
				}
		}

		void OnMouseExit ()
		{
				if (gamePaused == true) {
						play.gameObject.renderer.enabled = false;
						playDeslected.gameObject.renderer.enabled = false;
						pause.gameObject.renderer.enabled = false;
						pauseDeslected.gameObject.renderer.enabled = false;
				} else {
						play.gameObject.renderer.enabled = false;
						playDeslected.gameObject.renderer.enabled = false;
						pause.gameObject.renderer.enabled = true;
						pauseDeslected.gameObject.renderer.enabled = false;
				}
		}
}