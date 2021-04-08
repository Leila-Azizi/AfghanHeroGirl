using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffCtrl : MonoBehaviour {
     void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.CompareTag("Player")){
            
            GameCtrl.instance.PlayerDied(other.gameObject);
			AudioController.instance.PlayerDie (other.gameObject.transform.position);
			SFXCtrl.instance.Blood (other.gameObject.transform.position);
         }
     }

}
