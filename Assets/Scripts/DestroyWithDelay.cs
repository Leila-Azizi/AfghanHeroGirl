using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
	public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
		Destroy (gameObject,destroyTime);
    }

  
}
