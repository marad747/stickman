using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour {

    // Use this for initialization
    public string levelName;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel() {
        if (MenuController.instance.interstitial.IsLoaded()) {
            MenuController.instance.nameScene = levelName;
            MenuController.instance.interstitial.Show();
        } else
            SceneManager.LoadScene(levelName);
    } 
}
