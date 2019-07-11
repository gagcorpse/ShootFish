﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishControl : MonoBehaviour {
	public SceneManagerScript sceneManagerScipt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FishDeath ();
	}

	public void FishDeath()
	{
		if (sceneManagerScipt.livesMain == 0)
		{
			SceneManager.LoadScene ("MainScene");
		}
	}

	void DropReward()
	{
		float spwnRND = Random.Range (1.0f, 101.0f);
		int INTspnRND = (int)spwnRND;

		if (INTspnRND > 10) 
		{
			Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
			Instantiate (sceneManagerScipt.coin1, pos1, Quaternion.identity);
			print ("hit");
		}

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "WireDeath")
		{	
			sceneManagerScipt.livesMain -= 1;
			transform.position = new Vector2 (0,0);
		}

		if (collision.gameObject.tag == "Bird10")
		{	
			sceneManagerScipt.scoreMain += 10;
			Destroy (collision.gameObject, 0f);
			DropReward ();
		}
	}
}