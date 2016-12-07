using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInMainStage : MonoBehaviour {

    // Use this for initialization 
    public GameObject [] heroes;  
	void OnEnable () {
        for (int i = 0;i < heroes.Length;i++) {
            if (PlayerPrefs.GetString("SelectedHero").ToString() == heroes [i].name.ToString())
                heroes [i].SetActive(true);
            else
                heroes [i].SetActive(false);
        }
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
