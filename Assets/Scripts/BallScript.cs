using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		if (gameObject.transform.position.x > 0) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 7000);
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 5000);
		}

		if (gameObject.transform.position.x < 0) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 7000);
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 5000);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		OnEnable ();
	}

	void OnEnable()
	{
		GameObject[] chickObj = GameObject.FindGameObjectsWithTag("Border");
		foreach (GameObject obj in chickObj) 
		{
			Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
		}

		GameObject[] billetObj = GameObject.FindGameObjectsWithTag("Bullet");
		foreach (GameObject obj in billetObj) 
		{
			Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
		}
	}
}
