using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class TutorialManager : MonoBehaviour
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
		public GameObject gameOver;
		public GameObject flockAudio;
		public List<GameObject> letters = new List<GameObject> ();
		public List<GameObject> availablePositions = new List<GameObject> ();
		public int middle;
		public int respawnTimeAfterDeath;
		public float waitTimer = 1;
		public TextMesh respawnText;
	
	
		// Use this for initialization
		void Start ()
		{
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
		}
	
		public int getMiddle ()
		{
				return Mathf.Min (letters.Count / 2);
		}
	
		// Update is called once per frame
		void Update ()
		{
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
						gameOver.SetActive (true);
						waitTimer = waitTimer + Time.deltaTime;
						float waitTextTime = respawnTimeAfterDeath - waitTimer;
						respawnText.text = ("respawn in " + waitTextTime.ToString ("F0"));
						if (waitTimer >= respawnTimeAfterDeath) {
								print ("newlevelshouldappear");
								Application.LoadLevel (0);
						}
				}

				if ((letter0.GetComponent<Letter> ().letterPosition == 5) && (letter1.GetComponent<Letter> ().letterPosition == 4) && (letter2.GetComponent<Letter> ().letterPosition == 3) && (letter3.GetComponent<Letter> ().letterPosition == 1) && (letter4.GetComponent<Letter> ().letterPosition == 2) && (letter5.GetComponent<Letter> ().letterPosition == 6) && (letter2.GetComponent<Letter> ().letterPosition == 3) && (letter6.GetComponent<Letter> ().letterPosition == 8) && (letter7.GetComponent<Letter> ().letterPosition == 0) && (letter8.GetComponent<Letter> ().letterPosition == 7)) {
						ChallengeComplete ();
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
				Application.LoadLevel (1);
		}
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
}

