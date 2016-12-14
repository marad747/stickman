using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHeroes : MonoBehaviour {

    // Use this for initialization
    public int price;
    public UIButton target;
    public string previousСharacter;
    void Start () {
        if (PlayerPrefs.GetString(gameObject.name.ToString()) == "yes") {
            gameObject.SetActive(false);        
            target.enabled = true;
        } else
            target.enabled = false;		
	 }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuyHero() {
        Debug.Log( PlayerPrefs.GetString(previousСharacter));
        if (PlayerPrefs.GetInt("CountCoins") >= price) {
            if (PlayerPrefs.GetString(previousСharacter) == "yes"){
                gameObject.SetActive(false);
                target.enabled = true;
                PlayerPrefs.SetInt("CountCoins",PlayerPrefs.GetInt("CountCoins") - price);
                PlayerPrefs.SetString(gameObject.name.ToString(),"yes");
                // Debug.Log("Купили " + gameObject.name.ToString());
            }else
                Debug.Log("buy previous character");
        }
    }
}
