using System.Collections;
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



	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "WireDeath")
		{	
			sceneManagerScipt.livesMain -= 1;
			transform.position = new Vector2 (0,0);
		}

		if (collision.gameObject.tag == "Bird10")
		{	
			sceneManagerScipt.scoreMain += 5;
			Destroy (collision.gameObject, 0f);
		}

		if (collision.gameObject.tag == "BonusBird1")
		{	
			sceneManagerScipt.scoreMain += 50;
			Destroy (collision.gameObject, 0f);
		}
	}


}
