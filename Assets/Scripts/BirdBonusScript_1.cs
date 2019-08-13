using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBonusScript_1 : MonoBehaviour {
//	public SceneManagerScript sceneManagerScipt;
	//public GameObject ManagerSciptObj;

	[Header("Drop Rate")]
	public int percent50coinsdrop;
	public int percent30coinsdrop;
	public int percent15coinsdrop;
	public int percent5coinsdrop;
	public int ammodroprate;
	public int magnetdroprate;
	public int fishmagnetdroprate;
	public int goldfishdroprate;
	public int goldenraindroprate;

	public GameObject coin1;
	public GameObject ammo1;
	public GameObject magnet1;
	public GameObject fishmagnet1;
	public GameObject goldfish1;
	public GameObject goldenrain1;

	// Use this for initialization
	void Start () {
	//	ManagerSciptObj = GameObject.Find ("SceneManager");
	//	sceneManagerScipt = ManagerSciptObj.GetComponent<SceneManagerScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Chick")
		{	
				DropRewards1 ();
		}
	}
		

	public void Spawn(){
		Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
		Instantiate (coin1, pos1, Quaternion.identity);
	}

	public void SpawnAmmo1(){
		Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
		Instantiate (ammo1, pos1, Quaternion.identity);
	}

	public void SpawnMagnet1(){
		Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
		Instantiate (magnet1, pos1, Quaternion.identity);
	}

	public void SpawnFishMagnet1(){
		Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
		Instantiate (fishmagnet1, pos1, Quaternion.identity);
	}
		
	public void SpawnGoldFish1(){
		Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
		Instantiate (goldfish1, pos1, Quaternion.identity);
	}

	public void SpawnGoldenRain1(){
		Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
		Instantiate (goldenrain1, pos1, Quaternion.identity);
	}

	void DropRewards1()
	{
		float spwnRND = Random.Range (1.0f, 101.0f);
		int INTspnRND = (int)spwnRND;

		if (INTspnRND > 50) 
		{
		for (int i = 0; i != percent50coinsdrop; i++)
			{
			Spawn ();
			}
		}

		if (INTspnRND < 50 && INTspnRND > 20) 
		{
			for (int i = 0; i != percent30coinsdrop; i++)
			{
				Spawn ();
			}
		}
		if (INTspnRND < 20 && INTspnRND > 5) 
		{
			for (int i = 0; i != percent15coinsdrop; i++)
			{
				Spawn ();
			}
		}
		if (INTspnRND < 5 && INTspnRND > 1) 
		{
			for (int i = 0; i != percent5coinsdrop; i++)
			{
				Spawn ();
			}
		}

		float spwnRND2 = Random.Range (1.0f, 101.0f);
		int INTspnRND2 = (int)spwnRND2;
		if (INTspnRND2 <= (100-(100-ammodroprate))) 
		{
			SpawnAmmo1 ();
		}

		float spwnRND3 = Random.Range (1.0f, 101.0f);
		int INTspnRND3 = (int)spwnRND3;
		if (INTspnRND3 <= (100-(100-magnetdroprate))) 
		{
			SpawnMagnet1 ();
		}

		float spwnRND4 = Random.Range (1.0f, 101.0f);
		int INTspnRND4 = (int)spwnRND4;
		if (INTspnRND4 <= (100-(100-fishmagnetdroprate))) 
		{
			SpawnFishMagnet1 ();
		}

		float spwnRND5 = Random.Range (1.0f, 101.0f);
		int INTspnRND5 = (int)spwnRND5;
		if (INTspnRND5 <= (100-(100-goldfishdroprate))) 
		{
			SpawnGoldFish1 ();
		}

		float spwnRND6 = Random.Range (1.0f, 101.0f);
		int INTspnRND6 = (int)spwnRND6;
		if (INTspnRND6 <= (100-(100-goldenraindroprate))) 
		{
			SpawnGoldenRain1 ();
		}

	}
}
