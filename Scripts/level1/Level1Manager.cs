using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour {

    // Use this for initialization
    public static Level1Manager instance;
    public GameObject stickman,platform,spawnPoint,target,cat,dog,dedMoroz;
    public List<GameObject> platforms;
    public float damping;
    public int countPlatformPassed;
    public bool isItLast;
    void Awake() {
        instance = this;
    }

    void Start() {
        CreateBlocks();
        CreateHero();
    }

    public void CheckLastBlock(GameObject block) {

        for (int i = 0;i < platforms.Count;i++) {
            if (platforms [i].gameObject == block.gameObject && i == 9)
                isItLast = true;
        }
    }

    public void ChangePlatform() {
        for (int i = 1;i < platforms.Count;i++) {
            var blockTemp = platforms [i];
            blockTemp.transform.localScale = new Vector3(Random.Range(0.5f, 3f),platforms [i - 1].transform.localScale.y,1);
            blockTemp.transform.position = new Vector3(platforms [i - 1].GetComponent<MeshRenderer>().bounds.max.x + Random.Range(2f,4f),Random.Range(-3.6f,-2.3f),0);
        }
    }

    public void ChangePosition() {
        isItLast = false;
        platforms.Reverse();
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
    }

    void CreateBlocks() {
        var platformTemp = Instantiate(platform,new Vector3(-5.6f,-3.6f,0),Quaternion.identity) as GameObject;
        spawnPoint = GameObject.FindGameObjectWithTag("spawnPoint");
        platforms.Add(platformTemp);
        for (int i = 1;i < 10;i++) {
            var blockTemp = Instantiate(platform) as GameObject;
            blockTemp.name = "Block" + Random.Range(1f,100f);
            blockTemp.transform.localScale = new Vector3(Random.Range(0.5f,3f),platforms [i - 1].transform.localScale.y,1);
            blockTemp.transform.position = new Vector3(platforms [i - 1].GetComponent<MeshRenderer>().bounds.max.x + Random.Range(2f,4f),Random.Range(-3.6f,-2.3f),0);
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
}
