using UnityEngine;
using System.Collections;

public class HealthIndicator : MonoBehaviour
{

		public GameObject bird;
		public float alphaValue;
		public Material red;
		public bool ChangeAlpha = false;
		public Color health10;
		public Color health9;
		public Color health8;
		public Color health7;
		public Color health6;
		public Color health5;
		public Color health4;
		public Color health3;
		public Color health2;
		public Color health1;




		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (bird.GetComponent<Bird> ().health > 90) {
						gameObject.renderer.material.SetColor ("_Color", health10);
				}

				if ((bird.GetComponent<Bird> ().health > 80) && (bird.GetComponent<Bird> ().health <= 90)) {
						gameObject.renderer.material.SetColor ("_Color", health9);
				}

				if ((bird.GetComponent<Bird> ().health > 70) && (bird.GetComponent<Bird> ().health <= 80)) {
						gameObject.renderer.material.SetColor ("_Color", health8);
				}

				if ((bird.GetComponent<Bird> ().health > 60) && (bird.GetComponent<Bird> ().health <= 70)) {
						gameObject.renderer.material.SetColor ("_Color", health7);
				}

				if ((bird.GetComponent<Bird> ().health > 50) && (bird.GetComponent<Bird> ().health <= 60)) {
						gameObject.renderer.material.SetColor ("_Color", health6);
				}

				if ((bird.GetComponent<Bird> ().health > 40) && (bird.GetComponent<Bird> ().health <= 50)) {
						gameObject.renderer.material.SetColor ("_Color", health5);
				}

				if ((bird.GetComponent<Bird> ().health > 30) && (bird.GetComponent<Bird> ().health <= 40)) {
						gameObject.renderer.material.SetColor ("_Color", health4);
				}

				if ((bird.GetComponent<Bird> ().health > 20) && (bird.GetComponent<Bird> ().health <= 30)) {
						gameObject.renderer.material.SetColor ("_Color", health3);
				}

				if ((bird.GetComponent<Bird> ().health > 10) && (bird.GetComponent<Bird> ().health <= 20)) {
						gameObject.renderer.material.SetColor ("_Color", health2);
				}

				if ((bird.GetComponent<Bird> ().health > 0) && (bird.GetComponent<Bird> ().health <= 10)) {
						gameObject.renderer.material.SetColor ("_Color", health1);
				}
		}
}