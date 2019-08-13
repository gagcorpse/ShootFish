using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour {

	public float magnetRadius;
	public float magnetPower;
	public SceneManagerScript sceneManagerScript;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<CircleCollider2D> ().radius = magnetRadius;

	}

	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Coin" || collision.gameObject.tag == "Ammo" || collision.gameObject.tag == "Magnet")
		{	
			float step = magnetPower * Time.deltaTime;
			collision.transform.position = Vector2.MoveTowards (collision.transform.position, transform.position, step);
		}
	}
}
