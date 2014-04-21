using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{

		public int trackToPlay;
		public GameObject audio;
	
		// Use this for initialization
		void Start ()
		{
				audio = GameObject.Find ("Audio");

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (audio != null) {
						if (trackToPlay == 2) {
								audio.GetComponent<MusicAudio> ().PlayTrack2 ();
						}
						if (trackToPlay == 3) {
								audio.GetComponent<MusicAudio> ().PlayTrack3 ();
						}
						if (trackToPlay == 4) {
								audio.GetComponent<MusicAudio> ().PlayTrack4 ();
						}
						if (trackToPlay == 5) {
								audio.GetComponent<MusicAudio> ().PlayTrack5 ();
						}
				}
		}
}
