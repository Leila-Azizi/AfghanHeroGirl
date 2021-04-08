using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrolingEnemy : MonoBehaviour {

    public static PetrolingEnemy instance;
    public Transform leftEdge, rightEdge;
    public GameObject leftSeaArea,rightSeaArea;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private float originalSpeed;
    public float minDelay, maxDalay;
    public float speed;
    private bool canTurn;
	public EnemyState enemyState;

    public enum EnemyState{
        Attacking,
        Patrolling
    }
    void Awake(){
        if(instance ==null){
            instance=this;
        }
    }
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D> ();
        sr = GetComponent<SpriteRenderer> ();
        anim=GetComponent<Animator>();
        SetStartingDirection ();
        canTurn = true;
        originalSpeed=speed;
        enemyState = EnemyState.Patrolling;

    }

    // Update is called once per frame
    void Update () {
        if(!gameObject.CompareTag("GrayEnemy") && !gameObject.CompareTag("LevelTwoBoss"))
        {
           if(enemyState==EnemyState.Attacking){
               	   EnemyAttack();
            }else if(enemyState==EnemyState.Patrolling){
	               Move ();
	           	   FlipOnEdges ();
           }
        }
		else if(gameObject.CompareTag("GrayEnemy") || gameObject.CompareTag("LevelTwoBoss"))
        {
            Move ();
			if(enemyState==EnemyState.Patrolling)
           		 FlipOnEdges ();
        }


    }


    void OnDrawGizmos(){

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine (leftEdge.position,rightEdge.position);

    }

    void Move(){

        Vector2 temp = rb.velocity;
        temp.x = speed;
        rb.velocity = temp;
    }

    void SetStartingDirection(){
        if(speed<0){
            sr.flipX = true;
            leftSeaArea.SetActive(true);
            rightSeaArea.SetActive(false);
        }
        else if(speed>0){
            sr.flipX = false;
            rightSeaArea.SetActive(true);
            leftSeaArea.SetActive(false);

        }
    }

    void FlipOnEdges(){
       //speed=originalSpeed;
        if (sr.flipX && transform.position.x <= leftEdge.position.x ) {
                if (canTurn) {
                    canTurn = false;
                    originalSpeed = -speed;
                    speed = 0;
                    StartCoroutine("TurnRight", originalSpeed);
                }


            }
            else if (!sr.flipX && transform.position.x >= rightEdge.position.x ) {

                if (canTurn) {
                    canTurn = false;
                    originalSpeed = -speed;
                    speed = 0;
                    StartCoroutine("TurnLeft", originalSpeed);
                }


            }

    }

    IEnumerator TurnLeft(float originalSpeed){
		anim.SetInteger ("State",0);
		yield return new WaitForSeconds (Random.Range(minDelay,maxDalay));
        anim.SetInteger ("State",2);
		sr.flipX = true;
        leftSeaArea.SetActive(true);
        rightSeaArea.SetActive(false);
		speed = originalSpeed;
		canTurn = true;

    }

    IEnumerator TurnRight(float originalSpeed){
            anim.SetInteger ("State",0);
	        yield return new WaitForSeconds (Random.Range(minDelay,maxDalay));
            anim.SetInteger ("State",2);
	        sr.flipX = false;
            rightSeaArea.SetActive(true);
            leftSeaArea.SetActive(false);
	        speed = originalSpeed;
	        canTurn = true;
    }

   public void EnemyAttack(){
       EnemyCtrl.instance.ShowAttackAnimation();
       originalSpeed=speed;
       rb.velocity = Vector2.zero;
       speed=0;


   }

    public void EnemyPatrol(){

            anim.SetInteger ("State",2);
            if(sr.flipX){
                speed = -2;
            }else if(!sr.flipX){
                speed = 2;
            }
            rb.velocity = new Vector2(speed,0);
            enemyState = EnemyState.Patrolling;
            FlipOnEdges();

    }

   public void GaryEnemyPatrolling(){
       anim.SetInteger ("State",2);
   }

	public void OnCollisionEnter2D(Collision2D other){
		if(gameObject.CompareTag("GrayEnemy") || gameObject.CompareTag("LevelTwoBoss")){
			if(other.gameObject.CompareTag("Player")) {
			    GameCtrl.instance.PlayerDied (other.gameObject);
				enemyState = EnemyState.Patrolling;
		    }
		}
	}

}
