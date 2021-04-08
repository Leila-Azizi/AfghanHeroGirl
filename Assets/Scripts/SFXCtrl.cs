using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour {

    public static SFXCtrl instance;
	public Transform playerLandsPos;
    public SFX sfx;

    void Awake(){
        if(instance==null)
        {
            instance=this;
        }
    }

	public void AppearBossDied(Vector3 pos){
		Instantiate (sfx.appearBossDied,pos,Quaternion.identity);
		//Instantiate (sfx.appearBossDied1,pos,Quaternion.identity);
	}
	public void purpleWizardDied(Vector3 pos){
		Instantiate (sfx.purpleWizardDied,pos,Quaternion.identity);
	}
	public void BlueEnemyDied(Vector3 pos){
		Instantiate (sfx.BlueEnemyDied,pos,Quaternion.identity);
	}
	public void GrayEnemyDied(Vector3 pos){
		Instantiate (sfx.grayEnemyDied,pos,Quaternion.identity);
	}
    public void GreenMonesterDied(Vector3 pos)
    {
        Instantiate(sfx.GreenMonester, pos, Quaternion.identity);
    }
    public void Heart(Vector3 pos){
        Instantiate(sfx.heart,pos,Quaternion.identity);
    }
    public void GoAwayCrew(Vector3 pos)
    {
        Instantiate(sfx.goAwayCrew, pos, Quaternion.identity);
    }
    public void MagicBottle(Vector3 pos){
		Instantiate (sfx.magicBottle,pos,Quaternion.identity);
	}
	public void BigPrize(Vector3 pos){
		Instantiate (sfx.bigPrize,pos,Quaternion.identity);
	}
	public void SimplerPickUp(Vector3 pos){
		Instantiate(sfx.simplerPickUp,pos,Quaternion.identity);
	}
//	public void SimplerShow(Vector3 pos){
//		Instantiate(sfx.SimplerShow,pos,Quaternion.identity);
//	}
	public void Box(Vector3 pos){
		Instantiate(sfx.box,pos,Quaternion.identity);
	}
	public void PlayerBullet(Vector3 pos){
		Instantiate (sfx.playerBullet,pos,Quaternion.identity);
	}
	public void PlayerBulletPickUp(Vector3 pos){
		Instantiate (sfx.playerBulletpickup,pos,Quaternion.identity);
	}
	public void SavePoints(Vector3 pos){
		Instantiate (sfx.SavePoints,pos,Quaternion.identity);
	}

	public void Fire(Vector3 pos){
		Instantiate (sfx.fire,pos,Quaternion.identity);
	}
	public void Servicer(Vector3 pos){
		Instantiate (sfx.servitor,pos,Quaternion.identity);
	}

	public void Blood(Vector3 pos){
		Instantiate (sfx.blood,pos,Quaternion.identity);
	}
	public void PlayerLand(Vector3 pos){
		Instantiate (sfx.playerLand,pos,Quaternion.identity);
	}


	public void OpenDoor(Vector3 pos){
		Instantiate (sfx.openDoor,pos,Quaternion.identity);
	}
    public void Explosion(Vector3 pos)
    {
        Instantiate(sfx.explosion, pos, Quaternion.identity);
    }
    public void LevelTwoBossDied(Vector3 pos)
    {
        Instantiate(sfx.levelTwoBossDied, pos, Quaternion.identity);
    }
    public void GolemDied(Vector3 pos)
    {
        Instantiate(sfx.golemDie, pos, Quaternion.identity);
    }
    

}
