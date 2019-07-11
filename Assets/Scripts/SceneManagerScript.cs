
using UnityEngine;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour {

	[Header("Scripts")]
	public BulletControlSCript bulletControlScript;
	public FishControl fishControl;
	public PlayerControl playerControl;
	public BirdBonusScript_1 birdBonusScript1;

	public GameObject bullets;
	public GameObject lives;
	public GameObject score;
	public GameObject coins;


	[Header("Counts")]
	public int bulletsMain;
	public int livesMain;
	public int scoreMain;
	public int coinsMain;

	[Header("Counts")]
	public GameObject coin1;
	public GameObject ammo1;





	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		UIBulletsManager ();
		UILivesManager ();
		UIScoreManager();
		UICoinManager ();
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
}
