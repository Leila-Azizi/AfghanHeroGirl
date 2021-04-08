using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCameraFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (BossHealthBar.health<=0)
                {
                    GameCtrl.instance.ui.levelCompletePanel.SetActive(true);
                }
            }
            if (GameCtrl.instance.data.soldeirCounter==0 && GameCtrl.instance.appearBossIsDied){
				Camera.main.gameObject.GetComponent<CameraFollow> ().enabled = false;
                

			}

		}
	}
    
}
