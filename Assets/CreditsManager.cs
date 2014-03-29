using UnityEngine;
using System.Collections;

public class CreditsManager : MonoBehaviour
{

		public GameObject camera;
		public GameObject bottomBounds;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (camera.transform.position.y <= bottomBounds.transform.position.y) {
						Application.LoadLevel (0);
				}
		}
}
