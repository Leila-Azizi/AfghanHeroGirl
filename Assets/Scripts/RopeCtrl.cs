using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCtrl : MonoBehaviour
{
    public Shaker shaker;
   public float duration = 1f;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet")) {
           gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        if (collision.CompareTag("Dirt")) {
          GameObject.Find("EnemySpawner").GetComponent<SpawnGonal>().isDirtActive = false;
            shaker.Shake(duration);
            AudioController.instance.BombExplosion(transform.position);
            Destroy(gameObject,0.7f);
            SFXCtrl.instance.Explosion(collision.transform.position);
            // Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
