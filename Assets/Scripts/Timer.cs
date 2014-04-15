using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

		public float time;
		public float advanceLevelTime;
		public GameObject fadeBlack;
		public int levelToAdvanceTo;
		public bool startNextLevel = false;
		public bool timeHasBeenReset = false;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				time = time + Time.deltaTime;
				if (time >= advanceLevelTime) {
						fadeBlack.GetComponent<SceneFadeOutIn> ().EndScene (levelToAdvanceTo);
						print ("advancing to next level");

				}

				if (startNextLevel == true) {
						if (timeHasBeenReset == false) {
								time = 0;
								timeHasBeenReset = true;
						}
						fadeBlack.GetComponent<SceneFadeOutIn> ().EndScene (levelToAdvanceTo);
						if ((time > advanceLevelTime + 2) && (timeHasBeenReset == true)) {
								Application.LoadLevel (levelToAdvanceTo);
						}
						
				}

		}
}
