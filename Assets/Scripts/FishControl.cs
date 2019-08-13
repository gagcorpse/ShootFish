using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishControl : MonoBehaviour {
	public GameObject sceneManagerScipt;
	public Sprite fishNormal;
	public Sprite fishGold;


	// Use this for initialization
	void Start () {
		sceneManagerScipt = GameObject.Find ("SceneManager");
	}
	
	// Update is called once per frame
	void Update () {
		FishDeath ();
		GoldFish ();
	}

	public void FishDeath()
	{
		if (sceneManagerScipt.GetComponent<SceneManagerScript>().livesMain == 0)
		{
			sceneManagerScipt.GetComponent<SceneManagerScript>().LooseGame ();
			//SceneManager.LoadScene ("MainScene");
			//sceneManagerScipt.canvas
		}
	}

	public void GoldFish(){
		if (sceneManagerScipt.GetComponent<SceneManagerScript>().isFishGold == true)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite = fishGold;
		}

		if (sceneManagerScipt.GetComponent<SceneManagerScript>().isFishGold == false)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite = fishNormal;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "WireDeath")
		{	
			sceneManagerScipt.GetComponent<SceneManagerScript>().livesMain -= 1;
			transform.position = new Vector2 (0,0);
		}

		if (collision.gameObject.tag == "Bird10")
		{	
			sceneManagerScipt.GetComponent<SceneManagerScript>().birdsToLevelCurr += 1;
			sceneManagerScipt.GetComponent<SceneManagerScript>().birdsAll+=1;
			sceneManagerScipt.GetComponent<SceneManagerScript>().scoreMain += 5;
			Destroy (collision.gameObject, 0f);
		}

		if (collision.gameObject.tag == "BonusBird1")
		{	
			sceneManagerScipt.GetComponent<SceneManagerScript>().birdsToLevelCurr += 5;
			sceneManagerScipt.GetComponent<SceneManagerScript>().birdsAll+=1;
			sceneManagerScipt.GetComponent<SceneManagerScript>().scoreMain += 50;
			Destroy (collision.gameObject, 0f);
		}
			
	}

	public void Spawn(){
		Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
		Instantiate (sceneManagerScipt.GetComponent<SceneManagerScript>().coin1, pos1, Quaternion.identity);
	}

	void DropRewards1()
	{
		for (int i = 0; i != sceneManagerScipt.GetComponent<SceneManagerScript>().goldFishCoinDrop; i++)
			{
				Spawn ();
			}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Bullet" && sceneManagerScipt.GetComponent<SceneManagerScript>().isFishGold==true)
		{	
			print ("GOLD");
			DropRewards1 ();
		}

	}


}
