using UnityEngine;
using System.Collections;

public class A_Bird : MonoBehaviour {
	
//	public GameObject prefab;
//	GameObject flock = Instantiate(prefab);


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
	
	void OnTriggerEnter(Collider collision) {
		
		if (collision.gameObject.name.Contains("Obsticle")) {
			Debug.Log("Hit obsticle"); 
			Destroy(gameObject);


		}


		if (collision.name.Contains("EndGame")) {

		}
		
	}
}
