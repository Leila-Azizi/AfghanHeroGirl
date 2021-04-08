using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// provide parallax effects .
/// </summary>

public class Parallax : MonoBehaviour {

  
    
      public float speed;
     float offsetX;
      Material mat;
      Player plCtrl;
      public GameObject player;

    private float length, startpos;
    public float parallaxEffects;
    // Use this for initialization
    void Start () {
       plCtrl = player.GetComponent<Player>();
       mat = GetComponent<Renderer> ().material;
      
        //startpos =transform.position.x;
       // length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate () { 
     

        // if (player!=null)
        // {
        //     float temp = (player.transform.position.x * (1 - parallaxEffects));
        //     float dis = (player.transform.position.x * parallaxEffects);
        //    transform.position = new Vector3(startpos + dis, transform.position.y, transform.position.z);
        //     if (temp > startpos + length) startpos += length;
        //    else if (temp < startpos - length) startpos -= length;
        // }

        if (!plCtrl.isStuck)
        {
            if (plCtrl.isMoveLeft)
                offsetX += -speed;
            else if (plCtrl.isMoveRight)
                offsetX += speed;

            offsetX += Input.GetAxisRaw("Horizontal") * speed;
            mat.SetTextureOffset("_MainTex", new Vector2(offsetX, 0));
        }

    }
}
