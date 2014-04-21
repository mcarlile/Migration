using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

		public Rect windowRect = new Rect (295, 175, 0, 0);
		public bool gamePaused = false;
//	public Font font = "Bebas Neue";
	
		void Start ()
		{
	
		}
		
		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.P)) {
						if (gamePaused) {
								gamePaused = false;
								Time.timeScale = 1.0f;
						} else {
								gamePaused = true;
								Time.timeScale = 0.0f;
						}			
				}
				if (Input.GetKeyDown ("r")) {
						Application.LoadLevel (Application.loadedLevel);
				}
				if (Input.GetKeyDown ("q")) {
						Application.LoadLevel ("12_credits");
//			Application.Quit(); 
				}
		}
	
//		void OnGUI ()
//		{
//
//				if (GUI.Button (new Rect (Screen.width - 80, 630, 60, 30), "Pause"))
//						;
//				{
//						Debug.Log ("Clicked pause");
////
////			if(gamePaused){
////				gamePaused = false;
////				Time.timeScale = 1.0f;
////			} else {
////				gamePaused = true;
////				Time.timeScale = 0.0f;}	
//				}
//
//
//				if (GUI.Button (new Rect (Screen.width - 80, 665, 60, 30), "Reload"))
//						;
//				{
//						Debug.Log ("Clicked reload");
//						Application.LoadLevel ("5_1905");
//				}
//
//
//				if (GUI.Button (new Rect (Screen.width - 80, 700, 60, 30), "Quit"))
//						;
//				{
//						Debug.Log ("Clicked quit");
//						Application.LoadLevel ("12_credits");
//				}
//
//				if (GUI.Button (new Rect (10, 70, 50, 30), "Click"))
//						Debug.Log ("Clicked the button with text");
//		
//		}




}