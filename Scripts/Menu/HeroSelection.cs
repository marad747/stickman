using UnityEngine;
using System.Collections;

public class HeroSelection : MonoBehaviour {

    // Use this for initialization   
    public GameObject [] heroes;    
    public GameObject [] targets;
    void Start () {
        if (PlayerPrefs.GetString("SelectedHero").ToString() == gameObject.name.ToString())
            gameObject.SetActive(false);
    }   

    // Update is called once per frame
    void Update () {
	
	}
    public void SelectHero() {
        PlayerPrefs.SetString("SelectedHero",gameObject.name.ToString());
        //Debug.Log("select hero " + PlayerPrefs.GetString("SelectedHero").ToString());
        for (int i=0;i<heroes.Length;i++) {            
            if (PlayerPrefs.GetString("SelectedHero").ToString() == heroes[i].gameObject.name.ToString())
                heroes[i].SetActive(false);
            else
                if (PlayerPrefs.GetString(targets[i].gameObject.name.ToString()) == "yes")
                heroes[i].SetActive(true);

        }
    }
}
