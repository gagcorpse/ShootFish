using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishControl : MonoBehaviour {
	public SceneManagerScript sceneManagerScipt;
	public Sprite fishNormal;
	public Sprite fishGold;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FishDeath ();
		GoldFish ();
	}

	public void FishDeath()
	{
		if (sceneManagerScipt.livesMain == 0)
		{
			sceneManagerScipt.LooseGame ();
			//SceneManager.LoadScene ("MainScene");
			//sceneManagerScipt.canvas
		}
	}

	public void GoldFish(){
		if (sceneManagerScipt.isFishGold == true)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite = fishGold;
		}

		if (sceneManagerScipt.isFishGold == false)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite = fishNormal;
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
			sceneManagerScipt.birdsToLevelCurr += 1;
			sceneManagerScipt.birdsAll+=1;
			sceneManagerScipt.scoreMain += 5;
			Destroy (collision.gameObject, 0f);
		}

		if (collision.gameObject.tag == "BonusBird1")
		{	
			sceneManagerScipt.birdsToLevelCurr += 5;
			sceneManagerScipt.birdsAll+=1;
			sceneManagerScipt.scoreMain += 50;
			Destroy (collision.gameObject, 0f);
		}
			
	}

	public void Spawn(){
		Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
		Instantiate (sceneManagerScipt.coin1, pos1, Quaternion.identity);
	}

	void DropRewards1()
	{
			for (int i = 0; i != sceneManagerScipt.goldFishCoinDrop; i++)
			{
				Spawn ();
			}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Bullet" && sceneManagerScipt.isFishGold==true)
		{	
			print ("GOLD");
			DropRewards1 ();
		}

	}


}
