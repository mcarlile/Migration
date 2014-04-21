using UnityEngine;
using System.Collections;

public class NarrativeManager : MonoBehaviour
{

		public TextMesh NarrativeText;
		public string text1;
		public string text2;
		public string text3;
		public string text4;
		public string text5;
		public string text6;
		public AudioClip failure;
		public AudioClip success;


		// Use this for initialization
		void Start ()
		{
				NarrativeText.text = text1;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void ShowLowHealthMessage ()
		{
				NarrativeText.text = text2;
		}

		public void ShowSwapSuccessMessage ()
		{
				NarrativeText.text = text3;
		}

		public void ShowDeathMessage ()
		{
				NarrativeText.text = text4;
				audio.PlayOneShot (failure, 1);
				print ("failure should have played");


		}

		public void ShowCollissionMessage ()
		{
				NarrativeText.text = text5;
				audio.PlayOneShot (failure, 1);
				print ("failure should have played");

		}

		public void ShowCollissionAvoidanceMessage ()
		{
				NarrativeText.text = text6;
		}

		public void ClearMessages ()
		{
				NarrativeText.text = " ";
		}
}

