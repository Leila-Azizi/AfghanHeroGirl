using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormCtrl : MonoBehaviour
{
    public Transform pos1,pos2,startPos;
    Vector3 nextPos;
    public float speed=3;
    
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
