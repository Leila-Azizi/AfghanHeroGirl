using System.Text.RegularExpressions;
using UnityEngine;
using System.Collections;
public class Controller2D : RaycastController {


	private SpriteRenderer sr;

    public bool isJumping;

	public float maxSlopeAngle = 80;

	public CollisionInfo collisions;
//    public GameObject enemyGem;
//    public Transform enemyGemPos;
	[HideInInspector]
	public Vector2 playerInput;

	//public event object PurpleEnemyCtrl { add; remove; }

	public override void Start() {
		base.Start ();
		collisions.faceDir = 1;

		sr = GetComponent<SpriteRenderer> ();
	}

	public void Move(Vector2 moveAmount, bool standingOnPlatform) {
		Move (moveAmount, Vector2.zero, standingOnPlatform);

	}

	public void Move(Vector2 moveAmount, Vector2 input, bool standingOnPlatform = false) {
		UpdateRaycastOrigins ();


		collisions.Reset ();
		collisions.moveAmountOld = moveAmount;
		playerInput = input;

//		if (playerInput > 0) {
//			sr.flipX = false;
//		} else {
//			sr.flipX = true;
//		}
//		if (!isJumping){
//			anim.SetInteger ("State", 1);
//	}

		if (moveAmount.y < 0) {
			DescendSlope(ref moveAmount);
		}

		if (moveAmount.x != 0) {
			collisions.faceDir = (int)Mathf.Sign(moveAmount.x);
		}

		HorizontalCollisions (ref moveAmount);
		if (moveAmount.y != 0) {
			VerticalCollisions (ref moveAmount);
		}

		transform.Translate (moveAmount);

		if (standingOnPlatform) {
			collisions.below = true;
		}
	}

	void HorizontalCollisions(ref Vector2 moveAmount) {
		float directionX = collisions.faceDir;
		float rayLength = Mathf.Abs (moveAmount.x) + skinWidth;

		if (Mathf.Abs(moveAmount.x) < skinWidth) {
			rayLength = 2*skinWidth;
		}

		for (int i = 0; i < horizontalRayCount; i ++) {
			Vector2 rayOrigin = (directionX == -1)?raycastOrigins.bottomLeft:raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.right * directionX, Color.red);

			if (hit) {
//                if(hit.collider.tag=="Enemy") {
//					GameCtrl.instance.PlayerDied(gameObject);
//                }
//                if(hit.collider.tag=="SavePoint"){
//
//                    GameCtrl.instance.lamp.GetComponent<Animator>().enabled=true;
//                    GameCtrl.instance.currentCheckPoint=hit.collider.gameObject;
//                    hit.collider.gameObject.SetActive(false);
//                }
                if(hit.collider.tag=="EnemyBullet"){
					hit.transform.gameObject.GetComponent<Collider2D> ().enabled = false;
                    print("EnemyBullet kill player");
                    GameCtrl.instance.PlayerDied(gameObject);
				//	StartCoroutine ("ResetFireCollider",hit.transform.gameObject);
					SFXCtrl.instance.Blood(hit.collider.transform.position);
					AudioController.instance.PlayerDie(transform.position);

                }
				

				if (hit.collider.tag == "GarbageCollector") {
                    print("Garbage kill player");
                    GameCtrl.instance.PlayerDied(gameObject);
				}

                if (hit.collider.tag == "GonalEnemy")
                {
                    hit.transform.gameObject.GetComponent<Collider2D>().enabled = false;
                    print("Gonal kill player");
                    GameCtrl.instance.PlayerDied(gameObject);
                    //	StartCoroutine ("ResetFireCollider",hit.transform.gameObject);
                    SFXCtrl.instance.Blood(hit.collider.transform.position);
                    AudioController.instance.PlayerDie(transform.position);


                }
              
				
				
				if (hit.collider.gameObject.tag == "Pendulum") {
                    GameCtrl.instance.PlayerDied(gameObject);
                    print("pendulum kill player");
                    AudioController.instance.PlayerDie (transform.position);
					SFXCtrl.instance.Blood (hit.transform.position);
				}

				if (hit.distance == 0) {
					continue;
				}

				float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

				if (i == 0 && slopeAngle <= maxSlopeAngle) {
					if (collisions.descendingSlope) {
						collisions.descendingSlope = false;
						moveAmount = collisions.moveAmountOld;
					}
					float distanceToSlopeStart = 0;
					if (slopeAngle != collisions.slopeAngleOld) {
						distanceToSlopeStart = hit.distance - skinWidth;
						moveAmount.x -= distanceToSlopeStart * directionX;
					}
					ClimbSlope(ref moveAmount, slopeAngle, hit.normal);
					moveAmount.x += distanceToSlopeStart * directionX;
				}

				if (!collisions.climbingSlope || slopeAngle > maxSlopeAngle) {
					moveAmount.x = (hit.distance - skinWidth) * directionX;
					rayLength = hit.distance;

					if (collisions.climbingSlope) {
						moveAmount.y = Mathf.Tan(collisions.slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(moveAmount.x);
					}

					collisions.left = directionX == -1;
					collisions.right = directionX == 1;
				}
			}
		}
		}


