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
	
		void Awake ()
		{
		
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
						print ("playing track 1");
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
		}
	
	
		public void PlayTrack1 ()
		{
				playTrack1 = true;
				playTrack2 = false;
				playTrack3 = false;
				playTrack4 = false;
				playTrack5 = false;
		
		
				track1.audio.volume = 1;
				track2.audio.volume = 0;
				track3.audio.volume = 0;
				track4.audio.volume = 0;
				track5.audio.volume = 0;
		}
	
		public void PlayTrack2 ()
		{
				playTrack1 = false;
				playTrack2 = true;
				playTrack3 = false;
				playTrack4 = false;
				playTrack5 = false;
				track1.audio.volume = 0;
				track2.audio.volume = 1;
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
				track3.audio.volume = 1;
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
				track4.audio.volume = 1;
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
				track4.audio.volume = 1;
				track5.audio.volume = 0;
		}
}
