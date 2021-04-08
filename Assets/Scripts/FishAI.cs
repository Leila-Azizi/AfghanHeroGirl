using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour {
	public float speed;
	private Rigidbody2D rb;
	private SpriteRenderer sr;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		JumpFish ();
	}

	// Update is called once per frame
	void Update () {

		if (rb.velocity.y > 0) {

			sr.flipY = false;

		} else {

			sr.flipY = true;
		}

	}

	void JumpFish(){
		rb.AddForce (new Vector2(0,speed));
	}
}
