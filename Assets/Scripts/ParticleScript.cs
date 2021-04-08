using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {
	ParticleSystem ps;
	// Use this for initialization
	void OnEnable () {
		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
//	void OnParticleTrigger () {
//		print ("Triggers") ;
//	}
	void OnParticleCollision (GameObject other) {
		if(other.gameObject.CompareTag("Player")){
			GameCtrl.instance.PlayerDied (other.gameObject);
		}
	}



}
