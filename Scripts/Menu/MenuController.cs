using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;

/*
CountCoins - Количество монеток

*/
public class MenuController : MonoBehaviour {

    // Use this for initialization    
    [SerializeField]
    private GameObject panelButtons,panelSelectHero,panelScrollAnywhere;
    [SerializeField]
    private UILabel CointTxt;
    [SerializeField]
    private string id;
    InterstitialAd interstitial;

    void Awake() {
        CtreateInsertial();        
    }

    void Start () {
         
    }                                            	
	// Update is called once per frame
	void Update () {
        CointTxt.text = PlayerPrefs.GetInt("CountCoins").ToString();
    }

    public void LoadGame() {
        if (interstitial.IsLoaded()) {
            interstitial.Show();
        } else
            SceneManager.LoadScene("game");

    }

    public void QuitFromGame() {
        Application.Quit();

    }

    void HideOrShow(GameObject obj,bool flag) {
        obj.SetActive(flag);
    }

    public void showSelectHero() {
        HideOrShow(panelButtons,false);
        HideOrShow(panelSelectHero,true);
        HideOrShow(panelScrollAnywhere,true);
    }

    public void showMainMenu() {
        HideOrShow(panelButtons,true);
        HideOrShow(panelSelectHero,false);
        HideOrShow(panelScrollAnywhere,false);
    }

    void CtreateInsertial() {
        interstitial = new InterstitialAd(id);        
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("1ed90b7345391805").Build();                
        interstitial.OnAdClosed += HandleInterstitialClosed;        
        interstitial.LoadAd(request);
    }

    public void HandleInterstitialClosed(object sender,EventArgs args) {
        SceneManager.LoadScene("game");
    }

}
