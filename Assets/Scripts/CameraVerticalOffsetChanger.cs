using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerticalOffsetChanger : MonoBehaviour
{
    bool isChangeCammeraVerticalOffset;
    public float verticalOffset;
    private void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CameraFollow.isCameraChange = true;
        FindObjectOfType<CameraFollow>().verticalOffset = verticalOffset;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CameraFollow.isCameraChange = false;

    }

}
