using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour
{

		public GameObject pause;
		public GameObject play;
		public GameObject pauseDeslected;
		public GameObject playDeslected;
		public bool allowClick = true;
		public bool gamePaused = false;
		public AudioClip hover;



		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (gamePaused) {
						play.gameObject.renderer.enabled = true;
						pause.gameObject.renderer.enabled = false;
						Time.timeScale = 0.0f;
				} else {
						pause.gameObject.renderer.enabled = true;
						play.gameObject.renderer.enabled = false;
						Time.timeScale = 1.0f;
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

		void OnMouseEnter ()
		{
				audio.PlayOneShot (hover, 1f);
		}
}
