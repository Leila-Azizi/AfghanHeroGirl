using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public GameObject crew;
    public GameObject gage;
    public Sprite nextGageImg;
    public Sprite nextImage;
    public Vector2 jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.tag=="Player") {
            
            gameObject.GetComponent<SpriteRenderer>().sprite = nextImage;
            gage.gameObject.GetComponent<SpriteRenderer>().sprite = nextGageImg;

            crew.gameObject.GetComponent<Animator>().enabled = true;
            crew.gameObject.GetComponent<Rigidbody2D>().AddForce(jumpSpeed);

            SFXCtrl.instance.MagicBottle(crew.transform.position);
            AudioController.instance.MagicBottlePickup(crew.transform.position);
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(GoAwayEffect(crew.gameObject));
            Destroy(crew.gameObject, 3f);
        }


    }
  IEnumerator GoAwayEffect(GameObject crew)
    {
        yield return new WaitForSeconds(2.9f);
        AudioController.instance.GrayEnemyDie(crew.transform.position);
        SFXCtrl.instance.GoAwayCrew(crew.transform.position-new Vector3(1f,0,0));
    }
    
}
