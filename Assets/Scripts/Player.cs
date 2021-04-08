using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {
	public static Player instance;
	//public LayerMask whatIsGrounded;
	public float boxWidth;
	public float boxHeight;
	public float doubleJumpDelay;
	public bool canDoubleJump;
	public float jumpSpeed;
	public bool isGrounded;
	public Transform feet;

    public GameObject leftBullet;
    public GameObject rightBullet;
    public Transform leftBulletSpawner;
    public Transform rightBulletSpawner;
	//public Sprite openJumper,closeJumper;
	//public LayerMask collisionMask;
    public bool isStuck;
    public bool isMoveLeft,isMoveRight;

	public Controller2D collider2d;
	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;

	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	public float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	public Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;
	private Animator anim;
	private SpriteRenderer sr;
	Vector2 directionalInput;
	bool wallSliding;
	int wallDirX;
	public static  bool isJump;
	public static bool isAttack;
    public bool x;
	void Awake(){
		if(instance==null){
			instance = this;
		}
	}
	void Start() {
        GetComponent<Text>().text = "Afghan Hero Girl";
		isJump = false;

		isAttack = false;
		controller = GetComponent<Controller2D> ();

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
	}



	void Update() {
        print(gravity);
           CalculateVelocity();
     
		controller.Move (velocity * Time.deltaTime, directionalInput);
		if (controller.collisions.above || controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
			} else {
				velocity.y = 0;
			}
		}
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2 && transform.position.x >= 144f) {
           // print("Camera follow");
           // FindObjectOfType<CameraFollow>().verticalOffset = -6;
        }
	}

	public void SetDirectionalInput (Vector2 input) {
		directionalInput = input;
		if(directionalInput.x==0 && directionalInput.y==0 && isJump==false && !isAttack){
            isStuck = true;
            anim.SetBool("IsRun", false);
		}
		else if(directionalInput.x==0 && directionalInput.y==1 ){
		//	anim.SetInteger ("State", 2);
            isStuck = false;

        }
        else if(directionalInput.x==0 && directionalInput.y==-1 && isJump==false && !isAttack){
            anim.SetBool("IsRun", false);
            isStuck = true;

        }
        else if(directionalInput.x>=1 && directionalInput.y==0 ){
            anim.SetBool("IsRun", true);
            sr.flipX = false;
            isStuck = false;
        }
        else if(directionalInput.x<=-1 && directionalInput.y==0 ){
            anim.SetBool("IsRun", true);
            sr.flipX = true;
            isStuck = false;

        }



    }
    void ResetJump()
    {
        isJump = false;
        anim.ResetTrigger("Jump");
    }
    public void ResetJumpAndRun () {
        anim.SetBool("IsRun", false);
    }
    public void OnJumpInputDown() {
		isJump = true;

        anim.SetTrigger("Jump");
        Invoke("ResetJump",0.7f);
		AudioController.instance.PlayerJump (transform.position);

		if (controller.collisions.below) {
			velocity.y = maxJumpVelocity;
			canDoubleJump = true;
        }
        else {
			if (canDoubleJump) {
				canDoubleJump = false;
				velocity.y = maxJumpVelocity;
            }
        }	
	}

	public void OnJumpInputUp() {
		//AudioController.instance.PlayerJump (transform.position);

		if (velocity.y > minJumpVelocity) {
			velocity.y = minJumpVelocity;
		}
	}
		


	void CalculateVelocity() {
		float targetVelocityX = directionalInput.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;

	}


    public void FireBullet(){
        
		if(GameCtrl.instance.data.bulletCounter>0){
            anim.SetTrigger("Attack");
			isAttack = true;
			AudioController.instance.PlayerFire(transform.position);
			GameCtrl.instance.data.bulletCounter -= 1;
			GameCtrl.instance.ui.bulletText.text = ""+GameCtrl.instance.data.bulletCounter;
        if (sr.flipX) {
            Instantiate (leftBullet, leftBulletSpawner.transform.position, Quaternion.identity);

        } else {
            Instantiate (rightBullet, rightBulletSpawner.transform.position, Quaternion.identity);
        }
		}
		Invoke ("ResetAttack",0.3f);
        
    }
    public void ResetAttack()
    {
        anim.ResetTrigger("Attack");
        isAttack = false;
    }
    public void MoveLeft(){

        isMoveLeft = true;
    }

    public void MoveRight(){

        isMoveRight = true;
    }
}
