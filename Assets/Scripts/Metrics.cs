using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class Metrics : MonoBehaviour
{
		public bool madeItPastVillage = false;
		public int energyManagementTutorialAttempts;
		public int collissionAvoidancetTutorialAttempts;

	
		void Awake ()
		{
				DontDestroyOnLoad (this.gameObject);
		}
	
		// Metrics-Gathering Method by Riley Pietsch

		//IMPORTANT: You need to put "using System;" and "using System.IO;" at the top of your script!
		void OnApplicationQuit ()
		{
				string dateTime = System.DateTime.Now.ToString (); //Get the time to tack on to the file name
				dateTime = dateTime.Replace ("/", "-"); //Replace slashes with dashes, because Unity thinks they are directories..
				string fileName = "Metrics_" + dateTime;	 //Append file name
		
				//This is your main string output with all the data / variables that you want to save, plus accompanying text you want
//				string output = ("--Your Data-- \n " +
//						"Player Name: " + m_playerName + "\n " +
//						"Time to Complete: " + m_timeToComplete + "\n " +
//						"Number of deaths: " + m_deaths + "\n" + 
//						"Any other metric: " + m_timeInAir);

				string output = ("--Metric Data-- \n " +
						"Made it Past Village: " + madeItPastVillage + "\n" +
						"Energy Management Tutorial Attempts: " + energyManagementTutorialAttempts + "\n" +
						"Collission Avoidance Tutorial Attempts: " + collissionAvoidancetTutorialAttempts);
		
				//The "Metrics" folder in "Assets" needs to exist! Either create one or replace it with a name of another folder you have
				FileStream fs = File.Create ("Assets/Metrics/" + fileName + ".txt"); //Need to close this after so something else (StreamWriter) can access it
				fs.Close ();	//Close it!
				StreamWriter sw = new StreamWriter ("Assets/Metrics/" + fileName + ".txt");	//Create a StreamWriter which can write onto the file
				sw.WriteLine (output);	//Write line
				sw.Close ();	//Close access to file
		}
	
		//IMPORTANT: You need to put "using System;" and "using System.IO;" at the top of your script!

		public void MadeItPastVillage ()
		{
				madeItPastVillage = true;
		}

		public void IncrementEnergyManagementTutorialAttempts ()
		{
				energyManagementTutorialAttempts ++;
		}

		public void IncrementCollissionAvoidanceTutorialAttempts ()
		{
				collissionAvoidancetTutorialAttempts ++;
		}
}




