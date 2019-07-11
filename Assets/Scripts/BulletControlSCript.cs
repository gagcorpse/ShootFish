using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControlSCript : MonoBehaviour {
	public float bulletSpeed;
	public Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		BulletMove ();
		Destroy (gameObject,1);
	}

	public void BulletMove()
	{
		rb.velocity = new Vector2 (0,bulletSpeed);
	}
		
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Chick")
		{	
			Destroy (gameObject,0.01f);
		}

	}
}
