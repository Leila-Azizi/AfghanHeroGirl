using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingBullet : MonoBehaviour
{
	Rigidbody2D rb;
	public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject,4f);
    }

    // Update is called once per frame
    void Update()
    {
		rb.velocity = direction;
    }
}
