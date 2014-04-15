using UnityEngine;
using System.Collections;

public class ReloadButton : MonoBehaviour
{

		public GameObject manager;
		public GameObject deselectedReloadButton;
		public GameObject selectedReloadButton;

		// Use this for initialization
		void Start ()
		{
				manager = GameObject.Find ("_Manager");
		}
	
		// Update is called once per frame
		void Update ()
		{
		}

		void OnMouseOver ()
		{
				selectedReloadButton.gameObject.renderer.enabled = false;
				deselectedReloadButton.gameObject.renderer.enabled = true;

				if ((Input.GetMouseButtonDown (0))) {
						Application.LoadLevel (manager.GetComponent<Manager> ().currentLevel);
				}
		}

		void OnMouseExit ()
		{
				selectedReloadButton.gameObject.renderer.enabled = true;
				deselectedReloadButton.gameObject.renderer.enabled = false;
		}
}
