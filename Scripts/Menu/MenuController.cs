using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    // Use this for initialization    
    [SerializeField]
    private GameObject panelButtons,panelSelectHero,panelScrollAnywhere;
    [SerializeField]
    private UILabel CointTxt;

    void Start () {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("CountCoins",4894847);
        //PlayerPrefs.GetString("SelectedHero");
    }                                            	
	// Update is called once per frame
	void Update () {
        CointTxt.text = PlayerPrefs.GetInt("CountCoins").ToString();
	}

    public void QuitFromGame() {
        Application.Quit();

    }
    void HideOrShow(GameObject obj,bool flag) {
        obj.SetActive(flag);
    }

    public void showSelectHero() {
        HideOrShow(panelButtons,false);
        HideOrShow(panelSelectHero,true);
        HideOrShow(panelScrollAnywhere,true);
    }

    public void showMainMenu() {
        HideOrShow(panelButtons,true);
        HideOrShow(panelSelectHero,false);
        HideOrShow(panelScrollAnywhere,false);
    }
}
