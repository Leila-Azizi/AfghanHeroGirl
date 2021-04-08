using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	public GameObject player;
	Player playerControler;
	Controller2D Controler;
    public float fireTime;
    // Start is called before the first frame update
    void Start()
    {
		playerControler = player.GetComponent<Player> ();
		Controler = player.GetComponent<Controller2D> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTime -= Time.deltaTime;
    }
	public void JumpPlayer(){
		playerControler.OnJumpInputDown ();
    }
  
    public void FirePlayer (){
        
        if (fireTime <= 0) {
            playerControler.FireBullet();
            fireTime = 1.5f;
        }
		
	}
	public void MoveRight(){
        playerControler.isStuck = false;

        playerControler.MoveRight ();
		playerControler.SetDirectionalInput (new Vector2(1,0));
	}
	public void MoveLeft() { 
                playerControler.isStuck = false;

		playerControler.MoveLeft();
		playerControler.SetDirectionalInput (new Vector2(-1,0));
	}
	public void StopMOve(){
        playerControler.isStuck = true;
        playerControler.ResetJumpAndRun();
        playerControler.SetDirectionalInput (new Vector2(0,0));
	}
}
