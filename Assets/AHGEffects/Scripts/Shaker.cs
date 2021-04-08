using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    Transform target;
    Vector3 initialPos;
    float pendingShakeDuration=0f;
    bool isShaking=false;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
        initialPos = target.localPosition;
        
    }
    void Update()
    {
        if (pendingShakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
        
    }

    public void Shake(float duration)
    {
        if (duration > 0)
        {
            pendingShakeDuration += duration;
        }

    }
    IEnumerator DoShake()
    {
        isShaking = true;
        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + pendingShakeDuration)
        {
            var randomPoint = new Vector3(Random.Range(-1f,-1f),Random.Range(-1f,-1f),initialPos.z);
            target.localPosition = randomPoint;
            yield return null;
        }
        pendingShakeDuration = 0f;
        target.localPosition = initialPos;
        isShaking = false;
    }
}
