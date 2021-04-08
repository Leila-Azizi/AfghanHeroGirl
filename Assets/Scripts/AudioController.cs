using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioController : MonoBehaviour {
	public static AudioController instance;
	public PlayerAudio playeraudio;
	public Transform player;
	public bool soundOn;
	//public GameObject BGMusic;
	[Tooltip("Use On/Off the audio of the game from inspector")]
//	public bool soundon;
	public Button btn_sound;
	public Sprite imgSoundOff;
	public Sprite imgSoundOn;
	public bool bgMusicOn;
	//public GameObject bgMusic;
	//public Button btnMusic;
	//public Sprite imgMusicOff;
	//public Sprite imgMusicOn;
	// Use this for initialization
	void Start () {
		
		soundOn = true;
		if (instance == null) {

			instance = this;
		}
		if(instance==null){
			instance = this;
		}

		//if (DataCtrl.instance.data.playMusic) {
//			bgMusic.SetActive (true);
//			btnMusic.GetComponent<Image> ().sprite = imgMusicOn;
		//} else {
//			bgMusic.SetActive (true);
//			btnMusic.GetComponent<Image> ().sprite = imgMusicOff;
		//}
		//if (DataCtrl.instance.data.playSound) {
//			soundOn = true;
//			btn_sound.GetComponent<Image> ().sprite = imgSoundOn;
		//} else {
//			soundOn = false;
//			btn_sound.GetComponent<Image> ().sprite = imgSoundOff;
		//}
	}

	public void PlayerLands(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.playerLands,playerPos);
		}
	}
   
    public void PlayerJump(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.playerJump,playerPos);
		}
	}
	public void BulletPickup(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.bulletPickup,playerPos);
		}
	}
	public void PlayerFire(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.playerFire,playerPos);
		}
	}
//	public void KeyFound(Vector3 playerPos){
//		if (soundon) {
//			AudioSource.PlayClipAtPoint (playeraudio.keyfound,playerPos);
//		}
//	}
	public void GrayEnemyDie(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.grayEnemyDie,playerPos);
		}
	}



    public void EnemyDie(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.enemyDie,playerPos);
		}
	}
	public void PlayerDie(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.playerDie,playerPos);
		}
	}
	public void MagicBottlePickup(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.magicBottlePickup,playerPos);
		}
	}
	public void SavePoint(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.savePoint,playerPos);
		}
	}
	public void EnemyFire(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.enemyFire,playerPos);
		}
	}
	public void BigPrizePickup(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.bigPrizePickup,playerPos);
		}
	}
	public void HeartPickup(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.heartPickup,playerPos);
		}
	}
	public void SimplerPickup(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.simplerPickup,playerPos);
		}
	}
	public void StuffArea(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.stuffArea,playerPos);
		}
	}
	public void DangerArea(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.dengerArea,playerPos);
		}
	}
	public void BoxOpen(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.boxOpen,playerPos);
		}
	}
	public void ApearBoss(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.apearBoss,playerPos);
		}
	}
	public void Trampoline(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.trampline,playerPos);
		}
	}
    public void CoinPickup(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.coinPickup,playerPos);
		}
	}
    public void BombExplosion(Vector3 playerPos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (playeraudio.bombExplosion,playerPos);
		}
	}
	public void ToggleSound(){
		if (soundOn) {
			soundOn = false;
		    btn_sound.GetComponent<Image> ().sprite = imgSoundOff;
		//	DataCtrl.instance.data.playSound = false;
		} else {
		soundOn =true;
		    btn_sound.GetComponent<Image> ().sprite = imgSoundOn;
		//	DataCtrl.instance.data.playSound = true;
		}
	}

//	public void ToggleMusic(){
//		if (bgMusic) {
//			bgMusic.SetActive (false);
//			btnMusic.GetComponent<Image> ().sprite = imgMusicOff;
//		//	DataCtrl.instance.data.playMusic = false;
//		}
//		 else {
//			bgMusic.SetActive (true);
//			btnMusic.GetComponent<Image> ().sprite = imgMusicOn;
//			//DataCtrl.instance.data.playMusic = true;
//		//}
//	}



		}
	//}
