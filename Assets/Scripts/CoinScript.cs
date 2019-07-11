using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	public int coinValue;

	// Use this for initialization
	void Start () {
		float rndLeftOrRight = Random.Range (1.0f, 3.0f);
		int rndIntLeftOrRight = (int)rndLeftOrRight;

		if (rndIntLeftOrRight == 1) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 1000);
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1300);
		}

		if (rndIntLeftOrRight == 2) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 1000);
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1300);
		}
	}
	
	// Update is called once per frame
	void Update () {
		OnEnable ();
	}

	void IgnoreObjects(){
		
	}

	void OnEnable()
	{
		GameObject[] chickObj = GameObject.FindGameObjectsWithTag("Chick");
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
