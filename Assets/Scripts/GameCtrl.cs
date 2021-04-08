using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
/// <summary>
/// Managing the GamePLAY features like keeping the score,
/// restarting levels, Saving ,Loading data .updating the HUD etc..
///</summary>
public class GameCtrl : MonoBehaviour {
	public static GameCtrl instance;
	public Transform grayEnemy1, grayEnemy2;
	public GameData data;
	private GameObject player;
	public GameObject currentCheckPoint;
    public GameObject simpler;
	public Transform newPos;
	public GameObject bigPrize;
	public int gemValue;
	public int magicBottleValue;
	public int EnemyValue;
	public bool soundOn;
	public bool appearBossIsDied;
	public float restartDelay;
	public float MaxTime;
    public Transform pos;
    float TimeLeft;
	BinaryFormatter bf;
   

	string dataFilePath;

	public UI ui;
	bool timeOver;

	public enum Item
	{
		Gem,
		MagicBottle,
		Enemy
	}


	void Awake(){
		if (instance == null) {
			instance = this;
			bf = new BinaryFormatter ();
			dataFilePath = Application.persistentDataPath + "/game.bat";
		}
	}
		
	// Use this for initialization
	void Start () {
		soundOn = true;
		player = GameObject.FindGameObjectWithTag ("Player") as GameObject;
        //ui.coinText = GameObject.Find("CoinTxt") as GameObject;
        //		diedCollider.GetComponent<Collider2D> ().enabled = false;
        UpdateHearts ();
		TimeLeft = MaxTime;
		//ui.pausePanel.SetActive (false);
	}

	// Update is called once per frame
	void Update () { 
		if (TimeLeft > 0)
			UpdateTimer ();
		


		if(Input.GetKeyDown(KeyCode.Escape)){
		//	ResetData ();
		}
       
	}

	public void UpdateBulletCount(){
		data.bulletCounter += 1;
		ui.bulletText.text = " " + data.bulletCounter;
	//	ui.totalGemText.text = "   " + data.gemCounter;
	}
    public void UpdateCionCount()
    {
        data.coinCounter += 1;
        ui.coinText.text = " " + data.coinCounter;
        //	ui.totalGemText.text = "   " + data.gemCounter;
    }

    public void UpdateBigPrizeCount(){
		data.bulletCounter += 5;
		ui.bulletText.text = " " + data.bulletCounter;
		 //	ui.totalGemText.text = "   " + data.gemCounter;
	 }

	void SaveData(){
		FileStream fs = new FileStream (dataFilePath,FileMode.Create);
		bf.Serialize (fs,data);
		fs.Close ();
	}

	void LoadData(){
		if(File.Exists(dataFilePath)){
			FileStream fs = new FileStream (dataFilePath,FileMode.Open);
			data = (GameData)bf.Deserialize (fs);
			ui.bulletText.text = " " + data.bulletCounter;
            ui.coinText.text = " " + data.coinCounter;
            ui.sodierText.text = "" + data.soldeirCounter;
			ui.magicBottleText.text = " " + data.magicBottleCounter;
			ui.livesText.text = "x" + data.lives;
			//ui.totalGemText.text = "   " + data.gemCounter;
			//ui.totalMagicBottleText.text = "   " + data.magicBottleCounter;
			fs.Close ();
		}
	}
    
    //	public void UpdateGemCount(){
    //		data.gemCounter += 1;
    //		ui.gemText.text = "X " + data.gemCounter;
    //		ui.totalGemText.text = "   " + data.gemCounter;
    //	}
    //	public void UpdateScore(Item item){
    //		int itemVlaue = 0;
    //		switch (item) {
    //		case Item.Gem:
    //			itemVlaue = gemValue;
    //			break;
    //		case Item.MagicBottle:
    //			itemVlaue = magicBottleValue;
    //			break;
    //		case Item.Enemy:
    //			itemVlaue = EnemyValue;
    //			break;
    //		default:
    //			break;
    //		}
    //
    //		data.Score += itemVlaue;
    //
    //	}

    void UpdateTimer(){
		TimeLeft -= Time.deltaTime;
		ui.timerText.text=" "+(int)TimeLeft;

		if (TimeLeft <= 0) {
			timeOver = true;
			ui.timerText.text = " 0";
			//GameOver ();
			ActiveTimeAdsPanel();
		}
	}

	public void UpdateMagicBottleCount(){
		data.magicBottleCounter += 1;
		ui.magicBottleText.text = " " + data.magicBottleCounter;
		//ui.totalMagicBottleText.text = "   " + data.magicBottleCounter;
	}

