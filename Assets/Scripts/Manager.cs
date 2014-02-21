using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Manager : MonoBehaviour
{
		public GameObject bird0;
		public GameObject bird1;
		public GameObject bird2;
		public GameObject bird3;
		public GameObject bird4;
		public GameObject bird5;
		public GameObject bird6;
		public GameObject bird7;
		public GameObject bird8;
		public int birdInFront;
		public GameObject position1;
		public GameObject position2;
		public GameObject position3;
		public GameObject position4;
		public GameObject position5;
		public GameObject position6;
		public GameObject position7;
		public GameObject position8;
		public GameObject position9;
		public float time;
		public float secondsBetweenHealthChange = 5;
		List<GameObject> birds = new List<GameObject> ();

		// Use this for initialization
		void Start ()
		{
				birdInFront = 4;
				birds.Add (bird0);
				birds.Add (bird1);
				birds.Add (bird2);
				birds.Add (bird3);
				birds.Add (bird4);
				birds.Add (bird5);
				birds.Add (bird6);
				birds.Add (bird7);
				birds.Add (bird8);
		}
	
		// Update is called once per frame
		void Update ()
		{
				//Every few seconds, the changehealth function is called, then the timer is reset
				time = time + Time.deltaTime;
				if (time >= secondsBetweenHealthChange) {
						ChangeHealth ();
						time = 0;
				}
		}

		void ChangeHealth ()
		{
				for (int i=0; i<birds.Count; i++) {
						birds [i].gameObject.GetComponent<Bird> ().ChangeHealth ();
				}
		}

		public void MoveBirdToFront (int birdToMoveForward, int spotVacated)
		{
				if (birdToMoveForward != 4) {
						iTween.MoveTo (birds [birdToMoveForward], iTween.Hash ("path", iTweenPath.GetPath (birdToMoveForward + "to4"), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
				} else {
//						if (spotVacated = 0) {
						iTween.MoveTo (birds [birdToMoveForward], iTween.Hash ("path", iTweenPath.GetPath (spotVacated + "to4"), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
//						}
						//iTween.MoveTo (birds [birdToMoveForward], iTween.Hash ("position", position5.transform.position, "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
				}
				MoveBirdToBack (spotVacated);
				birdInFront = birdToMoveForward;
				birds [birdToMoveForward].GetComponent<Bird> ().SetPosition (4);
		}
	
		public void MoveBirdToBack (int vacatedPosition)
		{
				if (vacatedPosition != 4) {
						iTween.MoveTo (birds [birdInFront], iTween.Hash ("path", iTweenPath.GetPath ("4to" + vacatedPosition), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
				} else {
						//do nothing because you can't click on the front bird
				}

				birds [birdInFront].GetComponent<Bird> ().SetPosition (vacatedPosition);
		}
}