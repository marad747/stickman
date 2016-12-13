using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class adsController : MonoBehaviour {

    // Use this for initialization
    //public static adsController instance;
    public string id, idrewardBasedVideo;
    BannerView bannerView;
    RewardBasedVideoAd rewardBasedVideo;
    void Awake () {
        //instance = this;
        CreateBanner();
        CreateRevardVideo();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CreateBanner() {
        bannerView = new BannerView(id,AdSize.Banner,AdPosition.TopRight);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("1ed90b7345391805").Build();
        // Load the banner with the request.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        bannerView.LoadAd(request);
        
    }

    public void HandleOnAdLoaded(object sender,EventArgs args) {
        bannerView.Show();        
    }

    public void CreateRevardVideo() {

        rewardBasedVideo = RewardBasedVideoAd.Instance;
        AdRequest request = new AdRequest.Builder().Build();
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardBasedVideo.LoadAd(request,id);

    }

    public void PlayReklamy() {
        if (rewardBasedVideo.IsLoaded()) {
            rewardBasedVideo.Show();
        }
    }
    
    public void HandleRewardBasedVideoRewarded(object sender,Reward args) {      
        PlayerPrefs.SetInt("CountCoins",PlayerPrefs.GetInt("CountCoins") + 250);
    }
    void OnGUI() {
        GUILayout.Label(rewardBasedVideo.IsLoaded().ToString());
    }

}
