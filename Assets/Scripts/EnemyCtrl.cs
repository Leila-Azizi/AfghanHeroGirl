using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {

    Animator anim;

    public static EnemyCtrl instance;
    void Awake(){
        if (instance == null) {
            instance = this;
        }
		anim = GetComponent<Animator> ();

    }
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

    }

    public void ShowAttackAnimation(){
		if(anim!=null)
        anim.SetInteger ("State",1);
      //  print("iii!!!!!!!!!");

    }



}