	public void UpdateHeartCount(){
        print("lives jjhjhj");
        if ((data.lives <= 2 && data.subLives < 3) || (data.lives <= 1 && data.subLives ==3)) {
            print("lives");
			data.subLives += 1;
			UpdateHearts ();
		}
//			else if(data.lives <= 1 && data.subLives <=3){
//			data.subLives += 1;
//			UpdateHearts ();
//		}

		//ui.totalMagicBottleText.text = "   " + data.magicBottleCounter;
	}


	public void UpdateHearts(){
		if (data.lives >= 0) {
			ui.livesText.text = "x" + data.lives;

			if(data.subLives>3){
				print ("Increase Heart");
				if(data.lives<2){
					data.lives += 1;
					int newSublives = data.subLives - 3;
					data.subLives = newSublives;
					//ui.livesText.text = "x" + data.lives;
					UpdateHearts ();
				}

			}

            if (data.subLives == 3) {
				ui.heart1.sprite = ui.fullHeart;
				ui.heart2.sprite = ui.fullHeart;
				ui.heart3.sprite = ui.fullHeart;
//            ui.heart4.sprite = ui.fullHeart;
//            ui.heart5.sprite = ui.fullHeart;
//            ui.heart6.sprite = ui.fullHeart;
			}
//        if (data.lives == 5) {
//            ui.heart1.sprite = ui.emptyHeart;
//
//        }
//        if (data.lives == 4) {
//            ui.heart1.sprite = ui.emptyHeart;
//            ui.heart2.sprite = ui.emptyHeart;
//        }
//
//		if (data.lives == 3) {
//            ui.heart1.sprite = ui.emptyHeart;
//            ui.heart2.sprite = ui.emptyHeart;
//            ui.heart3.sprite = ui.emptyHeart;
//		}
			if (data.subLives == 2) {
				 ui.heart1.sprite = ui.fullHeart;
				  ui.heart2.sprite = ui.fullHeart;
				ui.heart3.sprite = ui.emptyHeart;
				// ui.heart4.sprite = ui.emptyHeart;

			}
			if (data.subLives == 1) {
				 ui.heart1.sprite = ui.fullHeart;
				ui.heart2.sprite = ui.emptyHeart;
				ui.heart3.sprite = ui.emptyHeart;
				// ui.heart4.sprite = ui.emptyHeart;
				// ui.heart5.sprite = ui.emptyHeart;
			}
		} else if (data.lives == 0)
			ui.livesText.text = "x" + data.lives;

	}

	public  void CheckLives(){
		int updateLive = data.subLives;

		if (data.subLives > 0) {
			updateLive -= 1;
			data.subLives = updateLive;
		}

		if (data.lives > 0 && data.subLives == 0) {
			data.lives -= 1;
			ui.livesText.text = "x" + data.lives;
			data.subLives = 3;
			SaveData ();
			//Invoke ("RespawnPlayer",0.5f);
		}	
		if (data.subLives == 0 && data.lives == 0) {
			//data.subLives = 3;
			//data.lives = 2;
			//SaveData ();
			//Invoke ("GameOver", 0.1f);
			ActiveHeartAdsPanel();

		} else {
			UpdateHearts ();
			SaveData ();
			Invoke ("RespawnPlayer", 0.5f);
			//RespawnPlayer ();

		}
	}
	 public void RespawnPlayer(){

		 player.GetComponent<Animator> ().SetInteger ("State",0);
		 player.transform.position = currentCheckPoint.transform.position;
		 player.GetComponent<Player> ().enabled = true;
		 player.GetComponent<Collider2D> ().enabled = true;
		player.GetComponent<SpriteRenderer> ().enabled = true;
        GameObject audSrc = GameObject.Find("FishSpawner");

        if (audSrc != null)
        {
            audSrc.GetComponent<AudioSource>().enabled = false;

        }
        //diedCollider.GetComponent<Collider2D> ().enabled = false;
        //SceneManager.LoadScene("Level1");

    }
	public void ShowTimeAdPanel(){
		if(timeOver){
			ui.timeAdPanel.SetActive (true);
		}
	}
	public void ShowHearthAdPanel(){
		if(data.subLives>0){
			ui.HeartAdsPanel.SetActive (true);
		}
	}
	public void GameOver(){
		print ("Game Over !!!!!!!!!!!");

		 if (timeOver && data.subLives > 0) {
			 ui.gameOverPanel.SetActive (true);

			 SaveData ();
			 ResetData ();
			// player.SetActive (false);
		 } else {

			ui.heart1.sprite = ui.emptyHeart;
			ui.gameOverPanel.SetActive (true);

			SaveData ();
			ResetData ();
			 //player.SetActive (false);
		 }
		//Invoke("RestartLevel",0.5f);

	 }
	public void AddHearts(){
		data.subLives += 3;
		UpdateHearts ();
		ui.goToContinueBtn.gameObject.SetActive (true);
	}
	public void ActiveHeartAdsPanel(){
		if (data.subLives == 1) {
			ui.heart1.sprite = ui.emptyHeart;
		}
		ui.HeartAdsPanel.gameObject.SetActive (true);
		Time.timeScale = 0;

	}
	public void ActiveTimeAdsPanel(){
		ui.timeAdsPanel.gameObject.SetActive (true);
		Time.timeScale = 0;

	}
	public void GoToContinue(){
		Time.timeScale = 1;
		ui.goToContinueBtn.gameObject.SetActive (false);
		ui.goToContinueBtnInT.gameObject.SetActive (false);
		ui.HeartAdsPanel.gameObject.SetActive (false);
		ui.timeAdsPanel.gameObject.SetActive (false);
		RespawnPlayer ();
	}

