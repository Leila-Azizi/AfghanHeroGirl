using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEdgeCtrl : MonoBehaviour {

	Transform oldPos;
    // Use this for initialization
    void Awake () {
		
    }

    // Update is called once per frame
    void Update () {

    }

//    void OnTriggerEnter2D(Collider2D col){
//        if(gameObject.tag=="GrayLeftSide"){
////            print("left");
//            EnemyCtrl.instance.ShowAttackAnimation ();
//            gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer> ().flipX = true;
//
//        }else if(gameObject.tag=="GrayRightSide"){
//         //   print("Right");
//            EnemyCtrl.instance.ShowAttackAnimation ();
//            gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer> ().flipX = false;
//        }else if(gameObject.tag=="WizardRightSide"){
//            print("on Wizard right platrolling fire !!!!!!!!!!!");
//            EnemyCtrl.instance.ShowAttackAnimation ();
//            //FindObjectOfType<PatrollingBulletSpawner>().canFire=true;
//            gameObject.GetComponentInParent<PatrollingBulletSpawner>().canFire=true;
//            gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer> ().flipX = false;
//        }else if(gameObject.tag=="WizardLeftSide"){
//            print("on Wizard Left platrolling fire !!!!!!!!!!!");
//            EnemyCtrl.instance.ShowAttackAnimation ();
//            gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer> ().flipX = true;
//            // FindObjectOfType<PatrollingBulletSpawner>().canFire=true;
//            gameObject.GetComponentInParent<PatrollingBulletSpawner>().canFire=true;
//
//        }else if(gameObject.tag == "BluePatrollingSeaArea") {
//            print("on blue platrolling fire !!!!!!!!!!!");
//            gameObject.GetComponentInParent<PatrollingBulletSpawner>().canFire=true;
//            //FindObjectOfType<PatrollingBulletSpawner>().canFire=true;
//
//        }else if(gameObject.tag=="StuffArea" && col.gameObject.tag=="Player"){
//            print("Stuff Area!!!!!!!!!!!!");
//            foreach (Transform child in gameObject.transform) {
//                child.gameObject.GetComponent<DropingPlatform>().FallDown();
//            }
//
//        }
//
//    }

    void OnTriggerStay2D(Collider2D other){
		
        if(other.gameObject.CompareTag("Player")){
            print("Player in enemy see area");

            if (gameObject.tag == "EnemySeeArea" && !gameObject.transform.parent.gameObject.CompareTag("GrayEnemy"))
            {
                if (!gameObject.transform.parent.gameObject.CompareTag("LevelTwoBoss"))
                {
                    gameObject.transform.parent.gameObject.GetComponent<EnemyCtrl>().ShowAttackAnimation();
                    gameObject.transform.parent.gameObject.GetComponent<PetrolingEnemy>().enemyState = PetrolingEnemy.EnemyState.Attacking;
                    gameObject.transform.parent.gameObject.GetComponentInChildren<PatrollingBulletSpawner>().canFire = true;
                } else if (gameObject.transform.parent.gameObject.CompareTag("LevelTwoBoss"))
                {
                    print("level two boss ");
                    gameObject.transform.parent.gameObject.GetComponent<PetrolingEnemy>().enemyState = PetrolingEnemy.EnemyState.Attacking;
                    gameObject.transform.parent.gameObject.GetComponent<EnemyCtrl>().ShowAttackAnimation();
                    gameObject.transform.parent.gameObject.GetComponentInChildren<PatrollingBulletSpawner>().canFire = true;

                }

            }
            else if (gameObject.tag == "EnemySeeArea" && gameObject.transform.parent.gameObject.CompareTag("GrayEnemy"))
            {
                gameObject.transform.parent.gameObject.GetComponent<PetrolingEnemy>().enemyState = PetrolingEnemy.EnemyState.Attacking;
                gameObject.transform.parent.gameObject.GetComponent<EnemyCtrl>().ShowAttackAnimation();
            }
            else if (gameObject.tag == "StuffArea" && other.gameObject.tag == "Player") {
                //	AudioController.instance.StuffArea (other.gameObject.transform.position);
                foreach (Transform child in gameObject.transform) {
                    child.gameObject.GetComponent<DropingPlatform>().FallDown();
                }

            }
//			else if(gameObject.tag=="DangerArea" && other.gameObject.tag=="Player"){
//				//print ("Killing plaform");
//				foreach (Transform child in gameObject.transform) {
//					//float newPosY = child.gameObject.transform.position.y + 0.002f;
//					oldPos=child.gameObject.transform;
//					child.gameObject.transform.position=new Vector2(child.gameObject.transform.position.x,GameCtrl.instance.newPos.position.y);
//				}
//				//Invoke ("ResetPlatformPos",0.5f);
//			}
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            if(gameObject.tag=="EnemySeeArea" && !gameObject.transform.parent.gameObject.CompareTag("GrayEnemy"))
            {
                if (!gameObject.transform.parent.gameObject.CompareTag("LevelTwoBoss"))
                {
                    gameObject.transform.parent.gameObject.GetComponent<PetrolingEnemy>().enemyState = PetrolingEnemy.EnemyState.Patrolling;
                    gameObject.transform.parent.gameObject.GetComponent<PetrolingEnemy>().EnemyPatrol();
                    gameObject.transform.parent.gameObject.GetComponentInChildren<PatrollingBulletSpawner>().canFire = false;
                }
                else if (gameObject.transform.parent.gameObject.CompareTag("LevelTwoBoss"))
                {
                    gameObject.transform.parent.gameObject.GetComponent<PetrolingEnemy>().enemyState = PetrolingEnemy.EnemyState.Patrolling;
                    gameObject.transform.parent.gameObject.GetComponent<PetrolingEnemy>().GaryEnemyPatrolling();
                }
            }
            else if(gameObject.tag=="EnemySeeArea" && gameObject.transform.parent.gameObject.CompareTag("GrayEnemy"))
            {
                print("Gray not see player");
				gameObject.transform.parent.gameObject.GetComponent<PetrolingEnemy>().enemyState = PetrolingEnemy.EnemyState.Patrolling;
				gameObject.transform.parent.gameObject.GetComponent<PetrolingEnemy> ().GaryEnemyPatrolling ();


            }
        }
    }

//	void ResetPlatformPos(GameObject platform){
//		platform.transform.position = oldPos.position;
//		
//	}

}
