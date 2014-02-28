using UnityEngine;
using System.Collections;

public class MusicAudio : MonoBehaviour
{
		private static MusicAudio instance = null;
		public static MusicAudio Instance {
				get { return instance; }
		}
		public AudioClip gameMusic;
		void Awake ()
		{
				if (instance != null && instance != this) {
						Destroy (this.gameObject);
						return;
				} else {
						instance = this;
				}
				DontDestroyOnLoad (this.gameObject);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
