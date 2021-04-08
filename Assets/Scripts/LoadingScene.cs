using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    public static LoadingScene instance;
    [SerializeField]
    private GameObject Loading_Bar_Holder;
    [SerializeField]
    private Image Loading_Bar_Progress;

    private float progress_value = 1.1f;
    public float progress_multiplier1 = 0.5f;
    public float progress_multiplier2 = 0.7f;
    public float load_Level_Time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingSomeLevel("Level1"));
    }

 

    IEnumerator LoadingSomeLevel(string levelName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
        while (!async.isDone)
        {
            float progress = async.progress / 0.9f;
            Loading_Bar_Progress.fillAmount = progress;
          
            yield return null;
        }
       
    }
}

