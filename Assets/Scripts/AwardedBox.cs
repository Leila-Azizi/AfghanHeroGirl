using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AwardedBox : MonoBehaviour {
   public Sprite openBox;
    public GameObject simpler;

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag ("PlayerBullet")) {
         gameObject.GetComponent<SpriteRenderer>().sprite=openBox;
			Vector3 pos = gameObject.transform.position;
			pos.y += 0.8f;
			AudioController.instance.BoxOpen (transform.position);
			SFXCtrl.instance.Box (pos);
			Invoke ("ActiveSimpler",0.8f);
			gameObject.GetComponent<Collider2D> ().enabled = false;
            Destroy(col.gameObject);
		//	SFXCtrl.instance.SimplerShow (pos);
        }
    }
	public void ActiveSimpler(){
		simpler.gameObject.SetActive(true);

	}
}
