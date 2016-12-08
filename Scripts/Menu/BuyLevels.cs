using System.Collections;
using UnityEngine;
using System;

public class BuyLevels : MonoBehaviour {

    // Use this for initialization
    public UIButton target;
    public int price;
    void Start() {        
        if (PlayerPrefs.GetString(gameObject.name.ToString()) == "yes") {
            gameObject.SetActive(false);
            target.enabled = true;
        } else
            target.enabled = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public void BuyLevel() {
        if (PlayerPrefs.GetInt("CountCoins") >= price) {
            gameObject.SetActive(false);
            target.enabled = true;
            PlayerPrefs.SetInt("CountCoins",PlayerPrefs.GetInt("CountCoins") - price);
            PlayerPrefs.SetString(gameObject.name.ToString(),"yes");
        }
    }
}
