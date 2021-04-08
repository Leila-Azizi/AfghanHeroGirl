using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerBullet : MonoBehaviour
{
	private Rigidbody2D rb;
	public Vector2 vel;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = vel;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag=="GrayEnemy")
        {
            if (SceneManager.GetActiveScene().buildIndex==3)
            {
                Destroy(other.gameObject);
                SFXCtrl.instance.GreenMonesterDied(other.transform.position);
                AudioController.instance.GrayEnemyDie(other.gameObject.transform.position);
                Destroy(gameObject);
            }
           

        }
		if (other.gameObject.tag == "WizardEnemy") {
			Destroy (other.gameObject);
			AudioController.instance.EnemyDie(other.gameObject.transform.position);

			SFXCtrl.instance.purpleWizardDied (other.gameObject.transform.position);
			Vector3 pos = other.gameObject.transform.position;
			pos.y -= 0.6f;
			GameCtrl.instance.ShowBigPrize (pos);
			Destroy (gameObject);
		} else if (other.gameObject.tag == "BlueEnemy") {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                
                SFXCtrl.instance.BlueEnemyDied(other.gameObject.transform.position);
                AudioController.instance.EnemyDie(other.gameObject.transform.position);

                Destroy(gameObject);
                Vector3 pos = other.gameObject.transform.position;
                Destroy(other.gameObject);
                pos.y -= 0.6f;
                GameCtrl.instance.ShowBigPrize(pos);
            }
			else if (SceneManager.GetActiveScene().buildIndex == 3)
            {

                SFXCtrl.instance.GolemDied(other.gameObject.transform.position);
                AudioController.instance.EnemyDie(other.gameObject.transform.position);

                Destroy(gameObject);
                Vector3 pos = other.gameObject.transform.position;
                Destroy(other.gameObject);
                pos.y -= 0.6f;
                GameCtrl.instance.ShowBigPrize(pos);
            }


        }

        else if (other.gameObject.CompareTag ("LevelOneBoss")) {
			print ("level One Boss");
			BossHealthBar.health -= 5;
			Destroy (gameObject);
		}
        else if (other.gameObject.CompareTag("LevelTwoBoss") && SceneManager.GetActiveScene().buildIndex == 3)
        {
            print("Level Two Boss");
            other.GetComponent<BossHealthManager>().giveDamage(10);
            Destroy(gameObject);
        }

    }
}
