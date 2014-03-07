using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialManagerA : MonoBehaviour
{
		public GameObject letter0;
		public GameObject letter1;
		public GameObject letter2;
		public GameObject letter3;
		public GameObject letter4;
		public GameObject letter5;
		public GameObject letter6;
		public GameObject letter7;
		public GameObject letter8;
		public TextMesh letter0text;
		public TextMesh letter1text;
		public TextMesh letter2text;
		public TextMesh letter3text;
		public TextMesh letter4text;
		public TextMesh letter5text;
		public TextMesh letter6text;
		public TextMesh letter7text;
		public TextMesh letter8text;
		public int letterInFront;
		public GameObject newLetterInFront;
		public GameObject letterToMoveBack;
		public GameObject position0;
		public GameObject position1;
		public GameObject position2;
		public GameObject position3;
		public GameObject position4;
		public GameObject position5;
		public GameObject position6;
		public GameObject position7;
		public GameObject position8;
		public float time;
		public float secondsBetweenHealthChange = 5;
		public int letterIndex;
		public GameObject indexLetter;
		public AudioClip dead;
		public GameObject flockAudio;
		public List<GameObject> letters = new List<GameObject> ();
		public List<GameObject> availablePositions = new List<GameObject> ();
		public int middle;
		public int respawnTimeAfterDeath;
		public float waitTimer = 1;
		public TextMesh respawnText;
		public TextMesh instructionsText;
		public bool waitTimerHasBeenReset = false;
		public Color levelComplete;
		public Color deselectedColor;
		public Camera mainCamera;
		public float zoomedInCameraSize;
		public float zoomedOutCameraSize = 46;
		public float zoomedOutCameraSizeWithMove = 22;
		public string successText;
		public string introText1;
		public string introText2;

	
	
		public bool hasBeenLerped = false;
		public bool hasBeenFaded = false;

		public float lerpDuration = 2.0f;
		public float startTime;
		public float deltaT = 0;
		public float zoomDuration = 2.0f;
		public float fadeDuration = 2.0f;
		public bool zooming;
		public bool fading = false;
		public GameObject tutorialBackground;
		public GameObject cameraTarget;
		public float fadeTime;
		bool canSkipAhead = false;
		public AudioClip startled;

	
		// Use this for initialization
		void Start ()
		{
				instructionsText.text = (introText1);
				startTime = 0;
				zoomedInCameraSize = mainCamera.orthographicSize;
				letterInFront = 4;
				letters.Add (letter0);
				letters.Add (letter1);
				letters.Add (letter2);
				letters.Add (letter3);
				letters.Add (letter4);
				letters.Add (letter5);
				letters.Add (letter6);
				letters.Add (letter7);
				letters.Add (letter8);
				availablePositions.Add (position0);
				availablePositions.Add (position1);
				availablePositions.Add (position2);
				availablePositions.Add (position3);
				availablePositions.Add (position4);
				availablePositions.Add (position5);
				availablePositions.Add (position6);
				availablePositions.Add (position7);
				availablePositions.Add (position8);
				letter0.renderer.material.SetColor ("_Color", deselectedColor);
				letter1.renderer.material.SetColor ("_Color", deselectedColor);
				letter2.renderer.material.SetColor ("_Color", deselectedColor);
				letter3.renderer.material.SetColor ("_Color", deselectedColor);
				letter4.renderer.material.SetColor ("_Color", deselectedColor);
				letter5.renderer.material.SetColor ("_Color", deselectedColor);
				letter6.renderer.material.SetColor ("_Color", deselectedColor);
				letter7.renderer.material.SetColor ("_Color", deselectedColor);
				letter8.renderer.material.SetColor ("_Color", deselectedColor);
		}
	
		public int getMiddle ()
		{
				return Mathf.Min (letters.Count / 2);
		}
	
		// Update is called once per frame
		void Update ()
		{
				
				if (time >= 5.0f) {
						instructionsText.text = (introText2);

						if (Input.GetKeyDown (KeyCode.Space)) {
								instructionsText.gameObject.SetActive (false);
								audio.PlayOneShot (startled, 1);
								StartCoroutine ("MoveToV");
//								if (hasBeenFaded != true) {
//										if (!fading) {
//												StartCoroutine ("FadeOut", fadeDuration);
//					
//										}
//										hasBeenFaded = true;
//										waitTimer = 1;
//								}

								letter0text.text = ("T");
								letter1text.text = ("A");
								letter2text.text = ("R");
								letter3text.text = ("I");
								letter4text.text = ("G");
								letter5text.text = ("I");
								letter6text.text = ("N");
								letter7text.text = ("M");
								letter8text.text = ("O");
								canSkipAhead = true;
						}
						if (canSkipAhead == true) {
								waitTimer = waitTimer + Time.deltaTime;
						}
						if ((waitTimer > fadeDuration + 2) && (canSkipAhead == true)) {
								Application.LoadLevel (1);
						}
				}
		
				//				if (hasBeenFaded == true) {
//						letter0text.text = ("T");
//						letter1text.text = ("A");
//						letter2text.text = ("R");
//						letter3text.text = ("I");
//						letter4text.text = ("G");
//						letter5text.text = ("I");
//						letter6text.text = ("N");
//						letter7text.text = ("M");
//						letter8text.text = ("O");
//
//						waitTimer = waitTimer + Time.deltaTime;
//						if (waitTimer > 5) {
//								Application.LoadLevel (1);
//						}
//				}
			

				if (letters.Count % 2 == 0) {// Is even, because something divided by two without remainder is even, i.e 4/2 = 2, remainder 0
						middle = ((letters.Count / 2) - 1);
				} else {
						middle = (letters.Count / 2);
				}
		
				newLetterInFront = GameObject.Find ("Letter" + letterInFront);
				//Every few seconds, the changehealth function is called, then the timer is reset
				time = time + Time.deltaTime;
		
				indexLetter = GameObject.Find ("Letter" + letterIndex);
		
				if (letters.Count == 1) {
						flockAudio.SetActive (false);
				}
				if (letters.Count == 0) {
						float waitTextTime = respawnTimeAfterDeath - waitTimer;
						respawnText.text = ("respawn in " + waitTextTime.ToString ("F0"));
						if (waitTimer >= respawnTimeAfterDeath) {
								print ("newlevelshouldappear");
								Application.LoadLevel (0);
						}
				}
		
				if (((letter0.GetComponent<Letter> ().letterPosition == 5) && (letter1.GetComponent<Letter> ().letterPosition == 4) && (letter2.GetComponent<Letter> ().letterPosition == 3) && (letter3.GetComponent<Letter> ().letterPosition == 1) && (letter4.GetComponent<Letter> ().letterPosition == 2) && (letter5.GetComponent<Letter> ().letterPosition == 6) && (letter6.GetComponent<Letter> ().letterPosition == 8) && (letter7.GetComponent<Letter> ().letterPosition == 0) && (letter8.GetComponent<Letter> ().letterPosition == 7)) || (letter0.GetComponent<Letter> ().letterPosition == 5) && (letter1.GetComponent<Letter> ().letterPosition == 4) && (letter2.GetComponent<Letter> ().letterPosition == 3) && (letter3.GetComponent<Letter> ().letterPosition == 6) && (letter4.GetComponent<Letter> ().letterPosition == 2) && (letter5.GetComponent<Letter> ().letterPosition == 1) && (letter2.GetComponent<Letter> ().letterPosition == 3) && (letter6.GetComponent<Letter> ().letterPosition == 8) && (letter7.GetComponent<Letter> ().letterPosition == 0) && (letter8.GetComponent<Letter> ().letterPosition == 7)) {
						print ("challenge complete");		
						ChallengeComplete ();
						tutorialBackground.GetComponent<TutorialBackground> ().canMove = true;
			
				}
		}
	
		public void MoveLetterToFront (Letter letter, int spotVacated)
		{
				int middle = getMiddle ();
				letterIndex = letters.IndexOf (letter.gameObject);
				letter.SetPosition (middle);
				if (letterIndex != middle) {
						iTween.MoveTo (letters [letterIndex], iTween.Hash ("path", iTweenPath.GetPath (letterIndex + "to4"), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
				} else {
						iTween.MoveTo (letters [letterIndex], iTween.Hash ("path", iTweenPath.GetPath (spotVacated + "to4"), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
				}
				//spotVacated = birdIndex;
				MoveLetterToBack (letters [middle].GetComponent<Letter> (), spotVacated);
		
				//				MoveBirdToBack (bird, spotVacated);
				//				birdToMoveBack = bird;
				letterInFront = letterIndex;
		}
	
		public void ChallengeComplete ()
		{
				if (waitTimerHasBeenReset != true) {
						waitTimer = 1;
						waitTimerHasBeenReset = true;
				}
				if ((waitTimer > 2) && (waitTimer <= 2.2)) {
						instructionsText.text = (successText);
						ChangeColorToGreen ();
				} 
				if (waitTimer > 2.2) {
						DeselectColor ();
			
						if (hasBeenLerped != true) {
								if (!zooming) {
										StartCoroutine ("zoomOut");
					
								}
								hasBeenLerped = true;
						}
				}
		
		
		}
	
		//				Application.LoadLevel (1);
	
	
		public void DestroyLetter (GameObject letter, int spotVacated)
		{
				audio.PlayOneShot (dead, 1);
		
				//Remove dead bird from birds List
				letters.Remove (letter);
				//Check to see how many birds remain in list and remove positions according to pattern 
				//so that the positions at the rear are removed first and that the positions on the left are removed before positions on the right
		
				if (letters.Count == 8) {
						availablePositions.Remove (position0);
				}
				if (letters.Count == 7) {
						availablePositions.Remove (position8);
				}
				if (letters.Count == 6) {
						availablePositions.Remove (position1);
				}
				if (letters.Count == 5) {
						availablePositions.Remove (position7);
				}
				if (letters.Count == 4) {
						availablePositions.Remove (position2);
				}
				if (letters.Count == 3) {
						availablePositions.Remove (position6);
				}
				if (letters.Count == 2) {
						availablePositions.Remove (position3);
				}
				if (letters.Count == 1) {
						availablePositions.Remove (position5);
				}
				//for each bird that still exists in the list, 
				for (int i=0; i<letters.Count; i++) {
						if (availablePositions [i] != null) {
								iTween.MoveTo (letters [i].gameObject, iTween.Hash ("position", availablePositions [i].transform.position, "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
								letters [i].GetComponent<Letter> ().SetPosition (availablePositions [i].GetComponent<Position> ().positionNumber);
						}
						if (availablePositions [i] == position4) {
								letterInFront = letters [i].GetComponent<Letter> ().letterNumber;
						}
				}
		
				letterToMoveBack = letters [middle];
		}
	
		public void MoveLetterToBack (Letter letter, int vacatedPosition)
		//		public void MoveBirdToBack (int vacatedPosition)
		{
				print ("vacated position" + vacatedPosition);
				if (vacatedPosition != getMiddle ()) {
						iTween.MoveTo (newLetterInFront.gameObject, iTween.Hash ("path", iTweenPath.GetPath ("4to" + vacatedPosition), "easetype", iTween.EaseType.easeInOutSine, "time", 2f));
				} else {
						//do nothing because you can't click on the front bird
				}
				newLetterInFront.GetComponent<Letter> ().SetPosition (vacatedPosition);
		
				//				birds [middle].GetComponent<Bird> ().SetPosition (vacatedPosition);
				//birdToMoveBack = bird.gameObject;
				//				birds [getMiddle ()].GetComponent<Bird> ().SetPosition (vacatedPosition);
		
		}
	
		public void ChangeColorToGreen ()
		{
				letter0.renderer.material.SetColor ("_Color", levelComplete);
				letter1.renderer.material.SetColor ("_Color", levelComplete);
				letter2.renderer.material.SetColor ("_Color", levelComplete);
				letter3.renderer.material.SetColor ("_Color", levelComplete);
				letter4.renderer.material.SetColor ("_Color", levelComplete);
				letter5.renderer.material.SetColor ("_Color", levelComplete);
				letter6.renderer.material.SetColor ("_Color", levelComplete);
				letter7.renderer.material.SetColor ("_Color", levelComplete);
				letter8.renderer.material.SetColor ("_Color", levelComplete);
		}
	
		public void DeselectColor ()
		{
				letter0.renderer.material.SetColor ("_Color", deselectedColor);
				letter1.renderer.material.SetColor ("_Color", deselectedColor);
				letter2.renderer.material.SetColor ("_Color", deselectedColor);
				letter3.renderer.material.SetColor ("_Color", deselectedColor);
				letter4.renderer.material.SetColor ("_Color", deselectedColor);
				letter5.renderer.material.SetColor ("_Color", deselectedColor);
				letter6.renderer.material.SetColor ("_Color", deselectedColor);
				letter7.renderer.material.SetColor ("_Color", deselectedColor);
				letter8.renderer.material.SetColor ("_Color", deselectedColor);
		}
	
		private IEnumerator zoomOut ()
		{
				float deltaT = 0;
		
				zooming = true;
				while (deltaT < zoomDuration) {
						deltaT += Time.deltaTime;
						yield return true;
						Camera.main.orthographicSize = Mathf.Lerp (zoomedInCameraSize, zoomedOutCameraSize, deltaT / zoomDuration);
						//						mainCamera.transform.position = Vector3.Lerp (mainCamera.transform.position, cameraTarget.gameObject.transform.position, deltaT / zoomDuration);
				}
				zooming = false;
		}

		private IEnumerator FadeIn (float fadeInDuration)
		{
				print ("fade in has been called");

				float deltaT = 0;
		
				fading = true;
				while (deltaT < fadeDuration) {
						deltaT += Time.deltaTime;
						yield return true;
						iTween.FadeTo (letter0.gameObject, iTween.Hash ("alpha", 255, "time", fadeInDuration));
						iTween.FadeTo (letter1.gameObject, iTween.Hash ("alpha", 255, "time", fadeInDuration));
						iTween.FadeTo (letter2.gameObject, iTween.Hash ("alpha", 255, "time", fadeInDuration));
						iTween.FadeTo (letter3.gameObject, iTween.Hash ("alpha", 255, "time", fadeInDuration));
						iTween.FadeTo (letter4.gameObject, iTween.Hash ("alpha", 255, "time", fadeInDuration));
						iTween.FadeTo (letter5.gameObject, iTween.Hash ("alpha", 255, "time", fadeInDuration));
						iTween.FadeTo (letter6.gameObject, iTween.Hash ("alpha", 255, "time", fadeInDuration));
						iTween.FadeTo (letter7.gameObject, iTween.Hash ("alpha", 255, "time", fadeInDuration));
						iTween.FadeTo (letter8.gameObject, iTween.Hash ("alpha", 255, "time", fadeInDuration));
				}
				fading = false;
		}
		private IEnumerator FadeOut (float fadeOutDuration)
		{
				print ("fade out has been called");
				float deltaT = 0;

				fading = true;
				while (deltaT < fadeDuration) {
						deltaT += Time.deltaTime;
						yield return true;
						iTween.FadeTo (letter0.gameObject, iTween.Hash ("alpha", 0, "time", fadeOutDuration));
						iTween.FadeTo (letter1.gameObject, iTween.Hash ("alpha", 0, "time", fadeOutDuration));
						iTween.FadeTo (letter2.gameObject, iTween.Hash ("alpha", 0, "time", fadeOutDuration));
						iTween.FadeTo (letter3.gameObject, iTween.Hash ("alpha", 0, "time", fadeOutDuration));
						iTween.FadeTo (letter4.gameObject, iTween.Hash ("alpha", 0, "time", fadeOutDuration));
						iTween.FadeTo (letter5.gameObject, iTween.Hash ("alpha", 0, "time", fadeOutDuration));
						iTween.FadeTo (letter6.gameObject, iTween.Hash ("alpha", 0, "time", fadeOutDuration));
						iTween.FadeTo (letter7.gameObject, iTween.Hash ("alpha", 0, "time", fadeOutDuration));
						iTween.FadeTo (letter8.gameObject, iTween.Hash ("alpha", 0, "time", fadeOutDuration));
				}
				fading = false;
		}

		public  IEnumerator MoveToV ()
		{
				for (int i=0; i<letters.Count; i++) {
						print ("moving");
						iTween.MoveTo (letters [i].gameObject, iTween.Hash ("position", availablePositions [i].transform.position, "easetype", iTween.EaseType.easeInOutSine, "time", fadeDuration));
						yield return true;

				}
		}
	
}

