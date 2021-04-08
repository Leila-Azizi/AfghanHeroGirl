using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PanelCtrl : MonoBehaviour {
	public static bool IsPaused;
	public Sprite soundOnSprite;
	public Sprite soundOffSprite;
	public Button btn_sound;
	public GameObject bGMusic;

	public Sprite musicOnSprite;
	public Sprite musicOffSprite;
	public Button btn_music;
	// Use this for initialization
	void Start () {
		IsPaused = false;
		if (AudioController.instance.soundOn) {
			btn_sound.GetComponent<Image> ().sprite = soundOnSprite;
		} else if (!AudioController.instance.soundOn) {
			btn_sound.GetComponent<Image> ().sprite = soundOffSprite;
		}


	}
	
	// Update is called once per frame
	void Update () {
		if (AudioController.instance.soundOn) {
			btn_sound.GetComponent<Image> ().sprite = soundOnSprite;
		} else if (!AudioController.instance.soundOn) {
			btn_sound.GetComponent<Image> ().sprite = soundOffSprite;
		}

		if(AudioController.instance.bgMusicOn){
			btn_music.GetComponent<Image> ().sprite = musicOnSprite;	
		}
		else if(!AudioController.instance.bgMusicOn){
			btn_music.GetComponent<Image> ().sprite = musicOffSprite;	
		}
		
	}
	public void ChangeScene(string sceneName){

		SceneManager.LoadScene (sceneName);

	}
	public void ShowPausePanel(){
		//if (ui.pausePanel.activeInHierarchy)
		//	ui.pausePanel.SetActive (false);
		GameCtrl.instance.ui.pausePanel.SetActive (true);

		//	ui.PausePanel.gameObject.GetComponent<RectTransform> ().DOAnchorPosY (0,0.7f,false);
		Invoke ("SetPause",1.1f);
		Time.timeScale = 0;
	}
	void SetPause(){
		IsPaused = true;
	}

	public void HidePausePanel(){
		IsPaused = false;
		if (!GameCtrl.instance.ui.pausePanel.activeInHierarchy)
			GameCtrl.instance.ui.pausePanel.SetActive (true);
		//ui.PausePanel.gameObject.GetComponent<RectTransform> ().DOAnchorPosY (621,0.7f,false);
		  GameCtrl.instance.ui.pausePanel.SetActive (false);
		Time.timeScale = 1;


	}
	public void BGMusicOnAndOff(){
		AudioController.instance.bgMusicOn = !AudioController.instance.bgMusicOn;
		if(AudioController.instance.bgMusicOn){
			btn_music.GetComponent<Image> ().sprite = musicOnSprite;
			bGMusic.GetComponent<AudioSource> ().enabled = true;
		}
		else if(!AudioController.instance.bgMusicOn){
			btn_music.GetComponent<Image> ().sprite = musicOffSprite;
			bGMusic.GetComponent<AudioSource> ().enabled = false;
		}

	}

	public void SoundOnAndOff(){
		AudioController.instance.soundOn = !AudioController.instance.soundOn;
		if (AudioController.instance.soundOn) {
			btn_sound.GetComponent<Image> ().sprite = soundOnSprite;
		} else if (!AudioController.instance.soundOn) {
			btn_sound.GetComponent<Image> ().sprite = soundOffSprite;
		}
		
	}

}
