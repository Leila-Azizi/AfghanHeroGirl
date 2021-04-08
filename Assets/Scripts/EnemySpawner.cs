using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // Use this for initialization
    public GameObject enemy;
    public Transform pos;
     public float spawnTime;
     bool canSpawn;

    // Use this for initialization
    void Start()
    {
       
        canSpawn = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        if (canSpawn)
        {
            StartCoroutine("SpawnEnemy");
        }

    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy,pos.position, Quaternion.identity);
        canSpawn = false;
        yield return new WaitForSeconds(spawnTime);
       canSpawn = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if (collision.tag=="Player") {
        //    canSpawn = true;
       // }
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
      //  canSpawn = false;
  
    }
}

