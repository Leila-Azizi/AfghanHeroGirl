using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightEdgeCtrl : MonoBehaviour {

	public float delayForDisappearing,delay;
	public GameObject bossBullet;
	public Transform bulletSpawner;
	public bool canFire;

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player")) {
			if (!transform.parent.GetComponent<SpriteRenderer> ().flipX) {
				transform.parent.GetComponent<SpriteRenderer> ().flipX = true;
				transform.parent.GetComponent<Animator> ().SetInteger ("State", 1);
				if (canFire) {
					Instantiate (bossBullet, bulletSpawner.position, Quaternion.identity);
					canFire = false;

				}
			
				Invoke ("SetAnimToDisappear", delayForDisappearing);
			}
			else if (transform.parent.GetComponent<SpriteRenderer> ().flipX) {
				transform.parent.GetComponent<Animator> ().SetInteger ("State", 1);
				if (canFire) {
					Instantiate (bossBullet, bulletSpawner.position, Quaternion.identity);
					canFire = false;

				}
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