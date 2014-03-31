using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

		public float time;
		public float advanceLevelTime;
		public GameObject fadeBlack;
		public int levelToAdvanceTo;

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
				}

		}
}
