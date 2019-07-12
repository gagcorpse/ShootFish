using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float playerSpeed;
	public float moveX;
	public GameObject bullet1;
	public GameObject shootingPoint;

	public SceneManagerScript sceneManagerScipt;
	//private int bulletsPlayer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();
		if (sceneManagerScipt.bulletsMain != 0) 
		{
			Shoot ();

		}
	}

	public void PlayerMove()
	{
		//двигаемся по у
		moveX=Input.GetAxis("Horizontal"); 
		gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2 (moveX*playerSpeed,gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
		
	public void Shoot()
	{
	//стреляем на пробел
	if (Input.GetButtonDown ("Jump"))
		{
			Instantiate (bullet1,shootingPoint.transform.position,Quaternion.identity);
			sceneManagerScipt.bulletsMain -= 1;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Coin") {
			//collision.gameObject.GetComponent<Rigidbody2D> ().simulated = false;	
			sceneManagerScipt.coinsMain += 1;
			Destroy (collision.gameObject, 0f);
		}

		if (collision.gameObject.tag == "Ammo") {	
			sceneManagerScipt.bulletsMain += sceneManagerScipt.ammoAmount;
			Destroy (collision.gameObject, 0f);
		}
	}
}
