using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
/// <summary>
/// Group all user interface elements together
/// </summary>
[Serializable]
public class UI  {
	
	[Header("Text")]
	public Text bulletText;
    public Text coinText;
	public Text sodierText;
	public Text timerText;
	public Text magicBottleText;
	public Text livesText;
	public GameObject gameOverPanel;
	public GameObject levelCompletePanel;
	//public Text totalGemText;
//	public Text totalsodierText;
	//public Text totalMagicBottleText;
	public Image heart1;
	public Image heart2;
	public Image heart3;
//    public Image heart4;
//    public Image heart5;
//    public Image heart6;
	public Sprite emptyHeart;
	public Sprite fullHeart;
	public GameObject pausePanel;
	public GameObject timeAdPanel;
	public GameObject HeartAdsPanel;
	public Button noThanksBtn;
	public Button goToContinueBtn;
	public GameObject noInternetTxt;
	public GameObject timeAdsPanel;
	public Button noThanksBtnInT;
	public Button goToContinueBtnInT;
	public GameObject noInternetTxtInT;


//	public Button SoundOff;
//	public Sprite img_SoundOff;
//	public Sprite img_SoundOn;



}
