using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBarCtrl : MonoBehaviour
{
   
    public Transform PlayerPos; //player position
    public Transform endLinePos; //end line position
    public Slider slider; //slider progress bar UI
    float maxDistance; // distance between player and end line.
    public static ProgressBarCtrl instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        maxDistance = getDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPos.position.x<=maxDistance && PlayerPos.position.x<=endLinePos.position.x) // if player is between start and end  note:(start = player position)
        {
            
            float distance = 1 - (getDistance()/maxDistance);
            setProgress(distance);
            
        }
      

    }
    public float getDistance()
    {
        return Vector2.Distance(PlayerPos.position,endLinePos.position);
    }
    void setProgress(float p)
    {
        slider.value = p;
    }

}
