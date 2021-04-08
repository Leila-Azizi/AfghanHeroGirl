using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectToPool;
    public Transform pos;

    public bool shouldExpand;
}

public class SpawnGonal : MonoBehaviour
{
    
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;
    public Transform pos;
    public bool isDirtActive;
   

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        isDirtActive = true;
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
    
    void ActiveGnol()
    {
        if (isDirtActive)
        {
            GameObject gonal = GetPooledObject("GonalEnemy");
            if (gonal != null)
            {
                gonal.transform.position = pos.position;
                gonal.SetActive(true);
            }
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            InvokeRepeating("ActiveGnol", 1f,5f);
        }
        
    }
}
