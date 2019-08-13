using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetFishScript : MonoBehaviour {

	public float magnetRadius;
	public float magnetPower;
	public SceneManagerScript sceneManagerScript;
	public GameObject fish;


	// Use this for initialization
	void Start () 
	{
		fish = GameObject.Find ("chick1");
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 fishPos = fish.transform.position;
		gameObject.transform.position = fishPos;
		GetComponent<CircleCollider2D> ().radius = magnetRadius;

	}

	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bird10" || collision.gameObject.tag == "BonusBird1")
		{	
			float step = magnetPower * Time.deltaTime;
			collision.transform.position = Vector2.MoveTowards (collision.transform.position, fish.transform.position, step);
		}
	}
}
