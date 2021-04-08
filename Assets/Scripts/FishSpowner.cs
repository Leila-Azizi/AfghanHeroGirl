using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpowner : MonoBehaviour {
	public GameObject fish;
	public float spawnTime;
	bool canSpawn;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().enabled = false;
        canSpawn = true;

	}

	// Update is called once per frame
	void Update () {
		if(canSpawn){
			StartCoroutine ("SpawnFish");

		}

	}

	IEnumerator SpawnFish(){
		Instantiate (fish,transform.position,Quaternion.identity);
		canSpawn = false;
		yield return new WaitForSeconds (spawnTime);
		canSpawn = true;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            GetComponent<AudioSource>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<AudioSource>().enabled = false;
        }
    }
}
