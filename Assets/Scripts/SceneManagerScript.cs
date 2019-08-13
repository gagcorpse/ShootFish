using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour {

	[Header("Scripts")]
	public BulletControlSCript bulletControlScript;
	public FishControl fishControl;
	public PlayerControl playerControl;
	public BirdBonusScript_1 birdBonusScript1;
	public MagnetScript magnetScript;
	public Emmiter emmiter;

	public GameObject bullets;
	public GameObject lives;
	public GameObject score;
	public GameObject coins;

	[Header("Loose Window Counts")]
	public GameObject scoreLoose;
	public GameObject birdsLoose;
	public GameObject coinsLoose;


	[Header("Counts")]
	public int bulletsMain;
	public int livesMain;
	public int scoreMain;
	public int coinsMain;
	public int birdsAll=0;

	[Header("ItemsDropped")]
	public GameObject coin1;
	public GameObject ammo1;
	public GameObject magnet1;
	public GameObject fishmagnet1;
	public GameObject goldfish1;
	public int ammoAmount;
	public GameObject goldenrain1;

	[Header("Objects")]
	public GameObject player;
	public GameObject lefttopSP;
	public GameObject righttopSP;
	public GameObject canvas;

	[Header("Windows")]
	public GameObject canvasLooseWindow;
	public GameObject canvasMainWindow;

	[Header("Boosters")]
	public GameObject playerMagnet;
	public float magnetTime;
	public float magnetTime2;
	public GameObject fishMagnet;
	public float fishMagnetTime;
	public float fishMagnetTime2;
	public GameObject fish;
	public float goldFishTime;
	public float goldFishTime2;
	public bool isFishGold;
	public int goldFishCoinDrop;

	public int grMin;
	public int grMax;
	public float goldenRainTime;
	public float goldenRainTime2;
	public float grspeed;
	public float grspeed2;
	public bool isGoldenRainOn;
	public int birdsToLevelCurr;
	public int birdsToLevelMax;
	public int levelLevel;




	// Use this for initialization
	void Start () {
	Screen.SetResolution(600, 1000, false);

	}

	public void ThanksWindowButton(){
		canvasLooseWindow.SetActive (false);
		canvasMainWindow.SetActive (true);
	}

	public void RestartGame()
	{
		canvasMainWindow.SetActive (false);

		livesMain = 1;
		bulletsMain = 20;
		scoreMain = 0;
		coinsMain = 0;

		levelLevel = 1;
		birdsToLevelCurr = 0;


		Vector2 playerpos = new Vector2 (0, -4.5f);
		player.transform.position = playerpos;
		player.SetActive (true);

		Vector2 fishpos = new Vector2 (0, 0);
		fish.transform.position = fishpos;
		fish.SetActive (true);

		GameObject[] bird10 = GameObject.FindGameObjectsWithTag("Bird10");
		foreach (GameObject obj in bird10) 
		{
			Destroy (obj,0.0f);
		}

		GameObject[] birdBonus10_2 = GameObject.FindGameObjectsWithTag("BonusBird1");
		foreach (GameObject obj in birdBonus10_2) 
		{
			Destroy (obj,0.0f);
		}

		GameObject[] BadBird_1 = GameObject.FindGameObjectsWithTag("BadBird1");
		foreach (GameObject obj in BadBird_1) 
		{
			Destroy (obj,0.0f);
		}

			UIBulletsManager ();
			UILivesManager();
			UIScoreManager();
			UICoinManager();

	}

	public void LooseGame(){
		scoreLoose.GetComponent<Text>().text = "" + scoreMain;
		birdsLoose.GetComponent<Text>().text = "" + birdsAll;
		coinsLoose.GetComponent<Text>().text = "" +  coinsMain;

		player.SetActive (false);
		fish.SetActive (false);
		emmiter.isEmittingBadBirds = false;
		emmiter.isEmittingBonusBirds = false;

		canvasLooseWindow.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		UIBulletsManager ();
		UILivesManager ();
		UIScoreManager();
		UICoinManager ();
		MagnetActivation ();
		FishMagnetActivation ();
		GoldFishActivation ();
		GoldenRain ();
		CanvasLevel ();
	}

	public void CanvasLevel()
	{
		if (levelLevel==1)
		{
			birdsToLevelMax = 5;

			emmiter.badBirdsEmitterSpeed = 5.0f;
			emmiter.bonusBirdsEmitterSpeed = 2.5f;
			emmiter.bonusBirds_2EmitterSpeed= 8.0f;
			emmiter.ball1EmitterSpeed= 10.0f;

			canvas.GetComponentInChildren<Slider> ().value = birdsToLevelCurr;
			canvas.GetComponentInChildren<Slider> ().maxValue=birdsToLevelMax;

			if (birdsToLevelCurr >= birdsToLevelMax) {
				levelLevel = 2;
				birdsToLevelCurr = 0;
			}
		}
		if (levelLevel==2)
		{
			birdsToLevelMax = 10;

			emmiter.badBirdsEmitterSpeed = 4.5f;
			emmiter.bonusBirdsEmitterSpeed = 2.0f;
			emmiter.bonusBirds_2EmitterSpeed= 7.0f;
			emmiter.ball1EmitterSpeed= 9.0f;

			canvas.GetComponentInChildren<Slider> ().value = birdsToLevelCurr;
			canvas.GetComponentInChildren<Slider> ().maxValue=birdsToLevelMax;
			if (birdsToLevelCurr >= birdsToLevelMax) {
				levelLevel = 3;
				birdsToLevelCurr = 0;
			}
		}
		if (levelLevel==3)
		{
			birdsToLevelMax = 50;

			emmiter.badBirdsEmitterSpeed = 4.0f;
			emmiter.bonusBirdsEmitterSpeed = 1.8f;
			emmiter.bonusBirds_2EmitterSpeed= 6.5f;
			emmiter.ball1EmitterSpeed= 8.0f;

			canvas.GetComponentInChildren<Slider> ().value = birdsToLevelCurr;
			canvas.GetComponentInChildren<Slider> ().maxValue=birdsToLevelMax;
			if (birdsToLevelCurr >= birdsToLevelMax) {
				levelLevel = 4;
				birdsToLevelCurr = 0;
			}
		}
		if (levelLevel==4)
		{
			birdsToLevelMax = 100;

			emmiter.badBirdsEmitterSpeed = 3.7f;
			emmiter.bonusBirdsEmitterSpeed = 1.6f;
			emmiter.bonusBirds_2EmitterSpeed= 6.0f;
			emmiter.ball1EmitterSpeed= 7.5f;

			canvas.GetComponentInChildren<Slider> ().value = birdsToLevelCurr;
			canvas.GetComponentInChildren<Slider> ().maxValue=birdsToLevelMax;
			if (birdsToLevelCurr >= birdsToLevelMax) {
				levelLevel = 4;
				birdsToLevelCurr = 0;
			}
		}

		if (levelLevel==5)
		{
			birdsToLevelMax = 200;

			emmiter.badBirdsEmitterSpeed = 3.5f;
			emmiter.bonusBirdsEmitterSpeed = 1.4f;
			emmiter.bonusBirds_2EmitterSpeed= 5.5f;
			emmiter.ball1EmitterSpeed= 7.0f;

			canvas.GetComponentInChildren<Slider> ().value = birdsToLevelCurr;
			canvas.GetComponentInChildren<Slider> ().maxValue=birdsToLevelMax;
			if (birdsToLevelCurr >= birdsToLevelMax) {
				levelLevel = 6;
				birdsToLevelCurr = 0;
			}
		}

	}

	public void UIBulletsManager()
	{
		bullets.GetComponent<Text>().text="x"+bulletsMain;
	}


	public void UILivesManager()
	{
		lives.GetComponent<Text>().text="x"+livesMain;
	}

	public void UIScoreManager()
	{
		score.GetComponent<Text>().text="Score: "+scoreMain;
	}


	public void UICoinManager()
	{
		coins.GetComponent<Text>().text="x"+coinsMain;
	}

	public void MagnetActivation()
	{
		if (magnetTime > 0) { 
			magnetTime -= Time.deltaTime;
			playerMagnet.SetActive (true);
		}
		
		if (magnetTime <= 0) {
			magnetTime = 0;
			playerMagnet.SetActive (false);
		}
	}

	public void SetMagnetTime()
	{
		magnetTime = magnetTime2;
	}

	public void FishMagnetActivation()
	{
		if (fishMagnetTime > 0) { 
			fishMagnetTime -= Time.deltaTime;
			fishMagnet.SetActive (true);
		}

		if (fishMagnetTime <= 0) {
			fishMagnetTime = 0;
			fishMagnet.SetActive (false);
		}
	}

	public void SetFishMagnetTime()
	{
		fishMagnetTime = fishMagnetTime2;
	}



	public void GoldFishActivation()
	{
		if (goldFishTime > 0) { 
			goldFishTime -= Time.deltaTime;
			isFishGold = true;

		}

		if (goldFishTime <= 0) {
			goldFishTime = 0;
			isFishGold = false;
		}
	}

	public void SetGoldFishTime()
	{
		goldFishTime = goldFishTime2;
	}

	public void SetGoldenRainTime()
	{
		goldenRainTime = goldenRainTime2;
	}
		

	public void GoldenRain()
	{	
		if (goldenRainTime > 0) { 
			goldenRainTime -= Time.deltaTime;
			isGoldenRainOn = true;

		}

		if (goldenRainTime <= 0) {
			goldenRainTime = 0;
			isGoldenRainOn = false;
		}

		if (isGoldenRainOn == true) 
		{	
			if (grspeed <= 0)
			{ 
				for (int i = Random.Range (grMin, grMax); i >= 0; i--)
				{
					Vector2 pos1 = new Vector2 (Random.Range (lefttopSP.transform.position.x, righttopSP.transform.position.x), righttopSP.transform.position.y+1f);
					Instantiate (coin1, pos1, Quaternion.identity);
					//print (i);
				}
				grspeed = grspeed2;
			}
			grspeed -= Time.deltaTime;
		}
	}
}

