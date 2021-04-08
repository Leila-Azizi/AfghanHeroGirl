using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 vel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = vel;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameCtrl.instance.PlayerDied(collision.gameObject);
            AudioController.instance.PlayerDie(collision.gameObject.transform.position);
            SFXCtrl.instance.Blood(collision.gameObject.transform.position);


        }
    }
}
