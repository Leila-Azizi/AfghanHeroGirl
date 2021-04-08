using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingPlatform : MonoBehaviour {
    Rigidbody2D rigid;
    Vector3 crPos;
    public float delay;

    void Start() {

        rigid = GetComponent<Rigidbody2D>();
        crPos = transform.position;
    }

    // Update is called once per frame
    void Update() {

    }

   public void FallDown(){
       Invoke("CallFallDown",delay);

    }

//    void ResetPlatformsPosition(){
//		transform.position = crPos;
//        gameObject.SetActive(true);
//        rigid.bodyType = RigidbodyType2D.Kinematic;
//        
//    }
    void CallFallDown(){
//        print("CallFallDown");
        rigid.bodyType = RigidbodyType2D.Dynamic;
		if(gameObject.CompareTag("Stuff")){
			Invoke ("DestroyStuff",3f);
		}
        if(gameObject.CompareTag("DropingPlatform")){
			StartCoroutine ("ResetPlatform",gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Fire")){
            gameObject.SetActive(false);
        }
    }
	void DestroyStuff(){
		Destroy (gameObject);
	}
	IEnumerator ResetPlatform(GameObject platform){
		yield return new WaitForSeconds (3f);
		rigid.bodyType = RigidbodyType2D.Static;

		transform.position = crPos;
		gameObject.SetActive(true);

	}

}