using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    public int enemyHealth;
    public int pointsOnDeath;
    public GameObject bossPrefab;
    public float minSize;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            if (transform.localScale.y > minSize)
            {
                GameObject clone1 = Instantiate(bossPrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
                GameObject clone2 = Instantiate(bossPrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
                clone1.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z * 0.5f);
                clone1.GetComponent<BossHealthManager>().enemyHealth = 20;
                clone1.GetComponent<PetrolingEnemy>().speed = 2;
                clone2.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z * 0.5f);
                clone2.GetComponent<BossHealthManager>().enemyHealth = 20;
                clone2.GetComponent<PetrolingEnemy>().speed = -2;

            }
            
            Destroy(gameObject);
            SFXCtrl.instance.GreenMonesterDied(transform.position); 
        }
    }

    public void giveDamage(int damageToGive)
    {
        sr.color = Color.red;
        enemyHealth -= damageToGive;
        StartCoroutine(ResetColor());
    }
    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}