	void VerticalCollisions(ref Vector2 moveAmount) {
		float directionY = Mathf.Sign (moveAmount.y);
		float rayLength = Mathf.Abs (moveAmount.y) + skinWidth;

		for (int i = 0; i < verticalRayCount; i ++) {

			Vector2 rayOrigin = (directionY == -1)?raycastOrigins.bottomLeft:raycastOrigins.topLeft;
			rayOrigin += Vector2.right * (verticalRaySpacing * i + moveAmount.x);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);
		
			Debug.DrawRay(rayOrigin, Vector2.up * directionY,Color.red);
          //  if(hit.collider.gameObject.CompareTag("Pendulum")){
         //       Pendulum.OnPendulumTriggerWithPlayer();
          //  }a
			if (hit) {
                if(hit.collider.tag=="Ground" && !CameraFollow.isCameraChange)
                {
					Player.isJump = false;

                    PlatformController.onPlatform = false;
					FindObjectOfType<CameraFollow> ().verticalOffset = 1;
					//SFXCtrl.instance.PlayerLand (SFXCtrl.instance.playerLandsPos.position);
					//AudioController.instance.PlayerLands (hit.collider.transform.position);

				}
				if(hit.collider.tag=="TopGround"){
					Player.isJump = false;
					PlatformController.onPlatform = false;
					FindObjectOfType<CameraFollow> ().verticalOffset =-4;
				
				//	SFXCtrl.instance.PlayerLand (SFXCtrl.instance.playerLandsPos.position);
				//	AudioController.instance.PlayerLands (hit.collider.transform.position);
				//	Destroy (SFXCtrl.instance.sfx.playerLand);

				}
				
				if (hit.collider.tag == "MovingPlatform") {
					Player.isJump = false;
				}
                if(hit.collider.tag=="TopMovingPlatform"){
					PlatformController.onPlatform = true;
					Player.isJump = false;

                    FindObjectOfType<CameraFollow>().focusAreaSize.y=2;
					//SFXCtrl.instance.PlayerLand (SFXCtrl.instance.playerLandsPos.position);
					//AudioController.instance.PlayerLands (hit.collider.transform.position);

					//Destroy (SFXCtrl.instance.sfx.playerLand);

                }
                if(hit.collider.tag=="ButtomMovingPlatform"){
                    FindObjectOfType<CameraFollow>().focusAreaSize.y=2;
					Player.isJump = false;
					//SFXCtrl.instance.PlayerLand (SFXCtrl.instance.playerLandsPos.position);
					//AudioController.instance.PlayerLands (hit.collider.transform.position);

					//Destroy (SFXCtrl.instance.sfx.playerLand);


                }
                if (hit.collider.tag == "GrayHead") {
                    if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
                    {
                        Player.isJump = false;
                        Destroy(hit.collider.transform.parent.gameObject);
                        SFXCtrl.instance.GrayEnemyDied(hit.collider.gameObject.transform.position);
                        AudioController.instance.GrayEnemyDie(hit.collider.gameObject.transform.position);
                        GameCtrl.instance.ShowBigPrize(GameCtrl.instance.grayEnemy1.transform.position);
                    }
                    else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 3)
                    {
                        Player.isJump = false;
                        Destroy(hit.collider.transform.parent.gameObject);
                        SFXCtrl.instance.GreenMonesterDied(hit.collider.gameObject.transform.position);
                        AudioController.instance.GrayEnemyDie(hit.collider.gameObject.transform.position);
                        //GameCtrl.instance.ShowBigPrize(GameCtrl.instance.grayEnemy1.transform.position);
                    }
					
                }
                if (hit.collider.tag == "DropingPlatform") {
					Player.isJump = false;
                    print("Droping Platform !!!!!!!!!!!");
                    hit.collider.gameObject.GetComponent<DropingPlatform>().FallDown();
					//SFXCtrl.instance.PlayerLand (SFXCtrl.instance.playerLandsPos.position);
					//AudioController.instance.PlayerLands (hit.collider.transform.position);

				//	Destroy (SFXCtrl.instance.sfx.playerLand);
                }
                if (hit.collider.tag == "GarbageCollector") {
                    print("Garbage kill player");
                    GameCtrl.instance.PlayerDied (gameObject);
                }
                if (hit.collider.tag == "Fire") {
					SFXCtrl.instance.Fire (SFXCtrl.instance.playerLandsPos.position);
					Player.isJump = false;
					hit.transform.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					AudioController.instance.PlayerDie(transform.position);
					GameCtrl.instance.PlayerDied (gameObject);
					StartCoroutine ("ResetFireCollider",hit.transform.gameObject);

                }
         //       if(hit.collider.tag == "Bullet"){
        //            GameCtrl.instance.UpdateBulletCount();
		//			SFXCtrl.instance.PlayerBullet (hit.collider.transform.position);

		//			AudioController.instance.BulletPickup (transform.position);
        //            Destroy(hit.collider.gameObject);
        //        }
                
               
//                if(hit.collider.tag=="PurpleLeftSide"){
//                    print("left");
//                    PurpleEnemyCtr.instance.isleft=true;
//
//                }
//                if(hit.collider.tag=="PurpleRightSide"){
//                    PurpleEnemyCtr.instance.isRight=true;
//                    print("right");
//                }
				if (hit.collider.tag == "Simpler") {
					GameCtrl.instance.simpler.SetActive(true);
					hit.collider.gameObject.SetActive(false);
					SFXCtrl.instance.SimplerPickUp (hit.collider.transform.position);

					//Destroy (SFXCtrl.instance.sfx.simplerPickUp);
				}
                if(hit.collider.gameObject.tag=="Pendulum"){
                    print("pendulum kill player");
                    GameCtrl.instance.PlayerDied(gameObject);
					SFXCtrl.instance.Blood (transform.position);
                }
				if (hit.collider.tag == "Through") {
					if (directionY == 1 || hit.distance == 0) {
						continue;
					}
					if (collisions.fallingThroughPlatform) {
						continue;
					}
					if (playerInput.y == -1) {
						collisions.fallingThroughPlatform = true;
						Invoke ("ResetFallingThroughPlatform", .5f);
						continue;
					}
				} 

				moveAmount.y = (hit.distance - skinWidth) * directionY;
				rayLength = hit.distance;

				if (collisions.climbingSlope) {
					moveAmount.x = moveAmount.y / Mathf.Tan(collisions.slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(moveAmount.x);
				}

				collisions.below = directionY == -1;
				collisions.above = directionY == 1;
			}
		}

