using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour {

	public bool isActive;
	public float magnetRadius;
	public float magnetPower;

	// Use this for initialization
	void Start () 
	{
		isActive = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<CircleCollider2D> ().radius = magnetRadius;
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Coin" || collision.gameObject.tag == "Ammo")
		{	
			//collision.GetComponent<Rigidbody2D> ().collisionDetectionMode=
			float step = magnetPower * Time.deltaTime;
			collision.transform.position = Vector2.MoveTowards (collision.transform.position, transform.position, step);
		}
	}
}
