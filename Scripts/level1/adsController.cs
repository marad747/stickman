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
}