		if (collisions.climbingSlope) {
			float directionX = Mathf.Sign(moveAmount.x);
			rayLength = Mathf.Abs(moveAmount.x) + skinWidth;
			Vector2 rayOrigin = ((directionX == -1)?raycastOrigins.bottomLeft:raycastOrigins.bottomRight) + Vector2.up * moveAmount.y;
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin,Vector2.right * directionX,rayLength,collisionMask);

			if (hit) {
				float slopeAngle = Vector2.Angle(hit.normal,Vector2.up);
				if (slopeAngle != collisions.slopeAngle) {
					moveAmount.x = (hit.distance - skinWidth) * directionX;
					collisions.slopeAngle = slopeAngle;
					collisions.slopeNormal = hit.normal;
				}
			}
		}
	}
	IEnumerator ResetFireCollider(GameObject fire){
		yield return new WaitForSeconds (1f);
		fire.GetComponent<BoxCollider2D> ().enabled = true;
	}
	void ClimbSlope(ref Vector2 moveAmount, float slopeAngle, Vector2 slopeNormal) {
		float moveDistance = Mathf.Abs (moveAmount.x);
		float climbmoveAmountY = Mathf.Sin (slopeAngle * Mathf.Deg2Rad) * moveDistance;

		if (moveAmount.y <= climbmoveAmountY) {
			moveAmount.y = climbmoveAmountY;
			moveAmount.x = Mathf.Cos (slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign (moveAmount.x);
			collisions.below = true;
			collisions.climbingSlope = true;
			collisions.slopeAngle = slopeAngle;
			collisions.slopeNormal = slopeNormal;
		}
	}

	void DescendSlope(ref Vector2 moveAmount) {

		RaycastHit2D maxSlopeHitLeft = Physics2D.Raycast (raycastOrigins.bottomLeft, Vector2.down, Mathf.Abs (moveAmount.y) + skinWidth, collisionMask);
		RaycastHit2D maxSlopeHitRight = Physics2D.Raycast (raycastOrigins.bottomRight, Vector2.down, Mathf.Abs (moveAmount.y) + skinWidth, collisionMask);
		if (maxSlopeHitLeft ^ maxSlopeHitRight) {
			SlideDownMaxSlope (maxSlopeHitLeft, ref moveAmount);
			SlideDownMaxSlope (maxSlopeHitRight, ref moveAmount);
		}

		if (!collisions.slidingDownMaxSlope) {
			float directionX = Mathf.Sign (moveAmount.x);
			Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;
			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, -Vector2.up, Mathf.Infinity, collisionMask);

			if (hit) {
				float slopeAngle = Vector2.Angle (hit.normal, Vector2.up);
				if (slopeAngle != 0 && slopeAngle <= maxSlopeAngle) {
					if (Mathf.Sign (hit.normal.x) == directionX) {
						if (hit.distance - skinWidth <= Mathf.Tan (slopeAngle * Mathf.Deg2Rad) * Mathf.Abs (moveAmount.x)) {
							float moveDistance = Mathf.Abs (moveAmount.x);
							float descendmoveAmountY = Mathf.Sin (slopeAngle * Mathf.Deg2Rad) * moveDistance;
							moveAmount.x = Mathf.Cos (slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign (moveAmount.x);
							moveAmount.y -= descendmoveAmountY;

							collisions.slopeAngle = slopeAngle;
							collisions.descendingSlope = true;
							collisions.below = true;
							collisions.slopeNormal = hit.normal;
						}
					}
				}
			}
		}
	}
	/// <summary>
	/// Slides down max slope.
	/// </summary>
	/// <param name="hit">Hit.</param>
	/// <param name="moveAmount">Move amount.</param>
	void SlideDownMaxSlope(RaycastHit2D hit, ref Vector2 moveAmount) {

		if (hit) {
			float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
			if (slopeAngle > maxSlopeAngle) {
				moveAmount.x = Mathf.Sign(hit.normal.x) * (Mathf.Abs (moveAmount.y) - hit.distance) / Mathf.Tan (slopeAngle * Mathf.Deg2Rad);

				collisions.slopeAngle = slopeAngle;
				collisions.slidingDownMaxSlope = true;
				collisions.slopeNormal = hit.normal;
			}
		}

	}

	void ResetFallingThroughPlatform() {
		collisions.fallingThroughPlatform = false;
	}

	/// <summary>
	/// Control all colision that maybe ocure
	/// </summary>
	public struct CollisionInfo {
		public bool above, below;
		public bool left, right;

		public bool climbingSlope;
		public bool descendingSlope;
		public bool slidingDownMaxSlope;

		public float slopeAngle, slopeAngleOld;
		public Vector2 slopeNormal;
		public Vector2 moveAmountOld;
		public int faceDir;
		public bool fallingThroughPlatform;

		public void Reset() {
			above = below = false;
			left = right = false;
			climbingSlope = false;
			descendingSlope = false;
			slidingDownMaxSlope = false;
			slopeNormal = Vector2.zero;

			slopeAngleOld = slopeAngle;
			slopeAngle = 0;
		}
	}


}
