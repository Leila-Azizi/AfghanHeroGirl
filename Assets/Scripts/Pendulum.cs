using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {

    Rigidbody2D rb;
    public float leftPushRang;
    public float rightPushRang;
    public float velocityThreshold;

    

// Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        
rb.angularVelocity = velocityThreshold;
    }

    

// Update is called once per frame
    void Update () {

        Push ();
    }

   

 public void Push(){

        if (transform.rotation.z > 0
        && transform.position.z < rightPushRang
        && (rb.angularVelocity > 0)
        && rb.angularVelocity < velocityThreshold)
        {
            rb.angularVelocity = velocityThreshold;

        }
		else if(transform.rotation.z < 0
        && transform.position.z > leftPushRang
        && (rb.angularVelocity < 0)
        && rb.angularVelocity > velocityThreshold*-1)
        {
            rb.angularVelocity = velocityThreshold*-1;
        }
    }
//    public static void OnPendulumTriggerWithPlayer(){
//        print("Pendulum Triggrer with player");
//
//    }
}