	public void GoToGameOver(){
		Time.timeScale = 1;
		ui.HeartAdsPanel.gameObject.SetActive (false);
		ui.timeAdsPanel.gameObject.SetActive (false);
		GameOver ();

	}
	public void AddTime(){
		TimeLeft = 60;
		ui.timerText.text=" "+(int)TimeLeft;
		ui.goToContinueBtnInT.gameObject.SetActive (true);

	}
	void ResetData(){
		FileStream fs = new FileStream (dataFilePath , FileMode.Create);
		data.bulletCounter = 0;
        data.coinCounter = 0;
        data.magicBottleCounter= 0;
		data.soldeirCounter= 0;

		ui.bulletText.text = " "+data.bulletCounter;
        ui.coinText.text = " " + data.coinCounter;
        ui.magicBottleText.text = " "+data.magicBottleCounter;
		ui.sodierText.text = " "+data.soldeirCounter;
		data.subLives = 3;
		data.lives = 2;
		UpdateHearts ();
		bf.Serialize (fs,data);
		fs.Close ();
	}



	void OnEnable(){
		LoadData ();

	}

	void OnDisable(){
		SaveData ();
	}	

	public void PlayerDied(GameObject other){
		
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		AudioController.instance.PlayerDie (other.gameObject.transform.position);
		//player.GetComponent<Animator> ().SetInteger ("State",-1);
		player.GetComponent<BoxCollider2D> ().enabled = false;
		player.GetComponent<Player> ().enabled = false;
		//diedCollider.GetComponent<Collider2D> ().enabled = true;
		Invoke ("CheckLives",restartDelay);
		other.GetComponent<SpriteRenderer> ().enabled = false;
        print("PlayerDied");



	}
	public void RestartLevel(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

	}

	public void ShowBigPrize(Vector3 pos){
		Instantiate(bigPrize,pos,Quaternion.identity);
	}
//	public void PlayerDiedAnimation(GameObject player){
//
//		//Throw the player back in the air
//		Rigidbody2D rb = player.GetComponent<Rigidbody2D> ();
//		rb.AddForce (new Vector2(-150f,400f));
//
//		//Rotate player a bit
//		player.transform.Rotate(new Vector3(0f,0f,45f));
//
//		//Disable player script
//		player.GetComponent<Player> ().enabled = false;
//
//		//Disable the colliders attached to player so that player can throw
//		foreach(Collider2D  c2d in player.transform.GetComponents<Collider2D>()){
//			c2d.enabled = false;
//		}
//		//Disable the child
//		foreach (Transform child in player.transform) {
//			child.gameObject.SetActive (false);
//		}
//
//		//Disable the cameraCTRl attached to gameobject camera
//		Camera.main.GetComponent<CameraFollow>().enabled=false;
//
//		//Set velocity of cat to zero
//		rb.velocity=Vector2.zero;
//
//		//Restart the level
//		StartCoroutine("PauseBeforDie",player);
//	}
//	IEnumerator PauseBeforDie(GameObject player){
//
//		yield return new WaitForSeconds (1.5f);
//		PlayerDie (player);
//	}
//	public void PlayerDie(GameObject other){
//
//		other.gameObject.SetActive (false);
//		CheckLives ();
//		//Invoke ("RestartLevel", restartDelay);
//
//	}


}
