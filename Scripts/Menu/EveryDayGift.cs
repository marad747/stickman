using UnityEngine;
using System;
using System.Collections;

public class EveryDayGift : MonoBehaviour {

    //public int bonusCount;
    public UILabel txt;
    public float timer;
    public GameObject panelButtons, panelHeroes,panelBonus,buttonTakeBonus;
    public bool roll;
    void Awake () {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetString("FirstBoot") != "yes") {
            PlayerPrefs.SetString("SelectedHero","Stickman");
            PlayerPrefs.SetString("FirstBoot","yes");
            PlayerPrefs.SetInt("CountCoins",1000000);
            PlayerPrefs.SetString("StickmanBuy","yes");
            PlayerPrefs.SetString("Level1Buy","yes");
        }

        string stringDate = PlayerPrefs.GetString("PlayDate");
        if (stringDate == "")
            stringDate = "01/01/01 00:00:00 AM";
        //Debug.Log("PlayDate: " + stringDate.ToString());
        DateTime oldDate = Convert.ToDateTime(stringDate);
        DateTime newDate = DateTime.Now;
        //Debug.Log("LastDay: " + oldDate);
        //Debug.Log("CurrDay: " + newDate);

        TimeSpan difference = newDate.Subtract(oldDate);        
        if (difference.Days >= 1) {
            HideMainMenu();
            Debug.Log("New Reward!");
            string newStringDate = Convert.ToString(newDate);
            PlayerPrefs.SetString("PlayDate",newStringDate);            
        }
        //else
            //Debug.Log("No Reward!");

    }

    IEnumerator HideBonusPanel() {
        yield return new WaitForSeconds(1.5f);
        panelButtons.SetActive(true);
        panelHeroes.SetActive(true);
        panelBonus.SetActive(false);
        
    }

    public void TakeBonus() {
        buttonTakeBonus.SetActive(false);
        roll = true;

    }

    public void HideMainMenu() {
        panelButtons.SetActive(false);
        panelHeroes.SetActive(false);
        panelBonus.SetActive(true);
    }
	
    // Update is called once per frame
	void Update () {
        //
        if (roll) {
            timer += Time.deltaTime;
            if (timer <= 1.5f) {
                txt.text = UnityEngine.Random.Range(100,500).ToString();

            } else {
                roll = false;
                PlayerPrefs.SetInt("CountCoins",PlayerPrefs.GetInt("CountCoins") + Convert.ToInt16(txt.text));
                StartCoroutine(HideBonusPanel());                                
            }
        }
    }
}
