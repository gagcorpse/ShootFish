using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBirdScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bird10") {	
			Destroy (collision.gameObject, 0);
		}

		if (collision.gameObject.tag == "BonusBird1") {	
			Destroy (collision.gameObject, 0);
		}

		if (collision.gameObject.tag == "Chick") {	
			collision.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 1500);
			collision.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1500);
		}
	}
}
