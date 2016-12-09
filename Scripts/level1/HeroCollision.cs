using System.Collections;
using System;
using UnityEngine;

public class HeroCollision : MonoBehaviour {

    // Use this for initialization
    public static HeroCollision instance;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public bool isGround;
    public float groundRadius = 0.2f;
	void Awake () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        //isGround = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
        isGround = Physics2D.OverlapBox(groundCheck.position,new Vector2(groundRadius,groundRadius),90,whatIsGround);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        HeroControlled.instance.anim.SetBool("fly",false);
        HeroControlled.instance.anim.SetBool("jump",false);
        Level1Manager.instance.CheckLastBlock(collision.gameObject);
        Level1Manager.instance.countPlatformPassed++;
        HeroControlled.instance.previousBlock = HeroControlled.instance.currentBlock;
        HeroControlled.instance.currentBlock = collision.gameObject;
    }
}
