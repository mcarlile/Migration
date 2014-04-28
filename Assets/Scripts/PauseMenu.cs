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
		}
}