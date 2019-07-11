using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBonusScript_1 : MonoBehaviour {
	public SceneManagerScript sceneManagerScipt;
	public GameObject ManagerSciptObj;
	// Use this for initialization
	void Start () {
		ManagerSciptObj = GameObject.Find ("SceneManager");
		sceneManagerScipt = ManagerSciptObj.GetComponent<SceneManagerScript> ();

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
		Instantiate (sceneManagerScipt.coin1, pos1, Quaternion.identity);
	}

	public void SpawnAmmo1(){
		Vector2 pos1 = new Vector2 (transform.position.x,transform.position.y);
		Instantiate (sceneManagerScipt.ammo1, pos1, Quaternion.identity);
	}
		
	void DropRewards1()
	{
		float spwnRND = Random.Range (1.0f, 101.0f);
		int INTspnRND = (int)spwnRND;

		if (INTspnRND > 50) 
		{
			Spawn ();
		}

		if (INTspnRND < 50 && INTspnRND > 20) 
		{
			Spawn ();
			Spawn ();
		}
		if (INTspnRND < 20 && INTspnRND > 5) 
		{
			Spawn ();
			Spawn ();
			Spawn ();
			Spawn ();
			Spawn ();
		}
		if (INTspnRND < 5 && INTspnRND > 1) 
		{
			Spawn ();
			Spawn ();
			Spawn ();
			Spawn ();
			Spawn ();
			Spawn ();
			Spawn ();
			Spawn ();
			Spawn ();
			Spawn ();
		}
		float spwnRND2 = Random.Range (1.0f, 101.0f);
		int INTspnRND2 = (int)spwnRND2;

		if (INTspnRND2 > 85) 
		{
			SpawnAmmo1 ();
		}
	}
}
