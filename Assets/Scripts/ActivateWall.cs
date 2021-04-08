using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActivateWall : MonoBehaviour
{
    public GameObject enterWall;
    public GameObject exitWall;

    void ActiveCompletePanel()
    {
        GameCtrl.instance.ui.levelCompletePanel.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("EnterWall"))
            {
                enterWall.SetActive(true);
                SFXCtrl.instance.GrayEnemyDied(enterWall.transform.position);
                AudioController.instance.MagicBottlePickup(transform.position);
                Destroy(gameObject);
            }
           else if (gameObject.CompareTag("ExitWall"))
            {
                exitWall.SetActive(false);
                SFXCtrl.instance.GrayEnemyDied(exitWall.transform.position);
                AudioController.instance.MagicBottlePickup(transform.position);
                Invoke("ActiveCompletePanel", 1f);
                Destroy(gameObject,1.5f);
            }
         
        }
    }


}
