using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	private Animator anim;
	Player player;
	public float boostSpeed;
	public float fireTime;

	void Start () {
		fireTime = 0;
		player = GetComponent<Player> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal")*boostSpeed, Input.GetAxisRaw ("Vertical"));
	
		#if  !UNITY_IOS
		player.SetDirectionalInput(directionalInput);
		#endif
		if (Input.GetKeyDown (KeyCode.Space)) {
			player.OnJumpInputDown ();

		}

        if (Input.GetKeyUp (KeyCode.Space)) {
			//anim.SetInteger ("State",3);
		//	player.Jump();

		}
		fireTime -= Time.deltaTime;
		if(fireTime<=0){
			if(Input.GetButtonDown("Fire1")){
				player.FireBullet();
				fireTime = 1.5f;
			}

		}
        
	}
}
