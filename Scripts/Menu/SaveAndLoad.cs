using UnityEngine;
using System.Collections;
using System.Xml;

public class SaveAndLoad : MonoBehaviour {

    // Use this for initialization
    public static SaveAndLoad instance;
    public int CoinCount;
    void Awake() {
        instance = this;
    }

    void Start () {
        SetCoinCount();
    }
	
	// Update is called once per frame
	void Update () {        
	}

    public void SetCoinCount() {
        CoinCount = GetCoinCount();
    }

    public int GetCoinCount() {
        int coin = 0;
        try {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.persistentDataPath + "Save.xml");
            coin = XmlConvert.ToInt16(xmlDoc.SelectSingleNode("Information/CoinCount").InnerText);
        } catch {
            coin = CreateFile();
        }
        return coin;
    }
 
    public int CreateFile() {

        int coin;
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode Rootnode = xmlDoc.CreateElement("Information");
        xmlDoc.AppendChild(Rootnode);

        XmlNode userNode;
        userNode = xmlDoc.CreateElement("CoinCount");
        userNode.InnerText = "200";
        Rootnode.AppendChild(userNode);

        xmlDoc.Save(Application.persistentDataPath + "Save.xml");

        xmlDoc.Load(Application.persistentDataPath + "Save.xml");
        coin = XmlConvert.ToInt16(xmlDoc.SelectSingleNode("Information/CoinCount").InnerText);
        return coin;
    }

    public void SaveCountCoin(int count) {
        int CountCoin = GetCoinCount();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Application.persistentDataPath + "Save.xml");
        xmlDoc.SelectSingleNode("Information/CoinCount").InnerText = (count + CountCoin).ToString();
        xmlDoc.Save(Application.persistentDataPath + "Save.xml");        
    }
}
