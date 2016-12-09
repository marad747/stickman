using UnityEngine;
using System.Collections;

public class HeroSelection : MonoBehaviour {

    // Use this for initialization   
    public GameObject [] heroes;        
    void Start () {
        Debug.Log("select hero " + PlayerPrefs.GetString("SelectedHero").ToString());
        if (PlayerPrefs.GetString("SelectedHero").ToString() == gameObject.name.ToString())
            gameObject.GetComponent<UISprite>().color = Color.red;
            //gameObject.SetActive(false);
    }   

    // Update is called once per frame
    void Update () {
	
	}
    public void SelectHero() {
        PlayerPrefs.SetString("SelectedHero",gameObject.name.ToString());
        Debug.Log("select hero " + gameObject.name.ToString());
        //for (int i = 0;i < heroes.Length;i++) {
        //    if (PlayerPrefs.GetString("SelectedHero").ToString() == heroes [i].gameObject.name.ToString())
        //        heroes [i].gameObject.GetComponent<UI2DSprite>().color = Color.red;
        //    heroes [i].gameObject.SetActive(false);
        //    else
        //        heroes [i].gameObject.GetComponent<UI2DSprite>().color = Color.white;
        //    heroes [i].gameObject.SetActive(true);

        //}
        //MenuController.instance.showMainMenu();
    }
}
