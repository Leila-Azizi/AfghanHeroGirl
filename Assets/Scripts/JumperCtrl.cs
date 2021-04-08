using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperCtrl : MonoBehaviour {
 

	public bool onTop;
 	Animator anim;

    GameObject player;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}

	public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null && onTop)
            {
                AudioController.instance.Trampoline(transform.position);
                anim.SetBool("isJumper",true);
                other.gameObject.GetComponent<Animator>().SetTrigger("Jump");
                Jump(player);
            }

        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onTop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onTop = false;
 
        }
    }

    void Jump(Player player)
    {
        player.velocity.y = 33;

    }
    void ResetAnimation()
    {
        anim.SetBool("isJumper", false);

    }
}
