using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    private Rigidbody2D rb;
    public Vector2 vel;
    public GameObject pos;
    public float resetTime;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pos = GameObject.Find("pos") as GameObject;
    }
    // Start is called before the first frame update
    void start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = vel;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        print("klms");
    }

    // Update is called once per frame
    void Update()
    {
        if (target!=null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (target.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (target.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;

            }
        }
        resetTime -= Time.deltaTime;
        if (resetTime <= 0)
        {
            ResetPosition();
            resetTime = 5f;
        }



    }
    public void ResetPosition()
    {
        gameObject.transform.position = pos.transform.position;

        gameObject.SetActive(false);
        // transform.position = pos.position;
        print("Deactivated");
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("enemyFollow kill player");
            GameCtrl.instance.PlayerDied(collision.gameObject);
            AudioController.instance.PlayerDie(collision.gameObject.transform.position);
            SFXCtrl.instance.Blood(collision.gameObject.transform.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") && gameObject.tag!="GonalEnemy")
        {
            Destroy(gameObject);
            SFXCtrl.instance.GrayEnemyDied(collision.gameObject.transform.position);
            AudioController.instance.GrayEnemyDie(collision.gameObject.transform.position);


        }

    }

    
}