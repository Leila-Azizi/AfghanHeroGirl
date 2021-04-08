using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCtrl : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
            print("Garbage kill player");
            GameCtrl.instance.PlayerDied (other.gameObject);
			print("player");

		}else if (other.gameObject.CompareTag ("Stuff")) {
			Destroy (other.gameObject);

		}else if (other.gameObject.CompareTag ("Enemy")) {
			Destroy (other.gameObject);

		}else{
				//Destroy (other.gameObject);
			}
	
		}
}

