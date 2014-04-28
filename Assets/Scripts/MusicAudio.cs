using UnityEngine;
using System.Collections;

public class MusicAudio : MonoBehaviour
{
		public GameObject track1;
		public GameObject track2;
		public GameObject track3;
		public GameObject track4;
		public GameObject track5;
		public bool playTrack1;
		public bool playTrack2;
		public bool playTrack3;
		public bool playTrack4;
		public bool playTrack5;
		public bool fadeAudio;
		bool hasBeenTweened;
		public GameObject audio;
		public float audioFadeSpeed;

	
	
		void Awake ()
		{
				audio = this.gameObject;
				DontDestroyOnLoad (this.gameObject);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (playTrack1 == true) {
						PlayTrack1 ();
						playTrack2 = false;
						playTrack3 = false;
						playTrack4 = false;
						playTrack5 = false;
				} else {
						track1.audio.volume = 0;
				}
		
				if (playTrack2 == true) {
						PlayTrack2 ();
						playTrack1 = false;
						playTrack3 = false;
						playTrack4 = false;
						playTrack5 = false;
				} else {
						track2.audio.volume = 0;
				}
		
				if (playTrack3 == true) {
						PlayTrack3 ();
						playTrack2 = false;
						playTrack1 = false;
						playTrack4 = false;
						playTrack5 = false;
				} else {
						track3.audio.volume = 0;
				}
		
				if (playTrack4 == true) {
						PlayTrack4 ();
						playTrack2 = false;
						playTrack3 = false;
						playTrack1 = false;
						playTrack5 = false;
				} else {
						track4.audio.volume = 0;
				}
		
				if (playTrack5 == true) {
						PlayTrack5 ();
						playTrack2 = false;
						playTrack3 = false;
						playTrack4 = false;
						playTrack1 = false;
				} else {
						track5.audio.volume = 0;
				}

				if (fadeAudio == true) {
						if (hasBeenTweened == false) {
								iTween.AudioTo (track1, iTween.Hash ("volume", 0.0f, "pitch", 1.0f, "time", audioFadeSpeed, "oncomplete", "MuteAudio", "oncompletetarget", audio));
								iTween.AudioTo (track2, iTween.Hash ("volume", 0.0f, "pitch", 1.0f, "time", audioFadeSpeed, "oncomplete", "MuteAudio", "oncompletetarget", audio));
								iTween.AudioTo (track3, iTween.Hash ("volume", 0.0f, "pitch", 1.0f, "time", audioFadeSpeed, "oncomplete", "MuteAudio", "oncompletetarget", audio));
								iTween.AudioTo (track4, iTween.Hash ("volume", 0.0f, "pitch", 1.0f, "time", audioFadeSpeed, "oncomplete", "MuteAudio", "oncompletetarget", audio));
								iTween.AudioTo (track5, iTween.Hash ("volume", 0.0f, "pitch", 1.0f, "time", audioFadeSpeed, "oncomplete", "MuteAudio", "oncompletetarget", audio));
								hasBeenTweened = true;
						}
				}
		}
	
	
		public void PlayTrack1 ()
		{
				playTrack1 = true;
				playTrack2 = false;
				playTrack3 = false;
				playTrack4 = false;
				playTrack5 = false;
		
				if (fadeAudio == false) {
						track1.audio.volume = 1;
				}
				track2.audio.volume = 0;
				track3.audio.volume = 0;
				track4.audio.volume = 0;
				track5.audio.volume = 0;
				print ("playtrack1 was triggered");

		}
	
		public void PlayTrack2 ()
		{
				playTrack1 = false;
				playTrack2 = true;
				playTrack3 = false;
				playTrack4 = false;
				playTrack5 = false;
				track1.audio.volume = 0;
				if (fadeAudio == false) {
						track2.audio.volume = 1;
				}
				track3.audio.volume = 0;
				track4.audio.volume = 0;
				track5.audio.volume = 0;
				print ("playtrack2 was triggered");
		}
	
		public void PlayTrack3 ()
		{
				playTrack1 = false;
				playTrack2 = false;
				playTrack3 = true;
				playTrack4 = false;
				playTrack5 = false;
				track1.audio.volume = 0;
				track2.audio.volume = 0;
				if (fadeAudio == false) {
						track3.audio.volume = 1;
				}
				track4.audio.volume = 0;
				track5.audio.volume = 0;
		}
	
		public void PlayTrack4 ()
		{
				playTrack1 = false;
				playTrack2 = false;
				playTrack3 = false;
				playTrack4 = true;
				playTrack5 = false;
				track1.audio.volume = 0;
				track2.audio.volume = 0;
				track3.audio.volume = 0;
				if (fadeAudio == false) {
						track4.audio.volume = 1;
				}
				track5.audio.volume = 0;
		}
	
		public void PlayTrack5 ()
		{
				playTrack1 = false;
				playTrack2 = false;
				playTrack3 = false;
				playTrack4 = false;
				playTrack5 = true;
				track1.audio.volume = 0;
				track2.audio.volume = 0;
				track3.audio.volume = 0;
				track4.audio.volume = 0;
				if (fadeAudio == false) {
						track5.audio.volume = 1;
				}
		}
	
		public void MuteAudio ()
		{
//				print ("muted audio");
//				track1.audio.volume = 0;
//				track2.audio.volume = 0;
//				track3.audio.volume = 0;
//				track4.audio.volume = 0;
//				track5.audio.volume = 0;
		}

		public void FadeAudio ()
		{
				fadeAudio = true;
		}
}
