using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;

/*
CountCoins - Количество монеток
SelectedHero - Выбранный герой
FirstBoot - первый раз запущена игра
*/
public class MenuController : MonoBehaviour {

    // Use this for initialization    
    [SerializeField]
    private GameObject panelButtons,panelSelectHero,panelScrollAnywhere,panelExit,panelHeroes;
    [SerializeField]
    private UILabel CointTxt;
    [SerializeField]
    private string id;
    InterstitialAd interstitial;

    void Awake() {
        CtreateInsertial();
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetString("FirstBoot") != "yes") {
            PlayerPrefs.SetString("SelectedHero","Stickman");
            PlayerPrefs.SetString("FirstBoot","yes");
            PlayerPrefs.SetInt("CountCoins",1000000);
            PlayerPrefs.SetString("StickmanBuy","yes");
        }
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
        HideOrShow(panelHeroes,false);
    }

    public void showMainMenu() {
        HideOrShow(panelButtons,true);
        HideOrShow(panelSelectHero,false);
        HideOrShow(panelScrollAnywhere,false);
        HideOrShow(panelHeroes,true);
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

    public void showExitQuestion() {
        HideOrShow(panelButtons,false);
        HideOrShow(panelExit,true);
    }

    public void ExitFromGame() {
        Application.Quit();
    }

    public void BackTogame() {
        HideOrShow(panelExit,false);
        HideOrShow(panelButtons,true);        
    }
}
