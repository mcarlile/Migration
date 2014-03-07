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
		public GameObject newBirdInFront;
		public GameObject birdToMoveBack;
		public GameObject position0;
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
		public int birdIndex;
		public GameObject indexBird;
		public AudioClip dead;
		public GameObject gameOver;
		public GameObject gameWon;
		public GameObject flockAudio;
		public List<GameObject> birds = new List<GameObject> ();
		public List<GameObject> availablePositions = new List<GameObject> ();
		public int middle;
		public int respawnTimeAfterDeath;
		public float waitTimer = 1;
		public TextMesh respawnText;
		public GameObject background;
		public GameObject finalMarker;
		public GameObject flock;


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
				availablePositions.Add (position0);
				availablePositions.Add (position1);
				availablePositions.Add (position2);
				availablePositions.Add (position3);
				availablePositions.Add (position4);
				availablePositions.Add (position5);
				availablePositions.Add (position6);
				availablePositions.Add (position7);
				availablePositions.Add (position8);
		}

		public int getMiddle ()
		{
				return Mathf.Min (birds.Count / 2);
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (background.gameObject.transform.position.y <= finalMarker.gameObject.transform.position.y) {
						gameWon.SetActive (true);
				}
				if (birds.Count % 2 == 0) {// Is even, because something divided by two without remainder is even, i.e 4/2 = 2, remainder 0
						middle = ((birds.Count / 2) - 1);
				} else {
						middle = (birds.Count / 2);
				}
	
				newBirdInFront = GameObject.Find ("Bird" + birdInFront);
				//Every few seconds, the changehealth function is called, then the timer is reset
				time = time + Time.deltaTime;
				if (time >= secondsBetweenHealthChange) {
						ChangeHealth ();
						time = 0;
				}

				indexBird = GameObject.Find ("bird" + birdIndex);

				if (birds.Count == 1) {
						flockAudio.SetActive (false);
				}
				if (birds.Count == 0) {
						gameOver.SetActive (true);
						flock.SetActive (false);
						waitTimer = waitTimer + Time.deltaTime;
						float waitTextTime = respawnTimeAfterDeath - waitTimer;
						respawnText.text = ("respawn in " + waitTextTime.ToString ("F0"));
						if (waitTimer >= respawnTimeAfterDeath) {
								print ("newlevelshouldappear");
								Application.LoadLevel (2);
						}
				}
		}

		void ChangeHealth ()
		{
				for (int i=0; i<birds.Count; i++) {
						if (birds [i] != null) {
								birds [i].gameObject.GetComponent<Bird> ().ChangeHealth ();
						}
				}
		}

		public void MoveBirdToFront (Bird bird, int spotVacated)
		{
				int middle = getMiddle ();
				birdIndex = birds.IndexOf (bird.gameObject);
				bird.SetPosition (middle);
				print ("bird position set to middle: " + middle);
				if (birdIndex != middle) {
						iTween.MoveTo (birds [birdIndex], iTween.Hash ("path", iTweenPath.GetPath (birdIndex + "to4"), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
				} else {
						iTween.MoveTo (birds [birdIndex], iTween.Hash ("path", iTweenPath.GetPath (spotVacated + "to4"), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
				}
				//spotVacated = birdIndex;
				MoveBirdToBack (birds [middle].GetComponent<Bird> (), spotVacated);

//				MoveBirdToBack (bird, spotVacated);
//				birdToMoveBack = bird;
				birdInFront = birdIndex;


				
		}

		/* old code from before meeting with iain
		public void MoveBirdToFront (int birdToMoveForward, int spotVacated)
		{
				bird.SetPosition(4);
				birds [birdToMoveForward].GetComponent<Bird> ().SetPosition (4);
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
//				birds [birdToMoveForward].GetComponent<Bird> ().SetPosition (4);
		}
		*/

		public void DestroyBird (GameObject bird, int spotVacated)
		{
				audio.PlayOneShot (dead, 0.1f);

				//Remove dead bird from birds List
				birds.Remove (bird);
//				birdToMoveBack = birds [getMiddle ()].GetComponent<Bird> ();
				//Check to see how many birds remain in list and remove positions according to pattern 
				//so that the positions at the rear are removed first and that the positions on the left are removed before positions on the right

				if (birds.Count == 8) {
						availablePositions.Remove (position0);
				}
				if (birds.Count == 7) {
						availablePositions.Remove (position8);
				}
				if (birds.Count == 6) {
						availablePositions.Remove (position1);
				}
				if (birds.Count == 5) {
						availablePositions.Remove (position7);
				}
				if (birds.Count == 4) {
						availablePositions.Remove (position2);
				}
				if (birds.Count == 3) {
						availablePositions.Remove (position6);
				}
				if (birds.Count == 2) {
						availablePositions.Remove (position3);
				}
				if (birds.Count == 1) {
						availablePositions.Remove (position5);
				}
				//for each bird that still exists in the list, 
				for (int i=0; i<birds.Count; i++) {
						if (availablePositions [i] != null) {
								iTween.MoveTo (birds [i].gameObject, iTween.Hash ("position", availablePositions [i].transform.position, "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
								birds [i].GetComponent<Bird> ().SetPosition (availablePositions [i].GetComponent<Position> ().positionNumber);
						}
						if (availablePositions [i] == position4) {
								birdInFront = birds [i].GetComponent<Bird> ().birdNumber;
						}
				}

				birdToMoveBack = birds [middle];
		} 

		public void MoveBirdToBack (Bird bird, int vacatedPosition)
//		public void MoveBirdToBack (int vacatedPosition)
		{
				print ("vacated position" + vacatedPosition);
				if (vacatedPosition != getMiddle ()) {
						
//						iTween.MoveTo (birds [birdInFront], iTween.Hash ("path", iTweenPath.GetPath ("4to" + vacatedPosition), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
//						iTween.MoveTo (bird.gameObject, iTween.Hash ("path", iTweenPath.GetPath ("4to" + vacatedPosition), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
						iTween.MoveTo (newBirdInFront.gameObject, iTween.Hash ("path", iTweenPath.GetPath ("4to" + vacatedPosition), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));

//						iTween.MoveTo (birdToMoveBack.gameObject, iTween.Hash ("path", iTweenPath.GetPath ("4to" + vacatedPosition), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));

				} else {
						//do nothing because you can't click on the front bird
				}
				newBirdInFront.GetComponent<Bird> ().SetPosition (vacatedPosition);

//				birds [middle].GetComponent<Bird> ().SetPosition (vacatedPosition);
				//birdToMoveBack = bird.gameObject;
//				birds [getMiddle ()].GetComponent<Bird> ().SetPosition (vacatedPosition);

		}
}

