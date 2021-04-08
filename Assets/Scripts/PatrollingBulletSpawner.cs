using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingBulletSpawner : MonoBehaviour
{
    public static PatrollingBulletSpawner instance;
    public Transform leftSpawn, rightSpawn;
    public bool canLeftSpawn, canRightSpawn;
    public GameObject leftBullet,rightBullet;
    public float time;
    private float fireTime;
    public bool canFire;

void Awake(){
    if(instance==null){
        instance=this;
    }
}
    // Start is called before the first frame update
    void Start()
    {
        fireTime=time;
        canFire=false;

    }

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime;
        if(time<=0){
            Invoke("FirePatrollingEnemy",0.01f);
            time=1;
        }
    }

    public void FirePatrollingEnemy(){
        if(canFire){
            if(gameObject.GetComponentInParent<SpriteRenderer>().flipX){
                Instantiate (leftBullet,leftSpawn.position,Quaternion.identity);
            }else if(!gameObject.GetComponentInParent<SpriteRenderer>().flipX){
                Instantiate (rightBullet,rightSpawn.position,Quaternion.identity);

            }
        }

    }

}
