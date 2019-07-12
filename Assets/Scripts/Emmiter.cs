using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmiter : MonoBehaviour {

	[Header("BonusBirds")]
	public GameObject bonusBird10;
	public GameObject birdBonus10_2;
	public bool isEmittingBonusBirds = true;

	[Header("BadBirds")]
	public GameObject badBird1;
	public bool isEmittingBadBirds = true;

	[Header("Birds Emitter")]
	public GameObject BirdsEmitterRightUp;
	public GameObject BirdsEmitterRightMiddle;
	public GameObject BirdsEmitterRightDown;
	public GameObject BirdsEmitterLeftUp;
	public GameObject BirdsEmitterLeftMiddle;
	public GameObject BirdsEmitterLeftDown;

	[Header("Birds Emitter Speed")]
	public float badBirdsEmitterSpeed;
	public float bonusBirdsEmitterSpeed;
	public float bonusBirds_2EmitterSpeed;


	// Use this for initialization
	void Start () {
		if (isEmittingBonusBirds == true) 
		{
			StartCoroutine (SpawnBonusBirds10 ());
			StartCoroutine (SpawnBonusBirds_2());
		}

		if (isEmittingBadBirds == true)
		{
			StartCoroutine (SpawnBadBirds ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnBonusBirds10(){
		for (;;) {
			yield return new WaitForSeconds (bonusBirdsEmitterSpeed);
			float rndLeftOrRight = Random.Range (1.0f, 3.0f);
		 	int rndIntLeftOrRight = (int)rndLeftOrRight;

			if (rndIntLeftOrRight == 1)
			{
				Vector2 pos1 = new Vector2 (BirdsEmitterRightUp.transform.position.x, Random.Range (BirdsEmitterRightUp.transform.position.y, BirdsEmitterRightDown.transform.position.y));
				Instantiate (bonusBird10, pos1, Quaternion.identity);
			}
			if (rndIntLeftOrRight == 2)
			{
				Vector2 pos2 = new Vector2 (BirdsEmitterLeftUp.transform.position.x, Random.Range (BirdsEmitterLeftUp.transform.position.y, BirdsEmitterLeftDown.transform.position.y));
				Instantiate (bonusBird10, pos2, Quaternion.identity);
			}
		}
	}

	//feoletovie
	IEnumerator SpawnBonusBirds_2(){
		for (;;) {
			yield return new WaitForSeconds (bonusBirds_2EmitterSpeed);
			float rndLeftOrRight = Random.Range (1.0f, 3.0f);
			int rndIntLeftOrRight = (int)rndLeftOrRight;

			if (rndIntLeftOrRight == 1) 
			{
				Vector2 pos1 = new Vector2 (BirdsEmitterRightUp.transform.position.x, Random.Range (BirdsEmitterRightUp.transform.position.y, BirdsEmitterRightMiddle.transform.position.y));
				Instantiate (birdBonus10_2, pos1, Quaternion.identity);
			}

			if (rndIntLeftOrRight == 2) 
			{
				Vector2 pos2 = new Vector2 (BirdsEmitterLeftUp.transform.position.x, Random.Range (BirdsEmitterLeftUp.transform.position.y, BirdsEmitterLeftMiddle.transform.position.y));
				Instantiate (birdBonus10_2, pos2, Quaternion.identity);
			}
		}
	}

		IEnumerator SpawnBadBirds(){
		for (;;) {
			yield return new WaitForSeconds (badBirdsEmitterSpeed);
			float rndLeftOrRight = Random.Range (1.0f, 3.0f);
			int rndIntLeftOrRight = (int)rndLeftOrRight;

			if (rndIntLeftOrRight == 1) 
			{
				Vector2 pos1 = new Vector2 (BirdsEmitterRightUp.transform.position.x, Random.Range (BirdsEmitterRightUp.transform.position.y, BirdsEmitterRightDown.transform.position.y));
				Instantiate (badBird1, pos1, Quaternion.identity);
			}

			if (rndIntLeftOrRight == 2) 
			{
				Vector2 pos2 = new Vector2 (BirdsEmitterLeftUp.transform.position.x, Random.Range (BirdsEmitterLeftUp.transform.position.y, BirdsEmitterLeftDown.transform.position.y));
				Instantiate (badBird1, pos2, Quaternion.identity);
			}

		}
	}
		
	}

