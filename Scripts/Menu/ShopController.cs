using UnityEngine;
using System.Collections;

public class ShopController : MonoBehaviour {

    // Use this for initialization 
    [SerializeField]
    private int price;
	void Start () {
        if (PlayerPrefs.GetString(gameObject.name.ToString()) == "yes") {
            gameObject.GetComponent<UIButton>().onClick.Clear();
            Debug.Log(gameObject.name.ToString() + " куплен");
        } else {
            //gameObject.GetComponent<UIButton>().enabled = false;
            Debug.Log(gameObject.name.ToString() + " не куплен");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BuyHero() {

        if (PlayerPrefs.GetInt("CountCoins") >= price) {
            gameObject.GetComponent<UIButton>().onClick.Clear();
            Debug.Log("buy " + gameObject.name.ToString());
            PlayerPrefs.SetString(gameObject.name.ToString(),"yes");
            PlayerPrefs.SetInt("CountCoins",PlayerPrefs.GetInt("CountCoins") - price);
        }


    }
}
