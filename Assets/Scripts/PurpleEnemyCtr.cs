using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PurpleEnemyCtr : MonoBehaviour{
    public static PurpleEnemyCtr instance;
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public bool isleft,isRight;
    Animator anim;

    void Awake(){
        if(instance==null){
            instance=this;
        }
    }

    // Use this for initialization
    void Start () {
        rb=GetComponent <Rigidbody2D>();
        sr=GetComponent <SpriteRenderer>();
        anim=GetComponent <Animator>();

    }

    // Update is called once per frame
    void Update () {
        if(isleft){
            isRight=false;
            rb.velocity=new Vector2(-1,0);
            sr.flipX=true;
            anim.SetInteger ("State", 1);
        }else if(isRight){
            isleft=false;
            sr.flipX=false;
            rb.velocity=new Vector2(1,0);
            anim.SetInteger ("State", 1);
        }



    }

}
