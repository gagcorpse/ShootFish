using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyScript : MonoBehaviour {

	public float birdFlySpeed;
	public bool isLeft;
	public Emmiter emitter;
	public int birdNumTag;

	// Use this for initialization
	void Start () {
		if (transform.position.x == emitter.BirdsEmitterRightDown.transform.position.x) {
			isLeft = false;
		} else {
			isLeft = true;
		}

		if (gameObject.tag == "BadBird1") {
			birdFlySpeed = 5;
		}

		if (gameObject.tag == "Bird10")
			birdFlySpeed = Random.Range(2.0f,2.8f);

		if (gameObject.tag == "BonusBird1")
			birdFlySpeed = Random.Range(1.5f,3.8f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isLeft == false) {
			BirdMoveRightToLeft ();
		} else {
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			BirdMoveLeftToRight ();
		}

	DestroyBird ();
	}

	public void BirdMoveRightToLeft()
	{
		transform.Translate(Vector3.left * birdFlySpeed * Time.deltaTime);
	}

	public void BirdMoveLeftToRight()
	{
		transform.Translate(Vector3.right * birdFlySpeed * Time.deltaTime);
	}

	public void DestroyBird(){
		if (transform.position.x > emitter.BirdsEmitterRightDown.transform.position.x)
			Destroy (gameObject,0);
		if (transform.position.x < emitter.BirdsEmitterLeftDown.transform.position.x)
			Destroy (gameObject,0);
	}


	}

