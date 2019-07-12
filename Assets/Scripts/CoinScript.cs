using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
		CoinSpawnJump ();
		Destroy (gameObject, 3);
	}

	// Update is called once per frame
	void FixedUpdate () {
		OnEnable ();
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

	void CoinSpawnJump(){
		float rndRightSpeed = Random.Range (1300.0f, -1300.0f);
		int intrndRightSpeed = (int)rndRightSpeed;

		float rndUpSpeed = Random.Range (1000.0f, 1800.0f);
		int intrndUpSpeed = (int)rndUpSpeed;

		gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * intrndRightSpeed);
		gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * intrndUpSpeed);
	}
}
