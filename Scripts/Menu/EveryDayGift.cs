using UnityEngine;
using System;

public class EveryDayGift : MonoBehaviour {

    
    void Awake () {

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
            Debug.Log("New Reward!");
            string newStringDate = Convert.ToString(newDate);
            PlayerPrefs.SetString("PlayDate",newStringDate);            
        }
        //else
            //Debug.Log("No Reward!");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
