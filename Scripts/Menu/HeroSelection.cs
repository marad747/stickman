using UnityEngine;
using System.Collections;

public class HeroSelection : MonoBehaviour {

    // Use this for initialization   

    void Start () {
        
    }   

    // Update is called once per frame
    void Update () {
	
	}

    public void SelectHero() {
        PlayerPrefs.SetString("SelectedHero",gameObject.name.ToString());
        Debug.Log("select hero " + PlayerPrefs.GetString("SelectedHero").ToString());
    }
}
