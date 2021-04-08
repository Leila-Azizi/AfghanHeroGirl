using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCtrl : MonoBehaviour {
    public GameObject lamp;
    //public int savePointNumber;
    bool isOn;
    void Start () {
        isOn = true;

    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            print("check and Save");
           // lamp.GetComponent<Animator> ().enabled = true;
			lamp.gameObject.SetActive(true);
            GameCtrl.instance.currentCheckPoint = gameObject;
           // ProgressBarCtrl.instance.UpdateProgressBar(savePointNumber);
            SFXCtrl.instance.GrayEnemyDied(lamp.gameObject.transform.position);
            AudioController.instance.MagicBottlePickup(transform.position);
            //gameObject.SetActive(false);
          //  play ();
           // isOn = false;
        }
    }
//    void play(){
//        if (isOn) {
//            SFXCtrl.instance.SavePoint (lamp.transform.position);
//            AudioController.instance.KeyFound (lamp.transform.position);
//        }
//    }
}
