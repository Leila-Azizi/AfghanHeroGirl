using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEdgeCtrl : MonoBehaviour {


	public float delayForDisappearing,delay;
	public GameObject bossBullet;
	public bool canFire;
	public Transform bulletSpawner;

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player")) {
			if (!transform.parent.GetComponent<SpriteRenderer> ().flipX) {
				
				transform.parent.GetComponent<Animator> ().SetInteger ("State", 1);

				if (canFire) {
					Instantiate (bossBullet, bulletSpawner.position, Quaternion.identity);
					canFire = false;
				}
				FindObjectOfType<SpawnBigBoss> ().appearFromLeft = true;

				Invoke ("SetAnimToDisappear", delayForDisappearing);



			}
			else if (transform.parent.GetComponent<SpriteRenderer> ().flipX) {
				transform.parent.GetComponent<SpriteRenderer> ().flipX = false;
				transform.parent.GetComponent<Animator> ().SetInteger ("State", 1);
				if (canFire) {
					Instantiate (bossBullet, bulletSpawner.position, Quaternion.identity);
					canFire = false;

				}
				FindObjectOfType<SpawnBigBoss> ().appearFromLeft = true;

				Invoke ("SetAnimToDisappear", delayForDisappearing);

			}
		}
	}

	public void SetAnimToDisappear(){
		
		transform.parent.GetComponent<Animator> ().SetInteger ("State", 2);

		Invoke ("DisappearBoss",delay);

	}

	public void DisappearBoss(){
		transform.parent.GetComponent<Animator> ().SetInteger ("State", 0);
		FindObjectOfType<SpawnBigBoss> ().canSpawn = true;
		transform.parent.gameObject.SetActive (false);

	}
}
