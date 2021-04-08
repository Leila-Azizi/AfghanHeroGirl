using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
{
	public static AdsManager instance;

	void Awake(){
		if(instance ==null){
			instance = this;
		}
	}
    // Start is called before the first frame update
    void Start()
    {
		if (!Advertisement.isInitialized)
			Advertisement.Initialize ("3110539");
    }

    // Update is called once per frame
//    public void ShowAds()
//    {
//		if (Advertisement.IsReady ()) {
//			Advertisement.Show ("video",new ShowOptions(){resultCallback = HandleAdsResult});
//		}
//
//    }

	void Update(){
		if (Input.GetKeyDown (KeyCode.E)) {
			ShowVideoOrInterstitialAD ();
		}
		if(Input.GetKeyDown (KeyCode.R)) {
			PlayRewardedVideo ();
		}
		if(Input.GetKeyDown (KeyCode.B)) {
			ShowBannerAD ();		
		}
	}

	public void ShowVideoOrInterstitialAD(){
		
		if (Advertisement.IsReady ()) {
			Advertisement.Show ("video",new ShowOptions(){resultCallback = HandleAdsResult});
		}
	}

	public void PlayRewardedVideo(){
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			GameCtrl.instance.ui.noInternetTxt.gameObject.SetActive (true);
		} else {
			if (Advertisement.IsReady ()) {
				Advertisement.Show ("rewardedVideo",new ShowOptions(){resultCallback = HeartAdsResult});
			}
		}

	}
	public void PlayRewardedVideoForTime(){
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			GameCtrl.instance.ui.noInternetTxtInT.gameObject.SetActive (true);
		} else {
			if (Advertisement.IsReady ()) {
				Advertisement.Show ("rewardedVideo",new ShowOptions(){resultCallback = TimeAdsResult});
			}
		}

	}

	public void ShowBannerAD(){
		if (Advertisement.IsReady ()) {
			Advertisement.Show ("banner",new ShowOptions(){resultCallback = HandleAdsResult});
		}
	}
	void HandleAdsResult(ShowResult result){
		switch (result) {
		case ShowResult.Finished:
			print ("Finished");
			break;
		case ShowResult.Skipped:
			print ("Skiped");
			break;
		case ShowResult.Failed:
			print ("Internet connection lost");

			break;
		}
	}
	void HeartAdsResult(ShowResult result){
		switch (result) {
		case ShowResult.Finished:
			GameCtrl.instance.AddHearts();
			break;
		case ShowResult.Skipped:
			print ("Skiped");
			break;
		case ShowResult.Failed:
			print ("Internet connection lost");

			break;
		}
	}
	public void TimeAdsResult(ShowResult result){
		switch (result) {
		case ShowResult.Finished:
			GameCtrl.instance.AddTime();
			break;
		case ShowResult.Skipped:
			print ("Skiped");
			break;
		case ShowResult.Failed:
			print ("Internet connection lost");

			break;
		}
	}
}
