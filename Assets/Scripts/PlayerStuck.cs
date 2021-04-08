using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour {

    public GameObject player;
    Player plCtrl;

    // Use this for initialization
    void Start () {
        plCtrl = player.GetComponent<Player> ();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D(Collider2D other){
        //        print("Trigger!!!!!!!!!!!1");
        if (other.CompareTag("Wall"))
        {
            plCtrl.isStuck = true;

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            plCtrl.isStuck = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            plCtrl.isStuck = false;

        }
    }
}
