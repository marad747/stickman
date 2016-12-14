using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1Manager : MonoBehaviour {

    // Use this for initialization
    public static Level1Manager instance;
    public GameObject stickman,platform,spawnPoint,target,cat,dog,dedMoroz,panelGameOver;
    public List<GameObject> platforms;
    public float damping;
    public int restartPrice; 
    public bool isItLast,doIt;
    public UILabel countPlatforms,Coins;
    public float minRandom, maxRandom;
    void Awake() {
        instance = this;        
        //Advertisement.Initialize("1224192");   
    }

    void Start() {
        CreateBlocks();
        CreateHero();
    }

    public void CheckLastBlock(GameObject block) {

        for (int i = 0;i < platforms.Count;i++) {
            if (platforms [i].gameObject == block.gameObject && i == 16)
                isItLast = true;
        }
    }

    public void ChangePlatform() {
        float rValue = Random.Range(minRandom,maxRandom);        
        platforms [4].transform.localScale = new Vector2(rValue,rValue);
        platforms [4].transform.position = new Vector2(platforms [0].GetComponent<SpriteRenderer>().bounds.max.x + Random.Range(2f,4f),Random.Range(-3.6f,-2.3f));
        for (int i = 5;i < platforms.Count;i++) {
            var blockTemp = platforms [i];
            blockTemp.transform.localScale = new Vector3(rValue,rValue,1);
            blockTemp.transform.position = new Vector3(platforms [i - 1].GetComponent<SpriteRenderer>().bounds.max.x + Random.Range(2f,4f),Random.Range(-3.6f,-2.3f),0);

        }
    }

    public void ChangePosition() {
        isItLast = false;
        platforms.Reverse(); 
        if (minRandom > 0.1f) {
            minRandom -= 0.03f;
           
        }
        if (maxRandom > 0.1f) {
            maxRandom -= 0.03f;
        }


        ChangePlatform();        
    }

    // Update is called once per frame
    void Update() {
        if (target != null) {
            Vector3 currentPosition = Vector3.Lerp(new Vector3(transform.position.x,1f,0),new Vector3(target.transform.position.x + damping,1f,0),damping * Time.deltaTime);
            transform.position = currentPosition;
        }
        if (isItLast)
            ChangePosition();

        Coins.text = PlayerPrefs.GetInt("CountCoins").ToString();       
    }

    void CreateBlocks() {
        var platformTemp = Instantiate(platform,new Vector3(-5.6f,-3.6f,0),Quaternion.identity) as GameObject;
        spawnPoint = GameObject.FindGameObjectWithTag("spawnPoint");
        platforms.Add(platformTemp);
        int t = 1;
        for (int i = 1;i < 20;i++) {
            var blockTemp = Instantiate(platform) as GameObject;            
            t++;
            blockTemp.name = "Block" + t.ToString();
            float rValue = Random.Range(0.35f,0.7f);
            blockTemp.transform.localScale = new Vector3(rValue,rValue,1);
            blockTemp.transform.position = new Vector3(platforms [i - 1].GetComponent<SpriteRenderer>().bounds.max.x + Random.Range(2f,4f),Random.Range(-3.6f,-2.3f),0);
            platforms.Add(blockTemp);
        }
    }
   
    void CreateHero() {
        string Currenthero = PlayerPrefs.GetString("SelectedHero");
        //Debug.Log(PlayerPrefs.GetString("SelectedHero"));

        switch (Currenthero) {

        case "Stickman":
            CreateHeroes(stickman);
        break;
        case "Cat":
            CreateHeroes(cat);
        break;
        case "Dog":
            CreateHeroes(dog);
        break;
        case "DedMoroz":
            CreateHeroes(dedMoroz);
        break;
        default:
            break;
        }
    }

    public void CreateHeroes(GameObject Hero) {
        var HeroTemp = Instantiate(Hero,spawnPoint.transform.position,Quaternion.identity) as GameObject;
        CameraFollow.instance.target = HeroTemp.gameObject;
        target = HeroTemp;
        HeroControlled.instance.Hero = HeroTemp;
        HeroControlled.instance.rb = HeroControlled.instance.Hero.GetComponent<Rigidbody2D>();
        HeroControlled.instance.anim = HeroControlled.instance.Hero.GetComponent<Animator>(); 
    }

    public void GameOver() {
        panelGameOver.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = false;        
        countPlatforms.text = HeroCollision.instance.countPlatforms + " platforms".ToString();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu() {
        SceneManager.LoadScene("menu");
    }

    public void returnGameForMoney() {                    
        if (PlayerPrefs.GetInt("CountCoins") >= restartPrice) {            
            target.SetActive(true);
            PlayerPrefs.SetInt("CountCoins", PlayerPrefs.GetInt("CountCoins") - restartPrice);
            GetComponent<BoxCollider2D>().enabled = true;
            target.transform.position = new Vector2(HeroControlled.instance.previousBlock.transform.position.x,HeroControlled.instance.previousBlock.transform.position.y + 1.5f);
            HeroControlled.instance.currentBlock = GameObject.Find("Main camera");            
            panelGameOver.SetActive(false);
            dethController.instance.follow.enabled = true;            
        }                                                 
    }    
}
