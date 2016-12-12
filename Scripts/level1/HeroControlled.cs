using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroControlled : MonoBehaviour {

    // Use this for initialization
    public Rigidbody2D rb;
    public static HeroControlled instance;
    public GameObject Hero, currentBlock, previousBlock;
    public Animator anim;
    public float startTime, forceRight, forceUp, diff, cunt;
    public bool press;

    void Awake () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentBlock == previousBlock) {
            Level1Manager.instance.GameOver();            
        }
        if (press)
            diff = Time.time - startTime;
    }    

    void OnMouseDown() {
        startTime = Time.time;
        anim.SetBool("jump",true);
        press = true;
    }

    void OnMouseUp() {        
        if (diff <= 2f) {
            forceUp = 200 * diff;
            forceRight = 170 * diff;
        } else {
            forceUp = Random.Range(320f,350f);
            forceRight = Random.Range(250f,280f);
        } 
        if (HeroCollision.instance.isGround == true && diff >= 0.1f) {
            anim.SetBool("fly",true);
            rb.AddForce(Hero.transform.up * forceUp);
            rb.AddForce(Hero.transform.right * forceRight);            
        }
        press = false;
    }
}
