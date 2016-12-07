using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHeroes : MonoBehaviour {

    // Use this for initialization
    public int price;
    public GameObject target;    
	void Start () {
        if (PlayerPrefs.GetString(gameObject.name.ToString()) == "yes") {
            gameObject.SetActive(false);
            target.gameObject.SetActive(true);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuyHero() {
        if (PlayerPrefs.GetInt("CountCoins") >= price) {
            gameObject.SetActive(false);
            target.gameObject.SetActive(true);
            PlayerPrefs.SetInt("CountCoins",PlayerPrefs.GetInt("CountCoins") - price);
            PlayerPrefs.SetString(gameObject.name.ToString(),"yes");
           // Debug.Log("Купили " + gameObject.name.ToString());

        }
    }
}
