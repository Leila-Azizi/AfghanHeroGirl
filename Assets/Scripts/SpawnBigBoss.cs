using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBigBoss : MonoBehaviour {
	public bool canSpawn;
	public float delay;
	public GameObject boss;
	public Transform rightPos;
	public bool appearFromLeft;
	public Transform leftPos;

	void Update(){
		SpawnBoss ();
	}
	public void SpawnBoss(){
		if (canSpawn) {
			Invoke ("AppearBoss", delay);
			canSpawn = false;
		}
	}

	public void AppearBoss(){
		
		if (appearFromLeft) {
			
			boss.transform.position = leftPos.position;
			appearFromLeft = false;

		} else {
			
			boss.transform.position = rightPos.position;
		}
		boss.SetActive (true);
		FindObjectOfType<LeftEdgeCtrl> ().canFire= true;
		FindObjectOfType<RightEdgeCtrl> ().canFire= true;

	}
}
