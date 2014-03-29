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
		public float secondsBetweenHealthChange;
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
		public GameObject completionMarker;
		public GameObject flock;
		public bool successfullyCompletedSwap = false;
		public bool tutorialMode;
		public bool birdCollided;
		public GameObject narrativeManager;
		public bool ignoreHealthChange = false;
		public bool succesfullyPassedVillage = false;
		public bool avoidanceLevel = false;
		public bool birdDiedOnCollision = false;
		public bool timeReset = false;
		public bool startHealthDecrement = false;
		public bool needsFadeToBlack;
		public GameObject fadeBlack;
		public bool fadeFromBlack;
		public AudioClip failure;
		public AudioClip success;
		public bool allowClickHasBeenTriggered = false;
		public bool villageAudioHasPlayed = false;
		public GameObject slowDownPoint;
		public GameObject camera;
		public float deltaT = 0;
		public float slowDownDuration = 60.0f;
		public bool slowing = false;
		public bool hasBeenLerped = false;
		public int currentLevel;
		public GameObject target;
		public GameObject targetIndicator;
		public float targetIndicatorYPosition;

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
				if (needsFadeToBlack == true) {
						fadeBlack.SetActive (true);
				}
		}

		public int getMiddle ()
		{
				return Mathf.Min (birds.Count / 2);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (tutorialMode == false) {
						if ((background.gameObject.transform.position.y <= slowDownPoint.gameObject.transform.position.y)) {
								if (hasBeenLerped != true) {
										if (!slowing) {
												StartCoroutine ("SlowBackground");
										}
										hasBeenLerped = true;
								} else {
										if (camera.GetComponent<MainCamera> ().movementSpeed <= 0.5) {
												print ("switching to next scene");
												fadeBlack.GetComponent<SceneFadeOutIn> ().EndScene (currentLevel + 1);
										}
								}
						}
				}

				if ((tutorialMode == true) && (avoidanceLevel == true)) {
						
						if ((background.gameObject.transform.position.y <= completionMarker.gameObject.transform.position.y) && (birdDiedOnCollision == false)) {
								print ("avoided obstacle");
								//cycle success text, then reset the counter to prepare to load new scene
								narrativeManager.GetComponent<NarrativeManager> ().ShowCollissionAvoidanceMessage ();
								succesfullyPassedVillage = true;
								if (villageAudioHasPlayed == false) {
										audio.PlayOneShot (success, 1);
										villageAudioHasPlayed = true;
								}
						}
				}

				if ((startHealthDecrement == false) && (time > 5.0f)) {
						narrativeManager.GetComponent<NarrativeManager> ().ClearMessages ();
						startHealthDecrement = true;
				}

				if ((startHealthDecrement == true) && (time > 2.0f)) {
						if (allowClickHasBeenTriggered == false) {
								bird0.GetComponent<Bird> ().AllowClick ();
								bird1.GetComponent<Bird> ().AllowClick ();
								bird2.GetComponent<Bird> ().AllowClick ();
								bird3.GetComponent<Bird> ().AllowClick ();
								bird4.GetComponent<Bird> ().AllowClick ();
								bird5.GetComponent<Bird> ().AllowClick ();
								bird6.GetComponent<Bird> ().AllowClick ();
								bird7.GetComponent<Bird> ().AllowClick ();
								bird8.GetComponent<Bird> ().AllowClick ();
								allowClickHasBeenTriggered = true;
						}
				}
		
		
				if (birds.Count % 2 == 0) {// Is even, because something divided by two without remainder is even, i.e 4/2 = 2, remainder 0
						middle = ((birds.Count / 2) - 1);
				} else {
						middle = (birds.Count / 2);
				}
	
				newBirdInFront = GameObject.Find ("Bird" + birdInFront);
				//Every few seconds, the changehealth function is called, then the timer is reset
				time = time + Time.deltaTime;
				if (tutorialMode == true) {
						if (startHealthDecrement == true) {
								if (time >= secondsBetweenHealthChange) {
										if (successfullyCompletedSwap == false) {
												if (succesfullyPassedVillage == false) {
														if (startHealthDecrement == true) {
																if (birdDiedOnCollision == false) {
																		ChangeHealth ();
																		time = 0;
																}
														}
												}
										}
								}
						}
				}
				
	

				if (tutorialMode == false) {
						if (time >= secondsBetweenHealthChange) {
								ChangeHealth ();
								time = 0;
						}
				}

				indexBird = GameObject.Find ("bird" + birdIndex);

				if (birds.Count == 1) {
						flockAudio.SetActive (false);
				}
				if (birds.Count == 0) {
						if (tutorialMode == false) {
								gameOver.SetActive (true);
						}
						flock.SetActive (false);
						waitTimer = waitTimer + Time.deltaTime;
						float waitTextTime = respawnTimeAfterDeath - waitTimer;
						respawnText.text = ("respawn in " + waitTextTime.ToString ("F0"));
						if (waitTimer >= respawnTimeAfterDeath) {
								print ("newlevelshouldappear");
								fadeBlack.GetComponent<SceneFadeOutIn> ().EndScene (2);
						}
				}

				if ((successfullyCompletedSwap == true) && (time > 5.0f)) {
						fadeBlack.GetComponent<SceneFadeOutIn> ().EndScene (3);
				}

				if ((birdDiedOnCollision == true) && (time > 5.0f)) {
						if (timeReset == false) {
								time = 0;
								timeReset = true;
								print ("time should have been reset");
						}
				}
		
				if ((succesfullyPassedVillage) && (time > 5.0f)) {
						if (timeReset == false) {
								time = 0;
								timeReset = true;
								print ("time should have been reset");
								audio.PlayOneShot (success, 1);

						}
				}

				if ((succesfullyPassedVillage == true) && (timeReset == true) && (time > 4.0f)) {
						fadeBlack.GetComponent<SceneFadeOutIn> ().EndScene (4);
				}

				if ((birdDiedOnCollision == true) && (timeReset == true) && (time > 4.0f)) {
						fadeBlack.GetComponent<SceneFadeOutIn> ().EndScene (3);
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

		public void SuccessfullyCompletedSwap ()
		{
				audio.PlayOneShot (success, 1);
				successfullyCompletedSwap = true;
		}

		public void BirdDiedOnCollision ()
		{
				birdDiedOnCollision = true;
				narrativeManager.GetComponent<NarrativeManager> ().ShowCollissionMessage ();
				audio.PlayOneShot (failure, 1);

		}

		public void AllowBirdsToBeClicked ()
		{
				bird0.GetComponent<Bird> ().AllowClick ();
				bird1.GetComponent<Bird> ().AllowClick ();
				bird2.GetComponent<Bird> ().AllowClick ();
				bird3.GetComponent<Bird> ().AllowClick ();
				bird4.GetComponent<Bird> ().AllowClick ();
				bird5.GetComponent<Bird> ().AllowClick ();
				bird6.GetComponent<Bird> ().AllowClick ();
				bird7.GetComponent<Bird> ().AllowClick ();
				bird8.GetComponent<Bird> ().AllowClick ();
		}

		private IEnumerator SlowBackground ()
		{
		
				print ("slowing has been called");
				float deltaT = 0;
		
				slowing = true;
				while (deltaT < slowDownDuration) {
						deltaT += Time.deltaTime;
						yield return true;
						camera.GetComponent<MainCamera> ().movementSpeed = Mathf.Lerp (camera.GetComponent<MainCamera> ().movementSpeed, 0.0f, deltaT / slowDownDuration);
						background.GetComponent<Background> ().movementSpeed = Mathf.Lerp (background.GetComponent<Background> ().movementSpeed, 0.0f, deltaT / slowDownDuration);
				}
				slowing = false;
		
		}

}

