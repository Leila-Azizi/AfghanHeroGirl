using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Bullet")
        {
            if (collision.tag == "Player")
            {
                GameCtrl.instance.UpdateBulletCount();
                SFXCtrl.instance.PlayerBullet(gameObject.transform.position);
                AudioController.instance.BulletPickup(gameObject.transform.position);
                Destroy(gameObject);
            }
        } else if (gameObject.tag == "Coin")
        {
            if (collision.tag == "Player")
            {
                GameCtrl.instance.UpdateCionCount();
                SFXCtrl.instance.PlayerBullet(gameObject.transform.position);
                AudioController.instance.CoinPickup(gameObject.transform.position);
                Destroy(gameObject);
            }

        }
        else if (gameObject.tag == "Heart")
        {
            if (collision.tag == "Player")
            {
                GameCtrl.instance.UpdateHeartCount();
                print("Heart");
                AudioController.instance.HeartPickup(gameObject.transform.position);
                SFXCtrl.instance.Heart(gameObject.transform.position);
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "BigPrize")
        {
            if (collision.tag=="Player")
            {
                GameCtrl.instance.UpdateBigPrizeCount();
                SFXCtrl.instance.BigPrize(gameObject.transform.position);
                AudioController.instance.BigPrizePickup(gameObject.transform.position);
                Destroy(gameObject);
            }
         
        }
        else if (gameObject.tag == "MagicBottel")
        {
            if (collision.tag=="Player") {
                SFXCtrl.instance.MagicBottle(gameObject.transform.position);
                AudioController.instance.MagicBottlePickup(transform.position);
                GameCtrl.instance.UpdateMagicBottleCount();
                Destroy(gameObject);

            }

        }
        else if (gameObject.tag == "Simpler")
        {
            GameCtrl.instance.simpler.SetActive(true);
            gameObject.SetActive(false);
            SFXCtrl.instance.SimplerPickUp(gameObject.transform.position);
            AudioController.instance.SimplerPickup(gameObject.transform.position);

        }



    }
}
