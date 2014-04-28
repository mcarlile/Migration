using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{

		public int trackToPlay;
		public GameObject audio;
		public GameObject gameAudio;

	
		// Use this for initialization
		void Start ()
		{
				if ((GameObject.Find ("Audio") == null) || (GameObject.Find ("Audio (Track 2)(Clone)") == null) || (GameObject.Find ("Audio (Track3)(Clone)") == null) || (GameObject.Find ("Audio (Track4)(Clone)") == null) || (GameObject.Find ("Audio (Track5)(Clone)") == null)) {
//						Instantiate (gameAudio);		
						audio = GameObject.Find ("Audio(Clone)");

				}
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
