using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthBar : MonoBehaviour {
	public GameObject levelBoss;
	Image healthbar;
	public float maxHealth;
	public static float health;


	void Awake(){
		
	}
	// Use this for initialization
	void Start () {

		healthbar = GetComponent<Image> ();
		health = maxHealth;
		

	}

	// Update is called once per frame
	void Update () {

		healthbar.fillAmount = health / maxHealth;

		if (health <=0) {
            //GameCtrl.instance.canOpenDoor=true;
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
            {
                GameCtrl.instance.appearBossIsDied = true;
                
                SFXCtrl.instance.AppearBossDied(GameObject.FindGameObjectWithTag("LevelOneBoss").transform.position);
                AudioController.instance.ApearBoss(levelBoss.transform.position);
                Destroy(levelBoss);
            }
            else if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 3)
            {
                
                SFXCtrl.instance.LevelTwoBossDied(levelBoss.transform.position);
                AudioController.instance.ApearBoss(levelBoss.transform.position);
                Destroy(levelBoss);

            }
			
		}

	}
}
