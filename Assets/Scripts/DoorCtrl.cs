using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
	
	void OnTriggerEnter2D(Collider2D other ){
		if (other.gameObject.CompareTag ("Player")) {
			gameObject.GetComponent<Animator> ().enabled = true;
			other.gameObject.SetActive (false);
			GameCtrl.instance.ui.levelCompletePanel.SetActive (true);
			//UnityEngine.SceneManagement.SceneManager.LoadScene (4);
		}
	}
}
