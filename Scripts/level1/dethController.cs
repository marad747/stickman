using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dethController : MonoBehaviour {

    // Use this for initialization
    public static dethController instance;
    public CameraFollow follow;

    void Awake() {
        instance = this;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Level1Manager.instance.GameOver();
            follow.enabled = false;
            other.gameObject.SetActive(false);
            if (HeroControlled.instance.previousBlock != null)
                other.gameObject.transform.position = new Vector2(HeroControlled.instance.previousBlock.transform.position.x,HeroControlled.instance.previousBlock.transform.position.y + 1.5f);
            else {
                HeroControlled.instance.previousBlock = HeroControlled.instance.currentBlock;
                HeroControlled.instance.currentBlock = GameObject.Find("Main Camera");
                other.gameObject.transform.position = new Vector2(HeroControlled.instance.previousBlock.transform.position.x,HeroControlled.instance.previousBlock.transform.position.y + 1.5f);
            }
        }
    }
}
