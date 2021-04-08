using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SimplerCtrl : MonoBehaviour {
	public GameObject platform1,platform2,topStuffPlatform,buttomStuffPlatform,simplerPlatform;
	void Start(){
		platform1 = GameObject.Find ("TopMovingPlatform");
		platform2 = GameObject.Find ("ButtomMovingPlatform");
		topStuffPlatform = GameObject.Find ("TopStuffPlatform");
		buttomStuffPlatform = GameObject.Find ("ButtomStuffPlatform");
		simplerPlatform = GameObject.Find ("Teleport 2");


	}

    public void RotatePlatform(){
		topStuffPlatform.SetActive (false);
		buttomStuffPlatform.SetActive (false);
        platform1.gameObject.transform.eulerAngles= new Vector3(0,0,0);
        platform2.gameObject.transform.eulerAngles= new Vector3(0,0,0);
        platform1.GetComponent<PlatformController>().enabled=true;
        platform2.GetComponent<PlatformController>().enabled=true;

    }
    public void ActivePlatform()
    {

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            simplerPlatform.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            print("simpler");
			if(SceneManager.GetActiveScene().buildIndex==2){
			SFXCtrl.instance.SimplerPickUp(transform.position);
			AudioController.instance.SimplerPickup (transform.position);
            RotatePlatform();
            gameObject.SetActive(false);
			}else if(SceneManager.GetActiveScene().buildIndex==3){
				SFXCtrl.instance.SimplerPickUp(transform.position);
				AudioController.instance.SimplerPickup (transform.position);
				ActivePlatform ();
				gameObject.SetActive(false);
			}
        }
    }

}
